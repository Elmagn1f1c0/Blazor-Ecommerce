using Stripe;
using Stripe.Checkout;

namespace BlazorEcommerce.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IAuthService _authService;

        const string secret = "whsec_edb8591ee9d905cea30d36eab5d68a52a5634b228bee7c152719c1f30082015a";

        public PaymentService(ICartService cartService, IOrderService orderService, IAuthService authService)
        {
            StripeConfiguration.ApiKey = "sk_test_51O9hh6H0KsejqWMFUQM5rvnuyPpR08uqZ5tE2rFkQwEVnhXuNWDU7bMTOrZOHvAF21Pb9kX6GP9IzaTsjdhQDLZm00BVK3l0yb";
            _cartService = cartService;
            _orderService = orderService;
            _authService = authService;
        }

        public async Task<Session> CreateCheckoutSession()
        {
            var products = (await _cartService.GetDbCartProducts()).Data;
            var lineItem = new List<SessionLineItemOptions>();
            products.ForEach(product => lineItem.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions()
                {
                    UnitAmountDecimal = product.Price * 100,
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Title,
                        Images = new List<string> { product.ImageUrl }
                    }
                },
                Quantity = product.Quantity,
            }));

            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                ShippingAddressCollection =
                    new SessionShippingAddressCollectionOptions
                    {
                        AllowedCountries = new List<string> { "US" }
                    },
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItem,
                Mode = "payment",
                SuccessUrl = "https://localhost:7254/order-success",
                CancelUrl = "https://localhost:7254/cart"
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }

        public async Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request)
        {
            var json = await new StreamReader(request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                        json,
                        request.Headers["Stripe-Signature"],
                        secret
                    );

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var user = await _authService.GetUserByEmail(session.CustomerEmail);
                    await _orderService.PlaceOrder(user.Id);
                }

                return new ServiceResponse<bool> { Data = true };
            }
            catch (StripeException e)
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = e.Message };
            }
        }
    }
    
}

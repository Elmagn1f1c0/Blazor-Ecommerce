using BlazorEcommerce.Server.Services.CartService;
using System.Security.Claims;

namespace BlazorEcommerce.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICartService _cartService;

        public OrderService(DataContext context, IHttpContextAccessor httpContextAccessor, ICartService cartService)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _cartService = cartService;
        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<bool>> PlaceOrder()
        {
            var products = (await _cartService.GetDbCartProducts()).Data;
            decimal totalPrice = 0;
            products.ForEach(product => totalPrice += product.Price * product.Quantity);

            var orderItems = new List<OrderItem>();
            products.ForEach(product => orderItems.Add(new OrderItem
            {
                ProductId = product.ProductId,
                ProductTypeId = product.ProductTypeId,
                Quantity = product.Quantity,
                TotalPrice = product.Price * product.Quantity,
            }));

            var order = new Order
            {
                UserId = GetUserId(),
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };


            _context.Orders.Add(order);

            _context.CartItems.RemoveRange(_context.CartItems.Where(c => c.UserId == GetUserId()));

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Data = true
            };
        }
    }
}

namespace BlazorEcommerce.Server.Services.AddressService
{
    public interface IAddressService
    {
        Task<ServiceResponse<Address>> GetAdress();
        Task<ServiceResponse<Address>> AddOrUpdateAdress(Address address);
    }
}

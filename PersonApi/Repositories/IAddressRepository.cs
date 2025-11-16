using PersonApi.Models;

namespace PersonApi.Repositories
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAsync();
        Task<Address?> GetByIdAsync(int id);
        Task<Address> CreateAsync(Address address);
        Task<Address> UpdateAsync(Address address);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        //Task<bool> ExistsAsync(long? addressId);
    }
}
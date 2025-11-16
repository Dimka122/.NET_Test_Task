using PersonApi.DTOs;
using PersonApi.Models;

namespace PersonApi.Services
{
    public interface IAddressService
    {
        Task<IEnumerable<DTOs.AddressDTO>> GetAllAddresses();
        Task<DTOs.AddressDTO?> GetAddressById(int id);
        Task<DTOs.AddressDTO> CreateAddress(CreateAddressDTO createAddressDto);
        Task<DTOs.AddressDTO> UpdateAddress(int id, CreateAddressDTO updateAddressDto);
        Task DeleteAddress(int id);
        Task<bool> AddressExists(int id);
    }
}
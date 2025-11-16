using AutoMapper;
using PersonApi.DTOs;
using PersonApi.Models;
using PersonApi.Repositories;

namespace PersonApi.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DTOs.AddressDTO>> GetAllAddresses()
        {
            var addresses = await _addressRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DTOs.AddressDTO>>(addresses);
        }

        public async Task<DTOs.AddressDTO?> GetAddressById(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            return address == null ? null : _mapper.Map<DTOs.AddressDTO>(address);
        }

        public async Task<DTOs.AddressDTO> CreateAddress(CreateAddressDTO createAddressDto)
        {
            var address = _mapper.Map<Address>(createAddressDto);
            var createdAddress = await _addressRepository.CreateAsync(address);
            return _mapper.Map<DTOs.AddressDTO>(createdAddress);
        }

        public async Task<DTOs.AddressDTO> UpdateAddress(int id, CreateAddressDTO updateAddressDto)
        {
            var existingAddress = await _addressRepository.GetByIdAsync(id);
            if (existingAddress == null)
            {
                throw new ArgumentException($"Address with ID {id} not found");
            }

            _mapper.Map(updateAddressDto, existingAddress);
            var updatedAddress = await _addressRepository.UpdateAsync(existingAddress);
            return _mapper.Map<DTOs.AddressDTO>(updatedAddress);
        }

        public async Task DeleteAddress(int id)
        {
            if (!await _addressRepository.ExistsAsync(id))
            {
                throw new ArgumentException($"Address with ID {id} not found");
            }

            await _addressRepository.DeleteAsync(id);
        }

        public async Task<bool> AddressExists(int id)
        {
            return await _addressRepository.ExistsAsync(id);
        }
    }
}

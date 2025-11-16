using Microsoft.AspNetCore.Mvc;
using PersonApi.DTOs;
using PersonApi.Models;
using PersonApi.Services;

namespace PersonApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOs.AddressDTO>>> GetAll()
        {
            var addresses = await _addressService.GetAllAddresses();
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DTOs.AddressDTO>> GetById(int id)
        {
            var address = await _addressService.GetAddressById(id);
            if (address == null)
                return NotFound();

            return Ok(address);
        }

        [HttpPost]
        public async Task<ActionResult<DTOs.AddressDTO>> Create(CreateAddressDTO createAddressDto)
        {
            try
            {
                var address = await _addressService.CreateAddress(createAddressDto);
                return CreatedAtAction(nameof(GetById), new { id = address.Id }, address);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

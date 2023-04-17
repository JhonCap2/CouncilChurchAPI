using AutoMapper;
using CouncilChurch.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using CouncilChurch.Core.DTOs;
using CouncilChurch.Core.Entities;


namespace CouncilChurch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private IAddressRespository _addressRespository;
        private readonly IMapper _mapper;
        public AddressController(IAddressRespository addressRespository, IMapper mapper)
        {
            _addressRespository = addressRespository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetAddresses()
        {
            var address = await _addressRespository.GetAddresses();
            var addressDto = _mapper.Map<IEnumerable<AddressDto>>(address);
            return Ok(addressDto);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetAddress(Guid id)
        {
            var address = await _addressRespository.GetAddress(id);
            var addressDto = _mapper.Map<AddressDto>(address);
            return Ok(addressDto);
        }
        [HttpPost]
        public async Task<IActionResult> InsertAddress(AddressDto newaddress)
        {
            var addressDto = _mapper.Map<Address>(newaddress);
            await _addressRespository.InsertAddress(addressDto);
            return Ok(addressDto);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateAddress(AddressDto upaddress)
        { 
            var address = _mapper.Map<Address>(upaddress);
            
            await _addressRespository.UpdateAddress(address);
            return Ok(address);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAddress(Guid id)
        {
            var address = await _addressRespository.GetAddress(id);
            var adDelete = await _addressRespository.DeleteAddress(id);
            if (adDelete) 
            return Ok($"La dirección {address.AddressChurch} fue eliminada correctamente ");
            else
            return StatusCode(500, $"Operación no procesada o el GUID '{id}'no existe.");
        }
    }
}

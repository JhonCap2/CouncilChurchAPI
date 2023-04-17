using AutoMapper;
using CouncilChurch.Core.DTOs;
using CouncilChurch.Core.Entities;
using CouncilChurch.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CouncilChurch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChurchController : Controller
    {

        private IChurchRepository _churchRepository;
        private readonly IMapper _mapper;
        public ChurchController(IChurchRepository churchRepository, IMapper mapper)
        {
            _churchRepository = churchRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetChurchs()
        {
            var churchs = await _churchRepository.GetChurchs();
            var ChurchsDto = _mapper.Map<IEnumerable<ChurchDto>>(churchs);
            return Ok(ChurchsDto);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetChurch(Guid id)
        {
            var address = await _churchRepository.GetChurch(id);
            var addressDto = _mapper.Map<AddressDto>(address);
            return Ok(addressDto);
        }
        [HttpPost]
        public async Task<IActionResult> InsertChurch(ChurchDto newchurch)
        {
            var church = _mapper.Map<Church>(newchurch);
            await _churchRepository.InsertChurch(church);
            return Ok(church);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateChurch(ChurchDto upchurch)
        {
            var church = _mapper.Map<Church>(upchurch);
            await _churchRepository.UpdateChurch(church);
            return Ok(church);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteChurch(Guid id)
        {
            var church = await _churchRepository.GetChurch(id);
            var churchDelete = await _churchRepository.DeleteChurch(id);
            if(churchDelete)
                return Ok($"La iglesia {churchDelete} fue eliminada");
            else
            return StatusCode(500, $"Operación no procesada o el GUID '{id}'no existe.");
        }
    }

}

using AutoMapper;
using CouncilChurch.Core.DTOs;
using CouncilChurch.Core.Entities;
using CouncilChurch.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CouncilChurch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouncilController : Controller
    {
        private ICouncilRepository _councilRepository;
        private readonly IMapper _mapper;
        public CouncilController(ICouncilRepository councilRepository, IMapper mapper)
        {
            _councilRepository = councilRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetCouncils()
        {
            var councils = await _councilRepository.GetCouncils();
            var councilDtos = _mapper.Map<IEnumerable<CouncilDto>>(councils);
            return Ok(councilDtos);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCouncil(Guid id)
        {
            var council = await _councilRepository.GetCouncil(id);
            var councilDtos = _mapper.Map<CouncilDto>(council);
            return Ok(councilDtos);
        }
        [HttpPost]
        public async Task<IActionResult> InsertCouncil(CouncilDto newcouncil)
        {

            var council = _mapper.Map<Council>(newcouncil);
            await _councilRepository.InsertCouncil(council);
            return Ok(council);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCouncil(CouncilDto upcouncil)
        {
            var council = _mapper.Map<Council>(upcouncil);
            await _councilRepository.UpdateCouncil(council);
            return Ok(council);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCouncil(Guid id)
        {
            var council = await _councilRepository.GetCouncil(id);
            var councilDelete = await _councilRepository.DeleteCouncil(id);
            if (councilDelete)
                return Ok($"El concilio {council.Imail} Fue eliminado.");
            else
                return StatusCode(500, $"Operación no procesada o el GUID '{id}'no existe.");
        }
    }
}

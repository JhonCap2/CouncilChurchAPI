using AutoMapper;
using CouncilChurch.Core.DTOs;
using CouncilChurch.Core.Entities;
using CouncilChurch.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CouncilChurch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CivilStateController : Controller
    {
        private ICivilStateRepository _civilStateRepository;
        private readonly IMapper _mapper;
        public CivilStateController(ICivilStateRepository civilStateRepository, IMapper mapper)
        {
            _civilStateRepository = civilStateRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetCivilStates()
        {
            var civils = await _civilStateRepository.GetCivilStates();
            var civilDto = _mapper.Map<IEnumerable<CivilStateDto>>(civils);
            return Ok(civilDto);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCivilState(Guid id)
        {
            var civils = await _civilStateRepository.GetCivilState(id);
            var civilDto = _mapper.Map<CivilStateDto>(civils);
            return Ok(civilDto);
        }
        [HttpPost]
        public async Task<IActionResult> InsertCivilState(CivilStateDto newcivilState)
        {
            var civilState = _mapper.Map<CivilState>(newcivilState);
            await _civilStateRepository.InsertCivilState(civilState);
            return Ok(civilState);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCivilState(CivilStateDto upcivilStateDto)
        {
            var civils = _mapper.Map<CivilState>(upcivilStateDto);
            await _civilStateRepository.UpdateCivilState(civils);
            return Ok(civils);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCivilState(Guid id)
        {
            var civil = await _civilStateRepository.GetCivilState(id);
            var civilsDelete = await _civilStateRepository.DeleteCivilState(id);
            if (civilsDelete)
                return Ok($"El estado civil {civil.NameCivilState} fue eliminado.");
            else
                return StatusCode(500, $"Operación no procesada o el GUID '{id}'no existe.");
        }
    }
}

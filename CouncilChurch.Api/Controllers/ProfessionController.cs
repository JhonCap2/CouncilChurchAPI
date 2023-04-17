using AutoMapper;
using CouncilChurch.Core.DTOs;
using CouncilChurch.Core.Entities;
using CouncilChurch.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CouncilChurch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionController : Controller
    {
        private IProfessionRepository _professionRepository;
        private readonly IMapper _mapper;
        public ProfessionController(IProfessionRepository professionRepository, IMapper mapper)
        {
            _professionRepository = professionRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetProfessions()
        {
            var professions = await _professionRepository.GetProfessions();
            var professionDtos = _mapper.Map<IEnumerable<ProfessionDto>>(professions);
            return Ok(professionDtos);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProfession(Guid id)
        {
            var professions = await _professionRepository.GetProfession(id);
            var professionDtos = _mapper.Map<ProfessionDto>(professions);
            return Ok(professionDtos);
        }
        [HttpPost]
        public async Task<IActionResult> InsertProfession(ProfessionDto newprofession)
        {
            var profession = _mapper.Map<Profession>(newprofession);
            await _professionRepository.InsertProfession(profession);
            return Ok(profession);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateProfession(ProfessionDto upprofession)
        {
            var profession = _mapper.Map<Profession>(upprofession);
            await _professionRepository.UpdateProfession(profession);
            return Ok(profession);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProfession(Guid id)
        {
            var profession = await _professionRepository.GetProfession(id);
            var professionDelete = await _professionRepository.DeleteProfession(id);
            if(professionDelete)
                return Ok($"La profesion {profession.NameProfession} fue eliminada.");
             else
                return StatusCode(500, $"Operación no procesada o el GUID '{id}'no existe.");
        }
    }
}

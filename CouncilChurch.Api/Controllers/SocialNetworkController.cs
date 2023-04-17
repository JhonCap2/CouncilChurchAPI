using AutoMapper;
using CouncilChurch.Core.DTOs;
using CouncilChurch.Core.Entities;
using CouncilChurch.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CouncilChurch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialNetworkController : Controller
    {
        private ISocialNetworkRepository _socialNetworkRepository;
        private readonly IMapper _mapper;
        public SocialNetworkController(ISocialNetworkRepository socialNetworkRepository, IMapper mapper)
        {
            _socialNetworkRepository = socialNetworkRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetSocialNetworks()
        {
            var socialNetworks = await _socialNetworkRepository.GetSocialNetworks();
            var socialNetworkDtos = _mapper.Map<IEnumerable<SocialNetworkDto>>(socialNetworks);
            return Ok(socialNetworkDtos);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetSocialNetwork(Guid id)
        {
            var socialNetwork = await _socialNetworkRepository.GetSocialNetwork(id);
            var socialNetworkDto = _mapper.Map<SocialNetworkDto>(socialNetwork);
            return Ok(socialNetworkDto);
        }
        [HttpPost]
        public async Task<IActionResult> InsertSocialNetwork(SocialNetworkDto newsocialnetwork)
        {
            var socialNetwork = _mapper.Map<SocialNetwork>(newsocialnetwork);
            await _socialNetworkRepository.InsertSocialNetwork(socialNetwork);
            return Ok(socialNetwork);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateSocialNetwork(SocialNetworkDto upsocialnetwork)
        {
            var socialNetwork = _mapper.Map<SocialNetwork>(upsocialnetwork);
            await _socialNetworkRepository.UpdateSocialNetwork(socialNetwork);
            return Ok(socialNetwork);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSocialNetwork(Guid id)
        {
            var socialNetwork = await _socialNetworkRepository.GetSocialNetwork(id);
            var SNDeleted = await _socialNetworkRepository.DeleteSocialNetwork(id);
            if (SNDeleted)
                return Ok($"La red social {socialNetwork.NameNetworks} ha sido eliminada con exito.");
            else
                return StatusCode(500,$"Operación no procesada o el GUID '{id}'no existe.");
        }
    }
}

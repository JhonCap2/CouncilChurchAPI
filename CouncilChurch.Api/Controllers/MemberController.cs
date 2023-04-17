using AutoMapper;
using CouncilChurch.Core.DTOs;
using CouncilChurch.Core.Entities;
using CouncilChurch.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CouncilChurch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : Controller
    {
        private IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        public MemberController(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetMembers()
        {
            var members = await _memberRepository.GetMembers();
            var memberDtos = _mapper.Map<IEnumerable<MemberDto>>(members);
            return Ok(memberDtos);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetMember(Guid id)
        {
            var members = await _memberRepository.GetMember(id);
            var memberDto = _mapper.Map<MemberDto>(members);
            return Ok(memberDto);
        }
        [HttpPost]
        public async Task<IActionResult> InsertMember(MemberDto newmember)
        {
            var member = _mapper.Map<Member>(newmember);
            await _memberRepository.InsertMember(member);
            return Ok(member);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateMember(MemberDto upmember)
        {
            var member = _mapper.Map<Member>(upmember);
            await _memberRepository.UpdateMember(member);
            return Ok(member);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMember(Guid id)
        {
            var member = await _memberRepository.GetMember(id);
            var memberDelete = await _memberRepository.DeleteMember(id);
            if(memberDelete)
                return Ok($"El miembro de nombre {member.Nickname} apellido {member.FirstSurname} fue eliminado");
            else
                return StatusCode(500, $"Operación no procesada o el GUID '{id}'no existe.");
        }
    }
}

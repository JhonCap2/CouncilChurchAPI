using AutoMapper.Execution;
using CouncilChurch.Core.Entities;
using CouncilChurch.Core.Interface;
using CouncilChurch.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Infraestructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DbChurchContext _context;

        public MemberRepository(DbChurchContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteMember(Guid id)
        {
            var currentmember = await GetMember(id);
            _context.Members.Remove(currentmember);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Member> GetMember(Guid id)
        {
            var member = await _context.Members.Include(x => x.IdProfession)
                    .Include(x => x.IdAddress)
                    .Include(x => x.IdChurch)
                    .SingleOrDefaultAsync(x => x.IdMembers == id);
            return member;
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            var members = await _context.Members.ToListAsync();
            return members;
        }

        public async Task InsertMember(Member newmember)
        {
            await _context.Members.AddAsync(newmember);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateMember(Member member)
        {
            var currentchurch = await GetMember(member.);
            currentchurch.NameChurch = member.NameChurch;
            currentchurch.IdAddress = member.IdAddress;
            currentchurch.IdCouncil = member.IdCouncil;
            currentchurch.Web = member.Web;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}

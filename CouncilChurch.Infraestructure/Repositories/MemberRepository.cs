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

        public async Task<Core.Entities.Member> GetMember(Guid id)
        {
            var member = await _context.Members
                    .Include(x => x.IdChurchNavigation)
                    .Include(x => x.IdAddressNavigation)
                    .Include(x => x.IdProfessionNavigation)
                    .Include(x => x.IdCivilStatesNavigation)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.IdMembers == id);
            return member;
        }

        public async Task<IEnumerable<Core.Entities.Member>> GetMembers()
        {
            var members = await _context.Members.ToListAsync();
            return members;
        }

        public async Task InsertMember(Core.Entities.Member newmember)
        {
            await _context.Members.AddAsync(newmember);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateMember(Core.Entities.Member member)
        {
            var currentchurch = await GetMember(member.IdMembers);
            if (currentchurch == null) { return false; }

            _context.Attach(member).State = EntityState.Modified;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}

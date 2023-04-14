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
            var church = await _context.Members
                    .Include(x => x.IdChurch)
                    .Include(x => x.IdAddress)
                    .Include(x => x.IdProfession)
                    .Include(x => x.IdCivilStates)
                    .SingleOrDefaultAsync(x => x.IdMembers == id);
            return church;
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
            currentchurch.IdChurch = member.IdChurch;
            currentchurch.IdProfession = member.IdProfession;
            currentchurch.IdAddress = member.IdAddress;
            currentchurch.IdCivilStates = member.IdCivilStates;
            currentchurch.FirstName = member.FirstName;
            currentchurch.SecondName = member.SecondName;
            currentchurch.FirstSurname = member.FirstSurname;
            currentchurch.SecondSurname = member.SecondSurname;
            currentchurch.Nickname = member.Nickname;
            currentchurch.Birthdate = member.Birthdate;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}

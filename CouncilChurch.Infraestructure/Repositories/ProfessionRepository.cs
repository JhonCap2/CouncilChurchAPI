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
    public class ProfessionRepository : IProfessionRepository
    {
        private readonly DbChurchContext _context;

        public ProfessionRepository(DbChurchContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteProfession(Guid id)
        {
            var currentprofession = await GetProfession(id);
            _context.Professions.Remove(currentprofession);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Profession> GetProfession(Guid id)
        {
            var profession = await _context.Professions.SingleOrDefaultAsync(x => x.IdProfession == id);
            return profession;
        }

        public async Task<IEnumerable<Profession>> GetProfessions()
        {
            var professions = await _context.Professions.ToListAsync();
            return professions;
        }

        public async Task InsertProfession(Profession newprofession)
        {
            await _context.Professions.AddAsync(newprofession);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateProfession(Profession profession)
        {
            var currentchurch = await GetProfession(profession.IdProfession);
            currentchurch.NameProfession = profession.NameProfession;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}

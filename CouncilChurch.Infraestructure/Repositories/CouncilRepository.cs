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
    public class CouncilRepository : ICouncilRepository
    {
        private readonly DbChurchContext _context;

        public CouncilRepository(DbChurchContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteCouncil(Guid id)
        {
            var currentcouncil = await GetCouncil(id);
            _context.Councils.Remove(currentcouncil);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Council> GetCouncil(Guid id)
        {
            var council = await _context.Councils.Include(x => x.IdSocialNetworks).SingleOrDefaultAsync(x => x.IdCouncil == id);
            return council;
        }

        public async Task<IEnumerable<Council>> GetCouncils()
        {
            var council = await _context.Councils.ToListAsync();
            return council;
        }

        public async Task InsertCouncil(Council newcouncil)
        {
            await _context.Councils.AddAsync(newcouncil);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateCouncil(Council council)
        {
            var currentaddress = await GetCouncil(council.IdCouncil);
            currentaddress.IdSocialNetworks = council.IdSocialNetworks;
            currentaddress.Web = council.Web;
            currentaddress.Rnc = council.Rnc;
            currentaddress.Imail = council.Imail;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}

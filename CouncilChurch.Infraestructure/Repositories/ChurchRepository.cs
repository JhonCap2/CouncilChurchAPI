using CouncilChurch.Core.Entities;
using CouncilChurch.Core.Interface;
using CouncilChurch.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Infraestructure.Repositories
{
    public class ChurchRepository : IChurchRepository
    {
        private readonly DbChurchContext _context;

        public ChurchRepository(DbChurchContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteChurch(Guid id)
        {
            var currentchurch = await GetChurch(id);
            _context.Churches.Remove(currentchurch);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Church> GetChurch(Guid id)
        {
            var church = await _context.Churches
                    .Include(x => x.IdAddressNavigation)
                    .Include(x => x.IdCouncilNavigation)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.IdChurch == id);
            return church;
        }

        public async Task<IEnumerable<Church>> GetChurchs()
        {
            var churchs = await _context.Churches.ToListAsync();
            return churchs;
        }

        public async Task InsertChurch(Church newchurch)
        {
            await _context.Churches.AddAsync(newchurch);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateChurch(Church church)
        {
            var currentchurch = await GetChurch(church.IdChurch);
            if (currentchurch == null) { return false; }

            _context.Attach(currentchurch).State = EntityState.Modified;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}

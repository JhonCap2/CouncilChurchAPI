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
    public class CivilStateRepository : ICivilStateRepository
    {
        private readonly DbChurchContext _context;

        public CivilStateRepository(DbChurchContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteCivilState(Guid id)
        {
            var currentcivilstate = await GetCivilState(id);
            _context.CivilStates.Remove(currentcivilstate);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<CivilState> GetCivilState(Guid id)
        {
            var civilstate = await _context.CivilStates.AsNoTracking().SingleOrDefaultAsync(x => x.IdCivilStates == id);
            return civilstate;
        }

        public async Task<IEnumerable<CivilState>> GetCivilStates()
        {
            var civilstate = await _context.CivilStates.ToListAsync();
            return civilstate;
        }

        public async Task InsertCivilState(CivilState newcivilstate)
        {
            await _context.CivilStates.AddAsync(newcivilstate);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateCivilState(CivilState civilstate)
        {
            var currentaddress = await GetCivilState(civilstate.IdCivilStates);
            if(currentaddress == null) { return false; }

            _context.Attach(civilstate).State = EntityState.Modified;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}

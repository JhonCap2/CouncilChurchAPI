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
    public class SocialNetworkRepository : ISocialNetworkRepository
    {
        private readonly DbChurchContext _context;

        public SocialNetworkRepository(DbChurchContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteSocialNetwork(Guid id)
        {
            var currentsocialnetwork = await GetSocialNetwork(id);
            _context.SocialNetworks.Remove(currentsocialnetwork);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<SocialNetwork> GetSocialNetwork(Guid id)
        {
            var socialnetwork = await _context.SocialNetworks.SingleOrDefaultAsync(x => x.IdSocialNetworks == id);
            return socialnetwork;
        }

        public async Task<IEnumerable<SocialNetwork>> GetSocialNetworks()
        {
            var socialnetwork = await _context.SocialNetworks.ToListAsync();
            return socialnetwork;
        }

        public async Task InsertSocialNetwork(SocialNetwork newsocialNetwork)
        {
            await _context.SocialNetworks.AddAsync(newsocialNetwork);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateSocialNetwork(SocialNetwork socialNetwork)
        {
            var currentsocialnetwork = await GetSocialNetwork(socialNetwork.IdSocialNetworks);
            currentsocialnetwork.NameNetworks = socialNetwork.NameNetworks;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}

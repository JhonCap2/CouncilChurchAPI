using CouncilChurch.Core.DTOs;
using CouncilChurch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Interface
{
    public interface ISocialNetworkRepository
    {
        Task<IEnumerable<SocialNetwork>> GetSocialNetworks(); 
        Task<SocialNetwork> GetSocialNetwork(Guid id);
        Task InsertSocialNetwork(SocialNetwork newsocialNetwork);
        Task<bool> UpdateSocialNetwork(SocialNetwork socialNetwork);
        Task<bool> DeleteSocialNetwork(Guid id);
    }
}

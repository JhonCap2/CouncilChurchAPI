using CouncilChurch.Core.DTOs;
using CouncilChurch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Interface
{
    public interface ICouncilRepository
    {
        Task<IEnumerable<Council>> GetCouncils();
        Task<Council> GetCouncil(Guid id);
        Task InsertCouncil(Council newcouncil);
        Task<bool> UpdateCouncil(Council council);
        Task<bool> DeleteCouncil(Guid id);
    }
}

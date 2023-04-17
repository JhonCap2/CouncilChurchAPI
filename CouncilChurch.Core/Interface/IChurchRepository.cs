using CouncilChurch.Core.DTOs;
using CouncilChurch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Interface
{
    public interface IChurchRepository
    {
        Task<IEnumerable<Church>> GetChurchs();
        Task<Church> GetChurch(Guid id);
        Task InsertChurch(Church newchurch);
        Task<bool> UpdateChurch(Church church);
        Task<bool> DeleteChurch(Guid id);
    }
}

using CouncilChurch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Interface
{
    public interface ICivilStateRepository
    {
        Task<IEnumerable<ICivilStateRepository>> GetCivilStates();
        Task<ICivilStateRepository> GetCivilState(Guid id);
        Task InsertCivilState(ICivilStateRepository newcivilstate);
        Task<bool> UpdateCivilState(ICivilStateRepository civilstate);
        Task<bool> DeleteCivilState(Guid id);
    }
}

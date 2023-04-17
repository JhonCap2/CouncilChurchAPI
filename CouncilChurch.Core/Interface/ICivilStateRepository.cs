using CouncilChurch.Core.DTOs;
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
        Task<IEnumerable<CivilState>> GetCivilStates();
        Task<CivilState> GetCivilState(Guid id);
        Task InsertCivilState(CivilState newcivilstate);
        Task<bool> UpdateCivilState(CivilState civilstate);
        Task<bool> DeleteCivilState(Guid id);
    }
}

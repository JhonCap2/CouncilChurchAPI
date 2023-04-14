using CouncilChurch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Interface
{
    public interface IProfessionRepository
    {
        Task<IEnumerable<Profession>> GetProfessions();
        Task<Profession> GetProfession(Guid id);
        Task InsertProfession(Profession newprofession);
        Task<bool> UpdateProfession(Profession profession);
        Task<bool> DeleteProfession(Guid id);
    }
}

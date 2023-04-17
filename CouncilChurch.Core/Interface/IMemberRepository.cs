using CouncilChurch.Core.DTOs;
using CouncilChurch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Interface
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetMembers();
        Task<Member> GetMember(Guid id);
        Task InsertMember(Member newmember);
        Task<bool> UpdateMember(Member member);
        Task<bool> DeleteMember(Guid id);
    }
}

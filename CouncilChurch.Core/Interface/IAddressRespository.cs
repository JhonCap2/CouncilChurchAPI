using CouncilChurch.Core.DTOs;
using CouncilChurch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Interface
{
    public interface IAddressRespository
    {
        Task<IEnumerable<Address>> GetAddresses();
        Task<Address> GetAddress(Guid id);
        Task InsertAddress(Address newaddress);
        Task<bool> UpdateAddress(Address address);
        Task<bool> DeleteAddress(Guid id);
    }
}

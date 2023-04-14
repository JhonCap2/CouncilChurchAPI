using CouncilChurch.Core.Entities;
using CouncilChurch.Core.Interface;
using CouncilChurch.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Infraestructure.Repositories
{
    public class AddressRepository : IAddressRespository
    {
        private readonly DbChurchContext  _context;

        public AddressRepository(DbChurchContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteAddress(Guid id)
        {
            var currentaddress = await GetAddress(id);
            _context.Addresses.Remove(currentaddress);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Address> GetAddress(Guid id)
        {
            var addresses = await _context.Addresses.SingleOrDefaultAsync(x => x.IdAddress == id);
            return addresses;
        }

        public async Task<IEnumerable<Address>> GetAddresses()
        {
            var addresse = await _context.Addresses.ToListAsync();
            return addresse;
        }

        public async Task InsertAddress(Address newaddress)
        {
            await _context.Addresses.AddAsync(newaddress);
            _context.SaveChanges();
        }

        public async Task<bool> UpdateAddress(Address address)
        {
            var currentaddress = await GetAddress(address.IdAddress);
            currentaddress.AddressChurch = address.AddressChurch;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}

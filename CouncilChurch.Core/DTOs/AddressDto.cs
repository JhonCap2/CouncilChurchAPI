using CouncilChurch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Core.DTOs
{
    public class AddressDto
    {
        public Guid IdAddress { get; set; }

        public string? AddressChurch { get; set; }

        public virtual ICollection<Church> Churches { get; set; } = new List<Church>();

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }
}

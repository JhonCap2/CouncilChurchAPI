using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Entities
{
    public partial class Address
    {
        public Guid IdAddress { get; set; }

        public string? AddressChurch { get; set; }

        public virtual ICollection<Church> Churches { get; set; } = new List<Church>();

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }
}

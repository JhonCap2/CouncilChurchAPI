using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Entities
{
    public partial class Address
    {
        public Guid IdAddress { get; set; }

        public string? AddressChurch { get; set; }
        [JsonIgnore]
        public virtual ICollection<Church> Churches { get; set; } = new List<Church>();
        [JsonIgnore]
        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }
}

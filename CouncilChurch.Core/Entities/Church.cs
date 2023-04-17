using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Entities
{
    public partial class Church
    {
        public Guid IdChurch { get; set; }

        public Guid? IdCouncil { get; set; }

        public Guid? IdAddress { get; set; }

        public string? NameChurch { get; set; }

        public string? Web { get; set; }
        [JsonIgnore]
        public virtual Address? IdAddressNavigation { get; set; }
        [JsonIgnore]
        public virtual Council? IdCouncilNavigation { get; set; }
        
        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }
}

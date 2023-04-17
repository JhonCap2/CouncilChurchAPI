using CouncilChurch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CouncilChurch.Core.DTOs
{
    public class ChurchDto
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
        [JsonIgnore]
        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }
}

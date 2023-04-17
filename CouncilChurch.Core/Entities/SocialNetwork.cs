using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Entities
{
    public partial class SocialNetwork
    {
        public Guid IdSocialNetworks { get; set; }

        public string? NameNetworks { get; set; }
        [JsonIgnore]
        public virtual ICollection<Council> Councils { get; set; } = new List<Council>();
    }
}

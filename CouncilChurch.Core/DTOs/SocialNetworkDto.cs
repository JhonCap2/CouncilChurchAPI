using CouncilChurch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CouncilChurch.Core.DTOs
{
    public class SocialNetworkDto
    {
       
        public Guid IdSocialNetworks { get; set; }

        public string? NameNetworks { get; set; }
        [JsonIgnore]
        public virtual ICollection<Council> Councils { get; set; } = new List<Council>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Entities
{
    public partial class Council
    {
        public Guid IdCouncil { get; set; }

        public Guid? IdSocialNetworks { get; set; }

        public string? Rnc { get; set; }

        public string? Imail { get; set; }

        public string? Web { get; set; }

        public virtual ICollection<Church> Churches { get; set; } = new List<Church>();

        public virtual SocialNetwork? IdSocialNetworksNavigation { get; set; }
    }
}

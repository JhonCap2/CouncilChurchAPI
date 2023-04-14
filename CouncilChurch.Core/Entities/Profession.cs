using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Entities
{
    public partial class Profession
    {
        public Guid IdProfession { get; set; }

        public string? NameProfession { get; set; }

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }
}

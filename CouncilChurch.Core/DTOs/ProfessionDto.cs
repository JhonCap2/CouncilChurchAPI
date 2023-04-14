using CouncilChurch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Core.DTOs
{
    public class ProfessionDto
    {
        public Guid IdProfession { get; set; }

        public string? NameProfession { get; set; }

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }
}

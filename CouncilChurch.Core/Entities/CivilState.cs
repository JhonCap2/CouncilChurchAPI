﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Entities
{
    public partial class CivilState
    {
        public Guid IdCivilStates { get; set; }

        public string? NameCivilState { get; set; }

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }
}
﻿using CouncilChurch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CouncilChurch.Core.DTOs
{
    public class CivilStateDto
    {
        
        public Guid IdCivilStates { get; set; }

        public string? NameCivilState { get; set; }
        [JsonIgnore]
        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }
}

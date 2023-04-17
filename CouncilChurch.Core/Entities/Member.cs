using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CouncilChurch.Core.Entities
{
    public partial class Member
    {
        public Guid IdMembers { get; set; }

        public Guid? IdAddress { get; set; }

        public Guid? IdChurch { get; set; }

        public Guid? IdCivilStates { get; set; }

        public Guid? IdProfession { get; set; }

        public string? FirstName { get; set; }
        
        public string? SecondName { get; set; } //Cambiar el second por Last

        public string? FirstSurname { get; set; }

        public string? SecondSurname { get; set; }

        public string? Nickname { get; set; }

        public DateTime? Birthdate { get; set; }
        [JsonIgnore]
        public virtual Address? IdAddressNavigation { get; set; }
        
        public virtual Church? IdChurchNavigation { get; set; }
        
        public virtual CivilState? IdCivilStatesNavigation { get; set; }
        
        public virtual Profession? IdProfessionNavigation { get; set; }
    }
}

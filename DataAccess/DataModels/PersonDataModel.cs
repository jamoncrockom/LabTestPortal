using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabTestPortal.DataAccess.DataModels
{
    public class PersonDataModel
    {
        [Column("person_id")]
        public int PersonId { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("state_id")]
        public int StateId { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        [Column("dob")]
        public DateTime? Dob { get; set; }
    }
}

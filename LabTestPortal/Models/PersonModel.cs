using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LabTestPortal.DataAccess.DataModels;

namespace LabTestPortal.Models
{
    public class PersonModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StateId { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public List<StateDataModel> States { get; set; }
        public PersonSearchDataModel PersonSearch { get; set; }
    }
}

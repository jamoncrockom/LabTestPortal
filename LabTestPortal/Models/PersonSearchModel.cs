using System.Collections.Generic;
using LabTestPortal.DataAccess.DataModels;

namespace LabTestPortal.Models
{
    public class PersonSearchModel
    {
        public PersonSearchDataModel PersonSearch { get; set; }
        public List<PersonModel> Persons { get; set; }
        public List<StateDataModel> States { get; set; }
    }
}

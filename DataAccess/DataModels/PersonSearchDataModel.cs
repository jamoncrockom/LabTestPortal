
namespace LabTestPortal.DataAccess.DataModels
{
    public class PersonSearchDataModel
    {
        public string SearchFirstName { get; set; }
        public string SearchLastName { get; set; }
        public int? SearchStateId { get; set; }
        public string SearchGender { get; set; }
        public string SearchDob { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace LabTestPortal.DataAccess.DataModels
{
    public class StateDataModel
    {
        [Column("state_id")]
        public int? StateId { get; set; }
        
        [Column("state_code")]
        public string StateCode { get; set; }
    }
}

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using LabTestPortal.DataAccess.DataModels;

namespace LabTestPortal.DataAccess
{
    public class PersonData
    {
        public static int PersonUpsert(PersonDataModel personDataModel)
        {
            using (var connection = new SqlConnection(ConnectionFactory.Connection))
            {
                return (int)connection.ExecuteScalar("uspPersonUpsert",
                    new {
                        person_id = personDataModel.PersonId,
                        first_name = personDataModel.FirstName,
                        last_name = personDataModel.LastName,
                        state_id = personDataModel.StateId,
                        gender = personDataModel.Gender,
                        dob = personDataModel.Dob
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public static PersonDataModel GetPerson(int personId)
        {
            using (var connection = new SqlConnection(ConnectionFactory.Connection))
            {
                return connection.QueryFirst<PersonDataModel>("uspPersonGet", new { person_id = personId }, commandType: CommandType.StoredProcedure);
            }
        }

        public static List<PersonDataModel> GetPersons(PersonSearchDataModel personSearchDataModel)
        {
            using (var connection = new SqlConnection(ConnectionFactory.Connection))
            {
                return connection.Query<PersonDataModel>("uspPersonSearch", 
                    new {
                        first_name = personSearchDataModel.SearchFirstName,
                        last_name = personSearchDataModel.SearchLastName,
                        state_id = personSearchDataModel.SearchStateId,
                        gender = personSearchDataModel.SearchGender,
                        dob = personSearchDataModel.SearchDob,
                    }, commandType: CommandType.StoredProcedure).AsList();
            }
        }
    }
}

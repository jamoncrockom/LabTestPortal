using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using LabTestPortal.DataAccess.DataModels;

namespace LabTestPortal.DataAccess
{
    public class StateData
    {
        public static List<StateDataModel> GetStates()
        {
            using (var connection = new SqlConnection(ConnectionFactory.Connection))
            {
                return connection.Query<StateDataModel>("uspStatesList", commandType: CommandType.StoredProcedure).AsList();
            }
        }
    }
}

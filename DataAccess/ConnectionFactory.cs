using Dapper;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using LabTestPortal.DataAccess.DataModels;

namespace LabTestPortal.DataAccess
{
    public class ConnectionFactory
    {
        public static string Connection;

        public static void Configure(string connection)
        {
            Connection = connection;
            ConfigureTypeMap<PersonDataModel>();
            ConfigureTypeMap<StateDataModel>();
        }

        private static void ConfigureTypeMap<TModel>() =>
            SqlMapper.SetTypeMap(
                typeof(TModel),
                new CustomPropertyTypeMap(
                    typeof(TModel),
                    (type, columnName) =>
                        type.GetProperties().FirstOrDefault(prop =>
                            prop.GetCustomAttributes(false)
                                .OfType<ColumnAttribute>()
                                .Any(attr => attr.Name == columnName))));
    }
}

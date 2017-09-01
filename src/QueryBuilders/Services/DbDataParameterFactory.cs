using System;
using System.Data;

namespace QueryBuilders.Services
{
    public class DbDataParameterFactory : IDbDataParameterFactory
    {
        public void AddParameterWithValue(IDbCommand command, string name, object value)
        {
            if (value == null)
            {
                value = DBNull.Value;
            }
            var parameter = command.CreateParameter();
            if (value is Enum)
            {
                var underlyingType = Enum.GetUnderlyingType(value.GetType());
                value = Convert.ChangeType(value, underlyingType);
            }
            parameter.ParameterName = name;
            parameter.Value = value;
            if (value is DateTime)
            {
                parameter.DbType = DbType.DateTime;
            }
            command.Parameters.Add(parameter);
        }
    }
}
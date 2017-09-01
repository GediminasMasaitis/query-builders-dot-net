using System.Data;

namespace QueryBuilders.Services
{
    public interface IDbDataParameterFactory
    {
        void AddParameterWithValue(IDbCommand command, string name, object value);
    }
}
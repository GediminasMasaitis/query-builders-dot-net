using System.Data;

namespace QueryBuilders
{
    public interface IDbDataParameterFactory
    {
        void AddParameterWithValue(IDbCommand command, string name, object value);
    }
}
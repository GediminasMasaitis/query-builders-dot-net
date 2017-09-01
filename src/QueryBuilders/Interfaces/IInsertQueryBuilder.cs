using System.Collections.Generic;
using System.Text;
using QueryBuilders.Buildables;

namespace QueryBuilders.Interfaces
{
    public interface IInsertQueryBuilder : IQueryBuilder, IHasTableBuilder, IHasValuesBuilder, IHasReturningBuilder, IHasSelectQueryBuilder
    {
    }
}
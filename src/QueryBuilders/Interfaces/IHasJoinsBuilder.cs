using QueryBuilders.Buildables;
using QueryBuilders.Models;

namespace QueryBuilders.Interfaces
{
    public interface IHasJoinsBuilder
    {
        QueryJoin AddJoin(string table, QueryJoinType joinType = QueryJoinType.Inner);
    }
}
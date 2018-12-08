using QueryBuilders.Buildables;
using QueryBuilders.Models;

namespace QueryBuilders.Interfaces
{
    interface IHasJoinsBuilder
    {
        QueryJoin AddJoin(string table, QueryJoinType joinType = QueryJoinType.Inner);
    }
}
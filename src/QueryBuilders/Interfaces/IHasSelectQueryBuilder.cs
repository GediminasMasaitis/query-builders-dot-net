using QueryBuilders.Builders;

namespace QueryBuilders.Interfaces
{
    public interface IHasSelectQueryBuilder
    {
        SelectQueryBuilder SelectQuery { get; }
    }
}
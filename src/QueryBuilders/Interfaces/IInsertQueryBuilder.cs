namespace QueryBuilders.Interfaces
{
    public interface IInsertQueryBuilder : IQueryBuilder, IHasTableBuilder, IHasValuesBuilder, IHasReturningBuilder, IHasSelectQueryBuilder
    {
    }
}
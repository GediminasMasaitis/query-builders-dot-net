namespace QueryBuilders.Interfaces
{
    public interface ISelectQueryBuilder : IQueryBuilder, IHasFieldsBuilder, IHasFromsBuilder, IHasJoinsBuilder, IHasOrderByBuilder, IHasGroupByBuilder, IHasLimitBuilder, IHasOffsetBuilder
    {
    }
}

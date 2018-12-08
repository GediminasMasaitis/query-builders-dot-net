namespace QueryBuilders.Interfaces
{
    interface ISelectQueryBuilder : IQueryBuilder, IHasFieldsBuilder, IHasFromsBuilder, IHasJoinsBuilder, IHasOrderByBuilder, IHasGroupByBuilder, IHasLimitBuilder, IHasOffsetBuilder
    {
    }
}

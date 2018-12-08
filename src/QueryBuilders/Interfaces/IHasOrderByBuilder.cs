namespace QueryBuilders.Interfaces
{
    interface IHasOrderByBuilder
    {
        void AddOrderBy(string statement, bool ascending);
    }
}
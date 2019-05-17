namespace QueryBuilders.Interfaces
{
    public interface IHasOrderByBuilder
    {
        void AddOrderBy(string statement, bool ascending);
    }
}
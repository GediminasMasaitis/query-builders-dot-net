namespace QueryBuilders
{
    public interface ICompositeEntry<out TBuildable>
        where TBuildable : IBuildable
    {
        bool AddParentheses { get; set; }
        TBuildable Buildable { get; }
        QueryLogicOperator? ForcedOperator { get; set; }
    }
}
using QueryBuilders.Models;

namespace QueryBuilders.Buildables
{
    public class CompositeEntry<TBuildable> : ICompositeEntry<TBuildable>
        where TBuildable : IBuildable
    {
        public CompositeEntry(TBuildable buildable)
        {
            Buildable = buildable;
        }

        public TBuildable Buildable { get; }
        public QueryLogicOperator? ForcedOperator { get; set; }
        public bool AddParentheses { get; set; }
    }
}
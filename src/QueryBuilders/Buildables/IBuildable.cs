using System.Text;

namespace QueryBuilders.Buildables
{
    public interface IBuildable
    {
        bool IsEmpty { get; }

        void BuildInto(StringBuilder builder);
    }
}
using System.Text;

namespace QueryBuilders.Buildables
{
    public interface IBuildable
    {
        void BuildInto(StringBuilder builder);
    }
}
using System.Text;

namespace QueryBuilders
{
    public interface IBuildable
    {
        void BuildInto(StringBuilder builder);
    }
}
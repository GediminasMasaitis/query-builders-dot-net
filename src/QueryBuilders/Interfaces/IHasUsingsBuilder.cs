using System.Collections.Generic;

namespace QueryBuilders.Interfaces
{
    public interface IHasUsingsBuilder
    {
        IList<string> Usings { get; }
        void AddUsing(string table);
    }
}
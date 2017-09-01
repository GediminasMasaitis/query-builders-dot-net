using System.Collections.Generic;

namespace QueryBuilders.Interfaces
{
    public interface IHasFromsBuilder
    {
        IList<string> Froms { get; }
        void AddFrom(string table);
    }
}
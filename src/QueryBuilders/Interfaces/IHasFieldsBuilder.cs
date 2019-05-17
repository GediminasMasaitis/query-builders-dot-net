namespace QueryBuilders.Interfaces
{
    public interface IHasFieldsBuilder
    {
        void AddField(string field, params object[] parameters);
    }
}
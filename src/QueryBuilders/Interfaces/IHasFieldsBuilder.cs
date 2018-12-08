namespace QueryBuilders.Interfaces
{
    interface IHasFieldsBuilder
    {
        void AddField(string field, params object[] parameters);
    }
}
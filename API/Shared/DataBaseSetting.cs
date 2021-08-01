namespace API.Shared
{
    public class DataBaseSetting : IDataBaseSetting
    {
        public string UserCollectionName { get; set; }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IDataBaseSetting
    {
        string UserCollectionName { get; set; }

        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
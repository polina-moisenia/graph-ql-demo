namespace UsageHistory.Models {

    public class DatabaseConfiguration
    {
        public string UsagesCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
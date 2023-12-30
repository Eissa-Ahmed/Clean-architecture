namespace School.Data.MongoDb
{
    public class DbSettings : IDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}

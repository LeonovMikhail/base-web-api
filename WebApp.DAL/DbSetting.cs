namespace WebApp.DAL
{
    public class DbSetting
    {   
        public string ConnectionString =>
            $"Host={DB_HOST};Port={DB_PORT};User Id={DB_USER};Password={DB_PASSWORD};Database={DB_NAME};sslmode=Prefer;Pooling=true;MinPoolSize=0;";

        public string DB_HOST { set; get; }
        public string DB_PORT { set; get; }
        public string DB_USER { set; get; }
        public string DB_PASSWORD { set; get; }
        public string DB_NAME { set; get; }
    }
}
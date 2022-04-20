using Npgsql;
namespace mainAPI.Configuration
{
    public class Database
    {
        public Server server;
        public NpgsqlDataReader reader;

        public Database(IConfiguration configuration)
        {
            this.server = new Server(configuration);
        }

        public void ExecuteSQLRequest_withParams(NpgsqlCommand cmd)
        {
            cmd.Connection = this.server.connection;
            cmd.ExecuteNonQuery();
        }

        public void ExecuteSQLRequest(string sql)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.server.connection);
            reader = cmd.ExecuteReader();
        }
        public void ExecuteSQLRequest_withoutReader(string sql)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.server.connection);
            cmd.ExecuteNonQuery();
        }
    }

    public class Server
    {
        public NpgsqlConnection connection;

        public Server(IConfiguration configuration)
        {
            string conn = string.Format(configuration.GetConnectionString("MyServer"));
            connection = new NpgsqlConnection(conn);
            connection.Open();
        }
    }
}

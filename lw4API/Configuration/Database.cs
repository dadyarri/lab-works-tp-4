using Npgsql;

namespace lw4API.Configuration
{
    public class Database
    {
        private readonly Server _server;
        public NpgsqlDataReader? Reader;

        public Database(IConfiguration configuration)
        {
            _server = new Server(configuration);
        }

        public void ExecuteSQLRequest_withParams(NpgsqlCommand cmd)
        {
            cmd.Connection = _server.Connection;
            cmd.ExecuteNonQuery();
        }

        public void ExecuteSqlRequest(string sql)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(sql, _server.Connection);
            Reader = cmd.ExecuteReader();
        }
    }

    public class Server
    {
        public readonly NpgsqlConnection Connection;

        public Server(IConfiguration configuration)
        {
            string conn = string.Format(configuration.GetConnectionString("Server"));
            Connection = new NpgsqlConnection(conn);
            Connection.Open();
        }
    }
}
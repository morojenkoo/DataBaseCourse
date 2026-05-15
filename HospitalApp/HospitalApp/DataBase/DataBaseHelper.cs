using Npgsql;

namespace HospitalApp.DataBase
{
    public class DataBaseHelper
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=Hospital;Username=postgres;Password=vostok2006";
        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}
using Npgsql;

namespace HospitalApp.Database
{
    public class DataBaseHelper
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=Hospital;Username=postgres;Password=vostok2006";
        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }
        public bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка подключения: " + ex.Message);
                return false;
            }
        }
    }
}
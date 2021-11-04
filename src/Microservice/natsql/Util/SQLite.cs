using System.Data;
using System.Data.SQLite;

namespace natsql.Util
{
    public static class SQLite
    {
        public static string ConnectionString;

        public static DataTable Query(string sql, int timeout = 120)
        {
            var dt = new DataTable();
            var conn = new SQLiteConnection(ConnectionString) { DefaultTimeout = timeout };
            using (var adapter = new SQLiteDataAdapter(sql, conn))
            {
                conn.Open();
                adapter.SelectCommand.CommandTimeout = timeout;
                adapter.Fill(dt);
                conn.Close();
            }
            return dt;
        }
    }
}

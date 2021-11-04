using System.Data;
using System.Data.SqlClient;

namespace natsql.Util
{
    /// <summary>
    /// Microsoft SQLServer
    /// </summary>
    public static class SQLServer
    {
        /// <summary>
        /// Batch Insert Records
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeout"></param>
        /// <param name="connectionString"></param>
        /// <param name="copyOptions"></param>
        public static int BatchInsert(DataTable dt, int timeout, string connectionString, SqlBulkCopyOptions copyOptions = SqlBulkCopyOptions.Default)
        {
            if (dt == null || dt.Rows.Count == 0 || string.IsNullOrEmpty(dt.TableName))
                return 0;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var bulk = new SqlBulkCopy(conn, copyOptions, null)
                {
                    DestinationTableName = dt.TableName,
                    BatchSize = dt.Rows.Count,
                    BulkCopyTimeout = timeout
                };
                bulk.WriteToServer(dt);
                conn.Close();
            }
            return dt.Rows.Count;
        }
    }
}

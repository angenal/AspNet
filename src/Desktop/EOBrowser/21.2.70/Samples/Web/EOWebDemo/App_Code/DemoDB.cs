using System;
using System.Data;
using System.Data.OleDb;
using System.Web;

namespace EO.Web.Demo
{
    /*CSTOVB*/
    public class DemoDB: IDisposable
    /*CSTOVB:<id>public class DemoDB|Public Class DemoDB</id>
    Public Class DemoDB 
        Implements IDisposable
    */
    {
        private OleDbConnection m_cn;

        public DemoDB()
        {
            string dbFileName = 
                HttpContext.Current.Request.MapPath("~/Demos/demo.mdb");
            string provider = string.Format(
                @"Provider=""Microsoft.Jet.OLEDB.4.0""; Data Source=""{0}"";", dbFileName);
            
            m_cn = new OleDbConnection(provider);
            m_cn.Open();
        }

        public OleDbDataReader ExecuteReader(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, m_cn);
            return cmd.ExecuteReader();
        }

        public object ExecuteScalar(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, m_cn);
            return cmd.ExecuteScalar();
        }

        /*CSTOVB*/
        public void Dispose()
        /*CSTOVB:<id>public void Dispose()|Public Sub Dispose()</id>
        Public Sub Dispose() Implements IDisposable.Dispose
        */
        {
            m_cn.Close();
            m_cn = null;
        }
    }
}
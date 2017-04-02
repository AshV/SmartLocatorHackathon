using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ConnectionFactory
/// </summary>
public static class ConnectionFactory
{
    static SqlConnection sqlcn;
    static SqlCommand sqlcmd;
    static SqlDataAdapter sqlda;
    static SqlDataReader sqldr;
    static DataSet ds;

    static ConnectionFactory()
    {
        sqlcn = new SqlConnection("user id=sa; password=123; database=HackathonDB;Data Source=YOGIGN");
    }

    public static DataSet GetData(string sqlQuery)
    {
        try
        {
            sqlcmd = new SqlCommand(sqlQuery, sqlcn);
            sqlda = new SqlDataAdapter(sqlcmd);
            ds = new DataSet();
            sqlda.Fill(ds);
            return ds;
        }
        catch
        {
            throw;
        }
    }

    public static void NonQuery(string sqlQuery)
    {
        sqlcmd = new SqlCommand(sqlQuery, sqlcn);
        sqlcn.Open();
        sqlcmd.ExecuteNonQuery();
        sqlcn.Close();
    }
}
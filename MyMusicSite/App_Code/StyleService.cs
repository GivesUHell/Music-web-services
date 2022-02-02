using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for StyleService
/// </summary>
public class StyleService
{
    private OleDbConnection myConnection;
	public StyleService()
	{
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
	}
    public DataSet ReturnStyles()
    {
        OleDbCommand mycmd = new OleDbCommand("spGetStyles", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
        try
        {
            DataSet ds = new DataSet();
            myConnection.Open();
            adapter.Fill(ds, "tblStyles");
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }
}
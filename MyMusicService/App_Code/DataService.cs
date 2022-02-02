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
using System.Data.OleDb;

/// <summary>
/// Summary description for DataService
/// </summary>
public class DataService
{
    protected OleDbConnection myConnection;
	public DataService()
	{
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);

    }
    public bool CheckUserValid(int codeUser)
    {
        OleDbCommand mycmd = new OleDbCommand("spCheckUser", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        try
        {
            myConnection.Open();
          if(  mycmd.ExecuteScalar()==null)
              return false;
            return true;
        }
        catch(Exception ex)
        {throw ex;}
        finally
        {
            myConnection.Close();
        }
    }
  
    

    
}

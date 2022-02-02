using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;


/// <summary>
/// Summary description for GridViewUploadServicesXD
/// </summary>
public class GridViewUploadServicesXD
{
    private OleDbConnection myConnection;

	public GridViewUploadServicesXD()
	{
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
	}
    public DataSet GetObjectSongsByListCode(int Listcode)
    {
        OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();
        try
        {
            OleDbCommand mycmd = new OleDbCommand("spGetSongInList", myConnection);
            mycmd.CommandType = CommandType.StoredProcedure;

            OleDbParameter objpar;
            objpar = mycmd.Parameters.Add("@Listcode", OleDbType.BSTR);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = Listcode;

            myDataAdapter.SelectCommand = mycmd;
            DataSet ds = new DataSet();
            myDataAdapter.Fill(ds, "tblsongs");
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

    public DateTime GetDateOfUploadByCode(int uploadcode)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetDateByCode", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@uploadcode", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = uploadcode;
        try
        {
            myConnection.Open();
            DateTime date = (DateTime)mycmd.ExecuteScalar();
            return date;
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
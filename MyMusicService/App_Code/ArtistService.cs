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
/// Summary description for ArtistService
/// </summary>
public class ArtistService
{
    protected OleDbConnection myConnection;
	public ArtistService()
	{
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
	}
    public DataSet GetArtists()
    {
        OleDbCommand mycmd = new OleDbCommand("spGetArtists", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
        try
        {
            myConnection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tblArtists");
            return ds;
        }
        catch (Exception ex)
        { throw ex; }
        finally
        {
            myConnection.Close();
        }
    }
    public string GetArtistByCode(int CodeArtist)
    {
        string Artist;
        OleDbCommand mycmd = new OleDbCommand("spGetArtistByCode", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@ArtistCode", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = CodeArtist;
        try
        {
            myConnection.Open();
            Artist=mycmd.ExecuteScalar().ToString();
            return Artist;
        }
        catch (Exception ex)
        { throw ex; }
        finally
        {
            myConnection.Close();
        }

    }
    public DataSet GetSongsByArtistName(string name)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetSongsByArtistName", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@ArtistName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = name;
        try
        {
            myConnection.Open();
            DataSet ds= new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
            adapter.Fill(ds, "tblsongs");
            return ds;
        }
        catch (Exception ex)
        { throw ex; }
        finally
        {
            myConnection.Close();
        }
    }
    public string CheckValidUser(string name)
    {
        string nameartist;
        string status;
        OleDbCommand mycmd = new OleDbCommand("spCheckNameExistAndStatus", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@ArtistName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = name;
        try
        {

            myConnection.Open();
            DataSet ds= new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
            adapter.Fill(ds, "tblArtistStatus");

            if (ds.Tables["tblArtistStatus"].Rows.Count == 0)
            {
                return "You are not an Artist";
            }
           nameartist = ds.Tables["tblArtistStatus"].Rows[0]["ArtistName"].ToString();
           status = ds.Tables["tblArtistStatus"].Rows[0]["ArtistStatus"].ToString();
            if ((nameartist != null) && (status == "לא פעיל"))
                return "You are Not Active right now, please ask for pemission to become active";
            else
                return "Allowed";
                
        }
        catch (Exception ex)
        { throw ex; }
        finally
        {
            myConnection.Close();
        }

    }

}

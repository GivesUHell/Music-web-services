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
/// Summary description for AlbumService
/// </summary>
public class AlbumService
{
    protected OleDbConnection myConnection;
	public AlbumService()
	{
		string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
	}
    public DataSet GetAlbumsByArtist(int Artist)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetAlbumsByArtist", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@ArtistCode", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = Artist;
        OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);

        try
        {
            myConnection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tblAlbums");
            return ds;
        }
        catch (Exception ex)
        { throw ex; }
        finally
        {
            myConnection.Close();
        }
    }
    public DataSet GetAlbumsByArtist(string Artist)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetAlbumsByArtistName", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@ArtistName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = Artist;
        OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);

        try
        {
            myConnection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tblAlbums");
            return ds;
        }
        catch (Exception ex)
        { throw ex; }
        finally
        {
            myConnection.Close();
        }
    }
    public string GetAlbumByCode(int CodeAlbum)
    {
        string Album;
        OleDbCommand mycmd = new OleDbCommand("spGetAlbumByCode", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@AlbumCode", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = CodeAlbum;
        try
        {
            myConnection.Open();
            Album = mycmd.ExecuteScalar().ToString();
            return Album;
        }
        catch (Exception ex)
        { throw ex; }
        finally
        {
            myConnection.Close();
        }

    }
    public DataSet GetSongsByAlbumCode(string Album)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetSongsByAlbum", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@AlbumName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = Album;
        OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
        try
        {
            myConnection.Open();
            DataSet ds= new DataSet();
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
}

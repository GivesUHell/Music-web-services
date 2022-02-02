using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SongService
/// </summary>
public class SongService
{
   private  OleDbTransaction objTrans;
    protected OleDbConnection myConnection;
	public SongService()
	{
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
	}
    public DataSet GetSongsByName(string name)
    {
        
        OleDbCommand mycmd= new OleDbCommand("spGetSongsByName",myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@SongName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = name;
        OleDbDataAdapter adapter= new OleDbDataAdapter(mycmd);
        try
        {
            myConnection.Open();
            DataSet ds= new DataSet();
            adapter.Fill(ds,"tblSongs");
            return ds;
        }
        catch (Exception ex)
        { throw ex; }
        finally
        {
            myConnection.Close();
        }
    }
    public DataSet GetSongByStyle(string Style)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetSongsByStyle", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@NameStyle", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = Style;
        OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);

        try
        {
            myConnection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tblSongs");
            return ds;
        }
        catch (Exception ex)
        { throw ex; }
        finally
        {
            myConnection.Close();
        }
    }
    public String UploadSongFamousWithAlbum(SongDetails SD)
    {
       
       
        try
        {
            myConnection.Open();
            objTrans = myConnection.BeginTransaction();
            SD.albumcode = AlbumAlreadyExistReturnsCode(SD.songalbum);
            if (SD.albumcode != null)
            {
                return "AlbumAlreadyExists";
            }
            else
                CreateNewAlbum(SD.songalbum);
            SD.albumcode = AlbumAlreadyExistReturnsCode(SD.songalbum);
            SD.artistcode = GetArtistCodeByName(SD.songartist);
            AddSong(SD);
            objTrans.Commit();
            return "Successful";
            
        }
        catch (Exception ex)
        {
            objTrans.Rollback();
            throw ex;
        }
        finally
        {
            myConnection.Close();
           
        }
    }
    public String UploadSongFamous(SongDetails SD)
    {


        try
        {
            myConnection.Open();
            objTrans = myConnection.BeginTransaction();       
            SD.artistcode = GetArtistCodeByName(SD.songartist);
            AddSong(SD);
            objTrans.Commit();
            return "Successful";
        }
        catch (Exception ex)
        {
            objTrans.Rollback();
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }

    public int AlbumAlreadyExistReturnsCode(string albumname)
    {
        OleDbCommand mycmd = new OleDbCommand("spReturnAlbumCode",myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        mycmd.Transaction = objTrans;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@AlbumName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = albumname;
        try
        {
            myConnection.Open();
            int SongCode;
            SongCode = int.Parse(mycmd.ExecuteScalar().ToString());
            return SongCode;
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
    public void CreateNewAlbum(string albumname)
    {
        OleDbCommand mycmd = new OleDbCommand("spInsertAlbum",myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        mycmd.Transaction = objTrans;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@AlbumName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = albumname;
        try
        {
            myConnection.Open();
            mycmd.ExecuteNonQuery();
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
    public int GetArtistCodeByName(string Artist)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetArtistCode", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        mycmd.Transaction = objTrans;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@ArtistName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = Artist;
        try
        {
            myConnection.Open();
            int ArtistCode=int.Parse(mycmd.ExecuteScalar().ToString());
            return ArtistCode;
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
    public void AddSong(SongDetails SD)
    {
        OleDbCommand mycmd = new OleDbCommand("spInsertSong", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        mycmd.Transaction = objTrans;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@SongName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = SD.songname;
        objpar = mycmd.Parameters.Add("@StyleCode", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = SD.stylecode;
        objpar = mycmd.Parameters.Add("@FileSong", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = SD.songfile;
        objpar = mycmd.Parameters.Add("@AlbumCode", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = SD.albumcode;
        objpar = mycmd.Parameters.Add("@ArtistCode", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = SD.artistcode;
        try
        {
            myConnection.Open();
            mycmd.ExecuteNonQuery();
            
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
    public DataSet GetAllFamousSongs()
    {
        OleDbCommand mycmd = new OleDbCommand("spGetAllFamousSongs",myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
        try
        {
            myConnection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tblAllFamousSongs");
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

    public DataSet GetFamousSongByCode(int SongCode)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetFamousSongByCode", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@SongCode", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = SongCode;
        OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
        try
        {
            myConnection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tblFamousSong");
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
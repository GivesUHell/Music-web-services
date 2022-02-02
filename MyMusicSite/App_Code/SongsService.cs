using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.IO;

/// <summary>
/// Summary description for SongsBag
/// </summary>
public class SongsService
{
    private OleDbTransaction objTrans;
    private OleDbConnection myConnection;
    ArrayList mSongs;
    ArrayList mSongsSearch;

	public SongsService()
	{
        mSongs = new ArrayList();
        mSongsSearch = new ArrayList();
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
	}
    public void ShowSongs(SongInList inSong)
    {
       
        this.mSongs.Add(inSong);
        //int index = SearchProduct(inSong.ProdID);
        //if (index == -1)
        //    this.mSongs.Add(inSong);
        //else
        //{
        //    ((ProductInBag)this.mProducts[index]).Quantity++;
        //}

    }
    public void SongsSearch(SongInList inSong)
    {
        this.mSongsSearch.Add(inSong);
    }
    public void DeleteSongAndFile(int songcode)
    {
        string filename;
        try
        {
            myConnection.Open();
            objTrans = myConnection.BeginTransaction();
            filename = this.GetFileName(songcode);
            this.DeleteSong(songcode);
            this.DeleteFileOfSong(filename);
            objTrans.Commit();
        }
        catch(Exception ex)
        {
            objTrans.Rollback();
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }
    public void DeleteFileOfSong(string filename)
    {
        try
        {
            FileInfo fi = new FileInfo(filename + ".mp3");
            fi.Delete();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public void DeleteSong(int songcode)
    {
        OleDbCommand mycmd = new OleDbCommand("spDeleteSong", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        mycmd.Transaction = objTrans;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@SongCode", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = songcode;

        try
        {
           
            mycmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
       
    }
    public string GetFileName(int songcode)
    {
        string filename;
        OleDbCommand mycmd = new OleDbCommand("spGetFileName", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@SongCode", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = songcode;
        try
        {
            
            filename = mycmd.ExecuteScalar().ToString();
            return filename;
        }
        catch (Exception ex)
        {
            throw ex;
        }
      
    }
    //public string GetSongsByArtistsByName(string name)
    //{
    //    DataSet ds = new DataSet();
    //    localhostWebServiceArtists.WebServiceArtists sa= new localhostWebServiceArtists.WebServiceArtists()
    //    ds= sa.GetSongsByArtistName(name);
    //    return ds;
    //}
    public string GetArtistByCode(int artistcode)
    {
     
       string Artist;
       localhostWebServiceArtists.WebServiceArtists service = new localhostWebServiceArtists.WebServiceArtists();
       Artist= service.GetArtistByCode(artistcode);
       return Artist;

    }

    public string GetAlbumByCode(int albumcode)
    {
        string Album;
        localhostWebServiceAlbums.WebServiceAlbums As = new localhostWebServiceAlbums.WebServiceAlbums();
        Album = As.GetAlbumByCode(albumcode);
        return Album;
    }
    public DataSet GetSongsByName(string name)
    {

        DataSet ds;
        localhostWebServiceSongs.WebServiceSongs ss= new localhostWebServiceSongs.WebServiceSongs();
        ds=ss.GetSongByName(name);
        return ds;

    }
    public DataSet SearchByName(string name)
    {   
        OleDbCommand mycmd = new OleDbCommand("spSelectSongByName", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@SongName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = name;
        try
        {
            myConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tblSongs");         
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
    


    public DataSet SearchByArtist(string Artist)
    {
       DataSet ds = new DataSet();
       localhostWebServiceArtists.WebServiceArtists sa = new localhostWebServiceArtists.WebServiceArtists();
        ds= sa.GetSongsByArtistName(Artist);
        return ds;
    }

    public DataSet GetSongByStyle(string Style)
    {
        DataSet ds = new DataSet();
        localhostWebServiceSongs.WebServiceSongs ss = new localhostWebServiceSongs.WebServiceSongs();
        ds= ss.GetSongByStyle(Style);
        return ds;
    }

    public DataSet SearchByStyle(string Style)
    {
         OleDbCommand mycmd = new OleDbCommand("spSelectSongByStyle", myConnection);
         mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@NameStyle", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = Style;
        try
        {
            myConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tblsongs");
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
    public DataSet SearchByAlbum(string Album)
    {
        DataSet ds = new DataSet();
        localhostWebServiceAlbums.WebServiceAlbums aa = new localhostWebServiceAlbums.WebServiceAlbums();
        ds=aa.GetSongsByAlbumName(Album);
        return ds;
    }
    public void UploadRegularSong(SongDetails Songdetails,int CodeUser)//uploadsong
      
    {
        myConnection.Open();
        int songCode;
        objTrans = myConnection.BeginTransaction();
        this.UploadToSongstbl(Songdetails);
        songCode=this.GetLastSongCode();
        this.UploadToUploadtbl(songCode,CodeUser);
     try
        {
            objTrans.Commit();

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
    public void UploadToSongstbl(SongDetails Songdetails)
    {
        OleDbCommand mycmd = new OleDbCommand("spInsertSongRegular", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        mycmd.Transaction = objTrans;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@SongName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = Songdetails.songname;
        objpar = mycmd.Parameters.Add("@StyleCode", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = Songdetails.stylecode;
        objpar = mycmd.Parameters.Add("@FileSong", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = Songdetails.songfile;
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
    public int GetLastSongCode()
    {
        int songcode;
        OleDbCommand mycmd = new OleDbCommand("spGetLastSongCode", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        mycmd.Transaction = objTrans;
        try
        {
            myConnection.Open();
           songcode=Convert.ToInt32(mycmd.ExecuteScalar());
           return songcode;
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
    public void UploadToUploadtbl(int songcode, int Codeuser)
    {
        OleDbCommand mycmd = new OleDbCommand("spUploadToUploadtbl", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        mycmd.Transaction = objTrans;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@CodeUser", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = Codeuser;
        objpar = mycmd.Parameters.Add("@DateOfUpload", OleDbType.Date);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = DateTime.Now;
        objpar = mycmd.Parameters.Add("@SongCode", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = songcode;
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

    public ArrayList Songs
    {
        get
        {
            return mSongs;
        }
    }
    public ArrayList SongsOfSearch
    {
    get
    {
        return mSongsSearch;
    }

    }
    //public string UploadSongFamous(SongDetails SD)
    //{
    //    int CodeAlbum;
    //    try
    //    {
    //        myConnection.Open();
    //        objTrans = myConnection.BeginTransaction();
    //        localhostWebServiceSongs.WebServiceSongs WebSongs = new localhostWebServiceSongs.WebServiceSongs();
    //        WebSongs.UploadSongWithAlbum(SD);
    //        //CodeAlbum = WebAlbums.GetLastAlbumCode();

    //        //this.DeleteSong(songcode);
    //        //this.DeleteFileOfSong(filename);
    //        objTrans.Commit();
    //    }
    //    catch (Exception ex)
    //    {
    //        objTrans.Rollback();
    //        throw ex;
    //    }
    //    finally
    //    {
    //        myConnection.Close();
    //    }
    //}
    public string UploadSongFamousWithAlbum(SongDetails SD)
    {
        localhostWebServiceSongs.WebServiceSongs WebSongs = new localhostWebServiceSongs.WebServiceSongs();
        localhostWebServiceSongs.SongDetails SD1 = new localhostWebServiceSongs.SongDetails();
        SD1.albumcode = SD.albumcode;
        SD1.artistcode = SD.artistcode;
        SD1.songalbum = SD.songalbum;
        SD1.songartist = SD.songartist;
        SD1.songfile = SD.songfile;
        SD1.songname = SD.songname;
        SD1.songstyle = SD.songstyle;
        SD1.stylecode = SD.stylecode;
        string answer=WebSongs.UploadSongFamousWithAlbum(SD1);
        return answer;
    }
    public string UploadSongFamous(SongDetails SD)
    {
        localhostWebServiceSongs.WebServiceSongs WebSongs = new localhostWebServiceSongs.WebServiceSongs();
        localhostWebServiceSongs.SongDetails SD1 = new localhostWebServiceSongs.SongDetails();
        SD1.albumcode = SD.albumcode;
        SD1.artistcode = SD.artistcode;
        SD1.songalbum = SD.songalbum;
        SD1.songartist = SD.songartist;
        SD1.songfile = SD.songfile;
        SD1.songname = SD.songname;
        SD1.songstyle = SD.songstyle;
        SD1.stylecode = SD.stylecode;
        
        string answer = WebSongs.UploadSongFamous(SD1);
        return answer;
    }

    public DataSet GetSongsUploaded()
    {
        OleDbCommand mycmd = new OleDbCommand("spGetAllSongsUploaded", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
        try
        {
            myConnection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tblSongsUploaded");
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

    public DataSet GetRegularSongByCode(int SongCode)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetSongByMusicUploadCode", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@CodeMusicUpload", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = SongCode;
        OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
        try
        {
            myConnection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tblSongUploaded");
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
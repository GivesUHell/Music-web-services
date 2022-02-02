using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebServiceSongs
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceSongs : System.Web.Services.WebService {

    public WebServiceSongs () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public DataSet GetSongByName(string name)
    {
        SongService ss = new SongService();
        DataSet ds = new DataSet();
        ds=ss.GetSongsByName(name);
        return ds;
    }
    [WebMethod]
    public DataSet GetSongByStyle(string Style)
    {
        SongService ss = new SongService();
        DataSet ds = new DataSet();
        ds= ss.GetSongByStyle(Style);
        return ds;
    }
    [WebMethod]
    public string UploadSongFamousWithAlbum(SongDetails SD)
    {
        string answer;
        SongService ss= new SongService();
        answer = ss.UploadSongFamousWithAlbum(SD);
        return answer;
    }
    [WebMethod]
    public string UploadSongFamous(SongDetails SD)
    {
        string answer;
        SongService ss = new SongService();
        answer = ss.UploadSongFamous(SD);
        return answer;
    }
    [WebMethod]
    public DataSet GetAllFamousSongs()
    {
        SongService Songserv = new SongService();
        DataSet ds = new DataSet();
        ds = Songserv.GetAllFamousSongs();
        return ds;
    }
    [WebMethod]
    public DataSet GetFamousSongByCode(int CodeSong)
    {
        SongService Songserv = new SongService();
        DataSet ds = new DataSet();
        ds = Songserv.GetFamousSongByCode(CodeSong);
        return ds;
    }
}

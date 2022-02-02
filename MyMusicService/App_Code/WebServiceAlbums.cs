using System;
using System.Data;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
/// Summary description for WebServiceAlbums
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceAlbums : System.Web.Services.WebService {

    public WebServiceAlbums () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public DataSet GetAlbumByArtist1(int Artist)//מקבל זמר לפי קוד
    {
        DataSet ds = new DataSet();
        AlbumService As = new AlbumService();
        ds = As.GetAlbumsByArtist(Artist);
        return ds;
    }
    [WebMethod]
    public DataSet GetAlbumByArtist(string Artist)//מקבל זמר לפי שם
    {
        DataSet ds = new DataSet();
        AlbumService As = new AlbumService();
        ds = As.GetAlbumsByArtist(Artist);
        return ds;
    }
    [WebMethod]
    public string GetAlbumByCode(int codealbum)
    {
        string Album;
        AlbumService As = new AlbumService();
        Album = As.GetAlbumByCode(codealbum);
        return Album;
    }
    [WebMethod]
    public DataSet GetSongsByAlbumName(string Album)
    {
        DataSet ds= new DataSet();
        AlbumService As = new AlbumService();
        ds = As.GetSongsByAlbumCode(Album);
            return ds;
    }
}


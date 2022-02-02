using System;
using System.Data;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
/// Summary description for WebServiceArtists
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceArtists : System.Web.Services.WebService {

    public WebServiceArtists () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public DataSet GetArtists()
    {
        DataSet ds = new DataSet();
        ArtistService As = new ArtistService();
        ds = As.GetArtists();
        return ds;
    }
    [WebMethod]
    public string GetArtistByCode(int codeartist)
    {
        string Artist;
        ArtistService As = new ArtistService();
        Artist = As.GetArtistByCode(codeartist);
        return Artist;
    }
    [WebMethod]
    public DataSet GetSongsByArtistName(string name)
    {
        DataSet ds = new DataSet();
        ArtistService ass = new ArtistService();
        ds=ass.GetSongsByArtistName(name);
        return ds;
    }
    [WebMethod]
    public string CheckValidArtist(string name)
    {
        string answer;
        ArtistService As = new ArtistService();
        answer = As.CheckValidUser(name);
            return answer;
      
    }
}


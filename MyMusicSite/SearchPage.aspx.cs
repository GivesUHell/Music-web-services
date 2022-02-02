using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class SearchPage : System.Web.UI.Page
{
    SongsService mSongsList = new SongsService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            Populate_GridViewSearch();
    }
    private Control FindControlRecursive(Control root, string id)
    {
        if (root.ID == id) return root;
        foreach (Control c in root.Controls)
        {
            Control t = FindControlRecursive(c, id);
            if (t != null) return t;
        }
        return null;
    }

    public void Populate_GridViewSearch()
    {      
        string name = Session["name"].ToString();
        SongsService ss = new SongsService();
         
        switch(int.Parse(Session["value"].ToString()))
        {
            case 0:
              
                DataSet ds = ss.SearchByName(name);
                DataSet ds1 = ss.GetSongsByName(name);
                Populate_GridViewSearch2(ds, ds1);
                break;
            case 1:
              
                DataSet ds2 = ss.SearchByArtist(name);
                Populate_GridViewSearch2(ds2);
                break;
            case 2:
               
                DataSet ds3 = ss.SearchByAlbum(name);
                Populate_GridViewSearch2(ds3);
                break;
            case 3:
              
                DataSet ds4 = ss.SearchByStyle(name);
                DataSet ds5 = ss.GetSongByStyle(name);
                Populate_GridViewSearch2(ds4,ds5);
                break;

        }       
        //GridViewSongs.DataSource = ds;
        //GridViewSongs.DataBind();
    }
  
    public void Populate_GridViewSearch2(DataSet ds)
    {
        if (ds != null)
        {
            SongsService ss = new SongsService();
            for (int i = 0; i < ds.Tables["tblsongs"].Rows.Count; i++)
            {
                int SongCode = int.Parse(ds.Tables["tblsongs"].Rows[i]["SongCode"].ToString());
                string SongName = ds.Tables["tblsongs"].Rows[i]["SongName"].ToString();
                string NameStyle = ds.Tables["tblsongs"].Rows[i]["NameStyle"].ToString();
                string SongArtist = ss.GetArtistByCode(int.Parse(ds.Tables["tblsongs"].Rows[i]["ArtistCode"].ToString()));
                string SongAlbum = ss.GetAlbumByCode(int.Parse(ds.Tables["tblsongs"].Rows[i]["AlbumCode"].ToString()));
                string FileName = ds.Tables["tblsongs"].Rows[i]["FileSong"].ToString();

                SongInList newS = new SongInList(SongCode, SongName, NameStyle, SongArtist, SongAlbum, FileName);

                mSongsList.SongsSearch(newS);

            }
            Page.Session["mySongsSearch"] = mSongsList;
            Populate_GridViewSearch2();
        }
        else
        {
            MySong.Text = "No Song Found!";
            MySong.ForeColor = System.Drawing.Color.Red;
            MySong.Visible = true;

        }
    }
    public void Populate_GridViewSearch2(DataSet ds,DataSet ds1)
    {
        SongsService ss = new SongsService();
        for (int i = 0; i < ds1.Tables["tblsongs"].Rows.Count; i++)
        {
            int SongCode = int.Parse(ds1.Tables["tblsongs"].Rows[i]["SongCode"].ToString());
            string SongName = ds1.Tables["tblsongs"].Rows[i]["SongName"].ToString();
            string NameStyle = ds1.Tables["tblsongs"].Rows[i]["NameStyle"].ToString();
            string SongArtist = ss.GetArtistByCode(int.Parse(ds1.Tables["tblsongs"].Rows[i]["ArtistCode"].ToString()));
            string SongAlbum = ss.GetAlbumByCode(int.Parse(ds1.Tables["tblsongs"].Rows[i]["AlbumCode"].ToString()));
            string FileName = ds1.Tables["tblsongs"].Rows[i]["FileSong"].ToString();

            SongInList newS = new SongInList(SongCode, SongName, NameStyle, SongArtist, SongAlbum,FileName);

            mSongsList.SongsSearch(newS);

        }
        for (int i = 0; i < ds.Tables["tblsongs"].Rows.Count; i++)
        {
            int SongCode = int.Parse(ds.Tables["tblsongs"].Rows[i]["SongCode"].ToString());
            string SongName = ds.Tables["tblsongs"].Rows[i]["SongName"].ToString();
            string NameStyle = ds.Tables["tblsongs"].Rows[i]["NameStyle"].ToString();
            string SongArtist = ss.GetArtistByCode(int.Parse(ds.Tables["tblsongs"].Rows[i]["ArtistCode"].ToString()));
            string SongAlbum = ss.GetAlbumByCode(int.Parse(ds.Tables["tblsongs"].Rows[i]["AlbumCode"].ToString()));
            string FileName = ds.Tables["tblsongs"].Rows[i]["FileSong"].ToString();

            SongInList newS = new SongInList(SongCode, SongName, NameStyle, SongArtist, SongAlbum, FileName);

            mSongsList.SongsSearch(newS);

        }
        Page.Session["mySongsSearch"] = mSongsList;
        Populate_GridViewSearch2();
        
    }
    public void Populate_GridViewSearch2()
    {
        if (((SongsService)(Session["mySongsSearch"])).SongsOfSearch != null)
        {
            GridViewSongs.DataSource = ((SongsService)(Session["mySongsSearch"])).SongsOfSearch;
            GridViewSongs.DataBind();
            GridViewSongs.Visible = true;
        }
        else
        {
            MySong.Text = "No Song Found!";
            MySong.ForeColor = System.Drawing.Color.Red;
            MySong.Visible = true;
        }
    }
    
    protected void GridViewSongs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "PlayMe")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewSongs.Rows[index];
            string filename = GridViewSongs.DataKeys[index].Value.ToString();
            MySong.Text = "MusicList/" + filename + ".mp3";
        }
    }
}

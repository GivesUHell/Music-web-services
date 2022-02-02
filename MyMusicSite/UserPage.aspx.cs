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
using System.IO;

public partial class UserPage : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserDetails"] == null)
                Response.Redirect("Login.aspx");
        }
        UserService us1 = new UserService();
        Session["UserDetails"] = us1.GetAllUser("Asax");
        UserDetails ud = new UserDetails();
        UserService us = new UserService();
        ud = (UserDetails)Session["UserDetails"];
        LabelUserName.Text = ud.username;
        LabelOther.Text = ud.other;
        if (!Page.IsPostBack)
        {
            Populate_ListBoxMyLists();
            Populate_ListBoxUploads();
        }


    }
    protected void Populate_ListBoxMyLists()
    {
        DataSet ds = new DataSet();
        UserService us = new UserService();
        ds = us.GetLists(((UserDetails)Session["UserDetails"]).codeuser);
        ListBoxMyList.DataSource = ds;
        ListBoxMyList.DataTextField = "ListName";
        ListBoxMyList.DataValueField = "ListCode";
        ListBoxMyList.DataBind();

    }

    protected void ListBoxMyList_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserService us = new UserService();
        DataSet ds = new DataSet();
        ds = us.GetSongsByList(int.Parse(ListBoxMyList.SelectedItem.Value));
        ListBoxMusicInList.DataSource = ds;
        ListBoxMusicInList.DataTextField = "SongName";
        ListBoxMusicInList.DataValueField = "FileSong";
        ListBoxMusicInList.DataBind();
        ListBoxMusicInList.Visible = true;

    }
    public void Populate_ListBoxUploads()
    {
        UserService us = new UserService();
        DataSet ds= new DataSet();
       ds=us.GetSongsUploaded(((UserDetails)Session["UserDetails"]).codeuser);
       ListBoxUploads.DataSource = ds;
       ListBoxUploads.DataTextField = "SongName";
       ListBoxUploads.DataValueField = "SongCode";
       ListBoxUploads.DataBind();

    }
    protected void ListBoxMusicInList_SelectedIndexChanged(object sender, EventArgs e)
    {SongsService SongServ = new SongsService();
        MySong.Text = "MusicList/" + ListBoxMusicInList.SelectedItem.Value + ".mp3";
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateNewSong.aspx");
    }
    protected void ListBoxUploads_SelectedIndexChanged(object sender, EventArgs e)
    {
        SongsService SongServ = new SongsService();
        string filename=SongServ.GetFileName(int.Parse(ListBoxUploads.SelectedValue));
        MySong.Text = "MusicList/" + filename + ".mp3";
    }
    protected void LinkButtonDelete_Click(object sender, EventArgs e)
    {
        
        SongsService SongServ = new SongsService();
      LinkButtonDelete.Attributes["onclick"]= "javascript:return confirm('Are you sure you want to delete Song #" +
                       ListBoxUploads.SelectedItem.Text + "? It Will be deleted Completely' )";
        SongServ.DeleteSongAndFile(int.Parse(ListBoxUploads.SelectedValue));

    }
}
    

using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListsPageForUser : System.Web.UI.Page
{
    SongsService mSongsList = new SongsService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            populate_GridViewUploaded();
            Populate_GridViewFamous();
            GridViewSongs.Visible = false;
            GridViewFamous.Visible = false;
            GridViewUploaded.Visible = false;
        }
        UserService us1 = new UserService();
        Session["UserDetails"] = us1.GetAllUser("Asax");
    }
    protected void ObjectDataSourceLists_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        int codeUser = ((UserDetails)Session["UserDetails"]).codeuser;
        e.InputParameters["CodeUser"] = codeUser;
    }
   public void populate_GridViewUploaded()
   {
       SongsService ss = new SongsService();
       DataSet ds = new DataSet();
       ds=ss.GetSongsUploaded();
       GridViewUploaded.DataSource = ds;
       GridViewUploaded.DataBind();
   }
   public void Populate_GridViewFamous()
   {
       localhostWebServiceSongs.WebServiceSongs WebSongs = new localhostWebServiceSongs.WebServiceSongs();
       DataSet ds = new DataSet();
       ds=WebSongs.GetAllFamousSongs();
       GridViewFamous.DataSource = ds;
       GridViewFamous.DataBind();
   }
    protected void GridViewLists_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string SongName;
        DateTime DateofUpload;
        string SongUploader;
        string NameStyle;
        string SongArtist;
        string SongAlbum;
        
        if (e.CommandName == "ShowDetails")
        {
            int codeUser = ((UserDetails)Session["UserDetails"]).codeuser;

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewLists.Rows[index];
            int codelist = int.Parse(GridViewLists.DataKeys[index].Value.ToString());
            Session["ListCodeSelected"] = codelist;
            ListsService ls = new ListsService();

            //DataSet ds = ls.GetAllLists(codeUser);

            //int codelist=-1;
            //string ListName = row.Cells[0].Text;

            //for (int i = 0; i < ds.Tables["tblLists"].Rows.Count; i++)
            //{
            //    DataRow dr = ds.Tables["tblLists"].Rows[i];
            //    if (dr["ListName"].ToString() == ListName)
            //    {
            //        codelist = int.Parse(dr["ListCode"].ToString());
            //        i = ds.Tables["tblLists"].Rows.Count;
            //        i++;
            //    }
            //}

            //if (codelist != -1)
            //{
            DataSet ds3 = new DataSet();
            ds3= ls.GetSongsInList(codelist);
            for (int i = 0; i < ds3.Tables["tblSongsInList"].Rows.Count; i++)
            {
                int SongsInListCode = int.Parse(ds3.Tables["tblSongsInList"].Rows[i]["SongsInListCode"].ToString());
                int PlaceInList = int.Parse(ds3.Tables["tblSongsInList"].Rows[i]["PlaceInList"].ToString());

                if ((ds3.Tables["tblSongsInList"].Rows[i]["FamousSongCode"].ToString()) != "")//כלומר השיר מפורסם
                {//נצטרך ללכת לוובסרביס
                    localhostWebServiceSongs.WebServiceSongs WebSongs = new localhostWebServiceSongs.WebServiceSongs();
                    DataSet ds4 = new DataSet();
                    ds4 = WebSongs.GetFamousSongByCode(int.Parse(ds3.Tables["tblSongsInList"].Rows[i]["FamousSongCode"].ToString()));
                    SongName = ds4.Tables["tblFamousSong"].Rows[0]["SongName"].ToString();
                    SongUploader = "";
                    DateofUpload =new DateTime();
                    NameStyle = ds4.Tables["tblFamousSong"].Rows[0]["NameStyle"].ToString();
                    SongArtist = ds4.Tables["tblFamousSong"].Rows[0]["ArtistName"].ToString();
                    SongAlbum = ds4.Tables["tblFamousSong"].Rows[0]["AlbumName"].ToString();

                }
                else//שיר לא מפורסם
                {//נקבל את השיר מהטבלה
                    SongsService SongServ = new SongsService();
                    DataSet ds5 = new DataSet();
                    ds5=SongServ.GetRegularSongByCode(int.Parse(ds3.Tables["tblSongsInList"].Rows[i]["CodeMusicUpload"].ToString()));
                    SongName = ds5.Tables["tblSongUploaded"].Rows[0]["SongName"].ToString();
                    DateofUpload =Convert.ToDateTime(ds5.Tables["tblSongUploaded"].Rows[0]["DateOfUpload"].ToString());
                    NameStyle = ds5.Tables["tblSongUploaded"].Rows[0]["NameStyle"].ToString();
                    SongUploader = ds5.Tables["tblSongUploaded"].Rows[0]["UserName"].ToString();
                    SongArtist = "";
                    SongAlbum = "";

                }
                SongInList newS = new SongInList(SongsInListCode, PlaceInList, SongName, DateofUpload, NameStyle, SongArtist, SongAlbum,SongUploader);
                mSongsList.ShowSongs(newS);
            }
            //GridViewUploadServicesXD gv = new GridViewUploadServicesXD();
            //DataSet ds1 = gv.GetObjectSongsByListCode(codelist);
            //SongsService ss = new SongsService();
            //for (int i = 0; i < ds1.Tables["tblsongs"].Rows.Count; i++)
            //{
            //    //int SongCode = int.Parse(ds1.Tables["tblsongs"].Rows[i]["SongCode"].ToString());
            //    int SongsInListCode = int.Parse(ds1.Tables["tblsongs"].Rows[i]["SongsInListCode"].ToString());
            //    string PlaceInList = ds1.Tables["tblsongs"].Rows[i]["PlaceInList"].ToString();
            //    string SongName = ds1.Tables["tblsongs"].Rows[i]["SongName"].ToString();
            //    DateTime DateofUpload = gv.GetDateOfUploadByCode(int.Parse(ds1.Tables["tblsongs"].Rows[i]["CodeMusicUpload"].ToString()));
            //    string NameStyle = ds1.Tables["tblsongs"].Rows[i]["NameStyle"].ToString();
            //    string SongArtist= ss.GetArtistByCode(int.Parse(ds1.Tables["tblsongs"].Rows[i]["ArtistCode"].ToString()));
            //    string SongAlbum = ss.GetAlbumByCode(int.Parse(ds1.Tables["tblsongs"].Rows[i]["AlbumCode"].ToString()));

            //    SongInList newS = new SongInList(SongsInListCode, int.Parse(PlaceInList), SongName, DateofUpload, NameStyle, SongArtist, SongAlbum);

            //    mSongsList.ShowSongs(newS);

            //}
            Page.Session["mySongs"] = mSongsList;
            Populate_GridViewSongs();
            

            //string SongDateOfUpload = row.Cells[2].Text;
            //string SongArtist = row.Cells[3].Text;
            //string SongAlbum = row.Cells[4].Text;
            //string Style = row.Cells[5].Text;
            //mShoppingBag.AddProduct(newp);

            //int index = Convert.ToInt32(e.CommandArgument);
            //GridViewRow row = GridViewProducts.Rows[index];

            //string productID = row.Cells[0].Text;
            //string productName = row.Cells[1].Text;
            //string price = row.Cells[2].Text;
            //ProductInBag newp = new ProductInBag(int.Parse(productID), productName, decimal.Parse(price), 1);
            //mShoppingBag.AddProduct(newp);

            //ButtonBuy.Visible = true;
            //Page.Session["myShoppingBag"] = mShoppingBag;
            //Populate_GridViewShoppingBag();

            //}
            //else
            //{
            //    LabelError.Text = "Sumthin went wrong";
            //    LabelError.Visible = true;
            //}
        }
    }
    public void Populate_GridViewSongs()
    {
        GridViewSongs.DataSource = ((SongsService)(Session["mySongs"])).Songs;
        GridViewSongs.DataBind();
        GridViewSongs.Visible = true;
        GridViewFamous.Visible = true;
        GridViewUploaded.Visible = true;

    }
    protected void GridViewSongs_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewSongs.EditIndex = e.NewEditIndex;
        GridViewSongs.Visible = true;
        Populate_GridViewSongs();
    }
    protected void GridViewSongs_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewSongs.EditIndex = -1;
        Populate_GridViewSongs();
    }
    protected void GridViewSongs_DataBound(object sender, GridViewRowEventArgs e)
    {
        {
            //First, make sure we're dealing a data Row
            if (e.Row.RowType != DataControlRowType.Header &&
                e.Row.RowType != DataControlRowType.Footer &&
                e.Row.RowType != DataControlRowType.Pager &&
                e.Row.RowState != DataControlRowState.Edit)
            {
                ////Now, reference the LinkButton control that the Delete ButtonColemn has been rendered to

                LinkButton deleteButton = (LinkButton)e.Row.Cells[8].FindControl("deleteButton");
                //    // we can now add the onclick event handler
                deleteButton.Attributes["onclick"] = "javascript:return confirm('Are you sure you want to delete Song #" +
                       DataBinder.Eval(e.Row.DataItem, "songname") + "?' )";
            }
        }
    }
    protected void GridViewLists_DataBound(object sender, GridViewRowEventArgs e)
    {
        {
            //First, make sure we're dealing a data Row
            if (e.Row.RowType != DataControlRowType.Header &&
                e.Row.RowType != DataControlRowType.Footer &&
                e.Row.RowType != DataControlRowType.Pager &&
                e.Row.RowState != DataControlRowState.Edit)
            {
                ////Now, reference the LinkButton control that the Delete ButtonColemn has been rendered to

                LinkButton deleteButton = (LinkButton)e.Row.Cells[3].FindControl("deleteButton1");
                 // we can now add the onclick event handler
                deleteButton.Attributes["onclick"] = "javascript:return confirm('Are you sure you want to delete List #" +
                       DataBinder.Eval(e.Row.DataItem, "ListName") + "? Deleting the List will also delete all of its songs.' )";
            }
        }
    }

    protected void GridViewSongs_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        int songinlistcode = int.Parse(GridViewSongs.DataKeys[e.RowIndex].Value.ToString());
        ListsService ls = new ListsService();
        ls.DeleteSongFromList(songinlistcode);
        
    }
    protected void GridViewLists_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ListsService ls = new ListsService();
        int codelist = int.Parse(GridViewLists.DataKeys[e.RowIndex].Value.ToString());
        GridViewUploadServicesXD gv = new GridViewUploadServicesXD();
        DataSet ds1 = ls.GetSongsInList(codelist);
        for (int i = 0; i < ds1.Tables["tblSongsInList"].Rows.Count; i++)
        {
            int SongsInListCode = int.Parse(ds1.Tables["tblSongsInList"].Rows[i]["SongsInListCode"].ToString());
            ls.DeleteSongFromList(SongsInListCode);
        }
        
        ls.DeleteList(codelist);
    }
    protected void GridViewSongs_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GridViewLists_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridViewFamous_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "AddSong")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewFamous.Rows[index];
            int CodeSong = int.Parse(GridViewFamous.DataKeys[index].Value.ToString());
            int ListCode = Convert.ToInt32(Session["ListCodeSelected"]);
            ListsService ListServ = new ListsService();
            ListServ.AddSongFamous(CodeSong, ListCode);
            Populate_GridViewSongs();
          
        }
    }
    protected void GridViewUploaded_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddSongRegular")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewUploaded.Rows[index];          
            int CodeMusicUpload = int.Parse(GridViewUploaded.DataKeys[index].Value.ToString());
            int ListCode = Convert.ToInt32(Session["ListCodeSelected"]);
            ListsService ListServ = new ListsService();
            ListServ.AddSong(CodeMusicUpload,ListCode);
           
        }
    }
   
}
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class RecognizedArtistsPage : System.Web.UI.Page
{
    string answer;//Upload status or user allowed
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserDetails"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }


            UserService userService = new UserService();
            answer = userService.CheckValidArtist(((UserDetails)Session["UserDetails"]).username);
            if (answer == "Allowed")
            {
                Populate_DropDownListStyles();
                Populate_DropDownListAlbums();
            }
            else
            {

                Panel1.Visible = false;
                LabelCheck1.Text = answer + " You Will be redirected";
                LabelCheck1.Visible = true;
                string HomePageUrl = "HomePage.aspx";
                Page.Header.Controls.Add(new LiteralControl(string.Format(@" <META http-equiv='REFRESH' content=3;url={0}> ", HomePageUrl)));

            }
        }
    }
   
    protected void Populate_DropDownListStyles()
    {
        DataSet ds = new DataSet();
        StyleService ss = new StyleService();
        ds = ss.ReturnStyles();
        DropDownListStyles0.DataSource = ds.Tables["tblStyles"];
        DropDownListStyles0.DataTextField = "NameStyle";
        DropDownListStyles0.DataValueField = "StyleCode";
        DropDownListStyles0.DataBind();
    }
    protected void Populate_DropDownListAlbums()
    {
        DataSet ds = new DataSet();
        localhostWebServiceAlbums.WebServiceAlbums service = new localhostWebServiceAlbums.WebServiceAlbums();
        ds = service.GetAlbumByArtist(((UserDetails)Session["UserDetails"]).username);
        DropDownListAlbumsByArtist.DataSource = ds.Tables["tblAlbums"];
        DropDownListAlbumsByArtist.DataTextField = "AlbumName";
        DropDownListAlbumsByArtist.DataValueField = "AlbumCode";
        DropDownListAlbumsByArtist.DataBind();          
    }
    protected void UploadBtn_Click(object sender, EventArgs e)
    {
        // Before attempting to save the file, verify 
        // that the FileUpload control contains a file. 
        if (FileUpload1.HasFile)//Check if file exists
        {

            if (Path.GetExtension(FileUpload1.PostedFile.FileName).Equals(".mp3", StringComparison.OrdinalIgnoreCase))//Check File type
            {

                SaveFile(FileUpload1.PostedFile);
            }

            else
            {
                this.LabelMessage.Text = "Only mp3 files allowed";
                this.LabelMessage.Visible = true;
            }
    
        }
    
    
        else
        {
            this.LabelMessage.Text = "No File Specified"; ;
            this.LabelMessage.Visible = true;
        }
    }

    protected void LinkButtonNewAlbum_Click(object sender, EventArgs e)
    {
        if (TextBoxNewAlbum.Visible == false)
        {
            TextBoxNewAlbum.Visible = true;
            DropDownListAlbumsByArtist.Visible = false;
        }
        if (TextBoxNewAlbum.Visible == true)
            TextBoxNewAlbum.Visible = false;
        DropDownListAlbumsByArtist.Visible = true;
    }
    public string StartUploadRoutine(string songfile)
    {
        if (TextBoxNewAlbum.Visible == true)//Upload+NewAlbum
        {
            SongDetails SD = new SongDetails();
            SD.songname = TextBoxSongName0.Text;
            SD.stylecode =int.Parse(DropDownListStyles0.SelectedItem.Value);
            SD.songfile = songfile;
            SD.songalbum=TextBoxNewAlbum.Text;
            SD.songartist = ((UserDetails)Session["UserDetails"]).username;
            SongsService SS = new SongsService();
            string blabla = SS.UploadSongFamousWithAlbum(SD);
          return blabla;
        }
        else //upload With existing album
        {
            SongDetails SD = new SongDetails();
            SD.songname = TextBoxSongName0.Text;
            SD.stylecode = int.Parse(DropDownListStyles0.SelectedItem.Value);
            SD.songfile = songfile;
            SD.albumcode = int.Parse(DropDownListAlbumsByArtist.SelectedItem.Value);
            SD.songartist = ((UserDetails)Session["UserDetails"]).username;
            SongsService SS = new SongsService();
            string blabla = SS.UploadSongFamous(SD);
            return blabla;
        }
    }
    public void SaveFile(HttpPostedFile file)
    {
        
        // Specify the path to save the uploaded file to. 
        string savePath = "F:/My Project Music/MyMusicSite/MusicList/";


        // Get the name of the file to upload. 
        string fileName = FileUpload1.FileName;


        // Create the path and file name to check for duplicates. 
        string pathToCheck = savePath + fileName;


        // Create a temporary file name to use for checking duplicates. 
        string tempfileName = "";


        // Check to see if a file already exists with the 
        // same name as the file to upload. 
        if (System.IO.File.Exists(pathToCheck))
        {
            int counter = 2;
            while (System.IO.File.Exists(pathToCheck))
            {
                // if a file with this name already exists, 
                // prefix the filename with a number. 
                tempfileName = counter.ToString() + fileName;
                pathToCheck = savePath + tempfileName;
                counter++;
            }


            fileName = tempfileName;

            answer=StartUploadRoutine(fileName);
            // Notify the user that the file name was changed. 
            UploadStatusLabel.Text = "A file with the same name already exists." +
                "<br />Your file was saved as " + fileName;
            UploadStatusLabel.Visible = true;
           
         
        }
        else
        {
           answer= StartUploadRoutine(fileName);
            // Notify the user that the file was saved successfully. 
            UploadStatusLabel.Text = "Your file was uploaded successfully.";
            UploadStatusLabel.Visible = true;
        }

        if (answer == "Successful")
        {
            // Append the name of the file to upload to the path. 
            savePath += fileName;


            // Call the SaveAs method to save the uploaded 
            // file to the specified directory. 
            FileUpload1.SaveAs(savePath);
            LabelUploaded.Text = "Song Uploaded Successfully";
            LabelUploaded.Visible = true;

        }

        else
        {
            LabelMessage.Text = "Something Went Wrong" + answer;
            LabelMessage.Visible = true;
        }
            

    }

    
}
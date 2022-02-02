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

public partial class CreateNewSong : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserDetails"] == null)
            {
                Session["StatusMessage"] = "Please Logg in first";
                Response.Redirect("Login.aspx");
            }
            else
            {
                Populate_DropDownListStyles();
            }

        }
    }
    protected void Populate_DropDownListStyles()
    {
        DataSet ds = new DataSet();
        StyleService ss = new StyleService();
        ds = ss.ReturnStyles();
        DropDownListStyles.DataSource = ds.Tables["tblStyles"];
        DropDownListStyles.DataTextField = "NameStyle";
        DropDownListStyles.DataValueField = "StyleCode";
        DropDownListStyles.DataBind();
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

            StartUploadRoutine(fileName);
            // Notify the user that the file name was changed. 
            UploadStatusLabel.Text = "A file with the same name already exists." +
                "<br />Your file was saved as " + fileName;
            UploadStatusLabel.Visible = true;


        }
        else
        {
            StartUploadRoutine(fileName);
            // Notify the user that the file was saved successfully. 
            UploadStatusLabel.Text = "Your file was uploaded successfully.";
            UploadStatusLabel.Visible = true;
        }

            // Append the name of the file to upload to the path. 
            savePath += fileName;


            // Call the SaveAs method to save the uploaded 
            // file to the specified directory. 
            FileUpload1.SaveAs(savePath);
            LabelUploaded.Text = "Song Uploaded Successfully";
            LabelUploaded.Visible = true;
        

       


    }
    public void StartUploadRoutine(string filename)
    {
        SongsService Songservice = new SongsService();
        SongDetails Songdetails = new SongDetails();
        Songdetails.songfile = filename;
        Songdetails.songname = TextBoxSongName.Text;
        Songdetails.stylecode = int.Parse(DropDownListStyles.SelectedItem.Value);
        Songservice.UploadRegularSong(Songdetails,(((UserDetails)Session["UserDetails"]).codeuser));
       
    }

}

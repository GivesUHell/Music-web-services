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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            if (Session["StatusMessage"] != null)
            {
                LabelMessage.Text = Session["StatusMessage"].ToString();
                LabelMessage.Visible = true;
            }

            if (Session["UserDetails"] != null)
            {
                Uri MyUrl = Request.UrlReferrer;
                Response.Redirect(MyUrl.PathAndQuery, true);
            }
           
        }
        
     
            
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        UserService us= new UserService();
        if (us.CheckUserExistPassword(TextBoxUserName.Text, TextBoxPassword.Text))
        {
            UserDetails ud = new UserDetails();
            Session["UserDetails"] = us.GetAllUser(TextBoxUserName.Text);
            Label3.Visible = false;
            Uri MyUrl = Request.UrlReferrer;
            Response.Redirect(MyUrl.PathAndQuery, true);

        }
        else
        {
            Label3.Visible = true;

        }
    }
    protected void LinkButtonCreateUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("DefaultStartRegister.aspx");
    }
}

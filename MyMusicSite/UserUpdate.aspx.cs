using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserDetails user1 = new UserDetails();
        UserService us = new UserService();
        user1 = (UserDetails)(Session["UserDetails"]);
        TextBoxEmail.Text = user1.email;
        TextBoxUserName.Text = user1.username;
        TextBoxOther.Text = user1.other;
    }
    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
        UserService us2 = new UserService();
         UserService us1 = new UserService();
         if ((!us1.CheckUserNameExist(TextBoxUserName.Text))||((TextBoxUserName.Text)==((UserDetails)(Session["UserDetails"])).username))
         {
             if (!us1.CheckEmailExist(TextBoxEmail.Text) || ((TextBoxPassword.Text) == ((UserDetails)(Session["UserDetails"])).password))
             {
                 UserDetails user = new UserDetails();
                 user = (UserDetails)(Session["UserDetails"]);
                 user.email = TextBoxEmail.Text;
                 user.username = TextBoxUserName.Text;
                 user.password = TextBoxPassword.Text;
                 us2.UpdateUser(user);
             }
             else
                 LabelEmailExist.Visible = true;
         }
         else
             LabelUserExist.Visible = true;
    }
}
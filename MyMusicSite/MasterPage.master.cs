using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserDetails"]==null)
        {
            MenuItemCollection menuItems = mTopMenu.Items;
            MenuItem userItem = new MenuItem();
            foreach (MenuItem menuItem in menuItems)
            {
                if (menuItem.ImageUrl == "~/Photos/LogOut.jpeg")
                    userItem = menuItem;
            }
            menuItems.Remove(userItem);
        }

    }
    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        if (TextBoxSearch.Text == "")
            Response.Redirect("HomePage.aspx");
        else
        {
            string name = TextBoxSearch.Text;
            int value = int.Parse(DropDownListSearch.SelectedValue.ToString());
            Session["name"] = name;
            Session["value"] = value;
            Response.Redirect("SearchPage.aspx");
            
        }  
        
    }
    
}

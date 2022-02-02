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

public partial class _Default : System.Web.UI.Page
{
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { this.addBirthYears(); }
       
      

    }
    private void addBirthYears()
    {
        int endyear = DateTime.Now.Year - 120;
        for (int year = DateTime.Now.Year; year > endyear; year--)
        {
            this.DropDownListYear.Items.Add(year.ToString());

        }

    }
    protected void DropDownListMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.DropDownListDay.Items.Clear();
        int birthyear = int.Parse(this.DropDownListYear.SelectedValue);
        int endday = DateTime.DaysInMonth(birthyear, int.Parse(this.DropDownListMonth.SelectedValue));
        for (int day = 1; day <= endday; day++)
        {
            DropDownListDay.Items.Add(day.ToString());
        }
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        UserService us1 = new UserService();
        if (!us1.CheckUserNameExist(TextBoxUserName.Text))
        {
            if (!us1.CheckEmailExist(TextBoxEmail.Text))
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    UserDetails ud = new UserDetails();
                    ud.username = this.TextBoxUserName.Text;
                    ud.firstname = this.TextBoxName.Text;
                    ud.lastname = this.TextBoxLastName.Text;
                    ud.email = this.TextBoxEmail.Text;
                    ud.password = this.TextBoxPassword.Text;
                    ud.other = this.TextBoxOther.Text;
                    DateTime dt = new DateTime(int.Parse(this.DropDownListYear.Text), int.Parse(this.DropDownListMonth.Text), int.Parse(this.DropDownListDay.Text));
                    ud.dateofbirth = dt;
                    UserService us = new UserService();
                    us.InsertUser(ud);

                    Response.Redirect("Login.aspx");

                }
            }
            else
                LabelEmailExist.Visible = true;
        }
        else
            LabelUserExist.Visible = true;
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (this.DropDownListMonth.SelectedValue == "Month")
            args.IsValid = false;
        else args.IsValid = true;
    }
}

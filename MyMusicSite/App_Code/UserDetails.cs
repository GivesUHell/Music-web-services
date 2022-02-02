using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for UserDetails
/// </summary>
public class UserDetails
{
    private int CodeUser;
    private string UserName;
    private string FirstName;
    private string LastName;
    private DateTime DateOfBirth;
    private string Password;
    private string Email;
    private string Other;


	public UserDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int codeuser
    {
        get 
        {
            return CodeUser;
        }
        set
        {
            this.CodeUser = value;
        }
    }
    public string username
    {
        get 
        {
            return UserName;
        }
        set 
        {
            this.UserName = value;
        }
    }
    public string firstname
    {
        get 
        {
            return FirstName;
        }
        set 
        {
            this.FirstName = value;
        }
    }
    public string lastname { get { return LastName; } set { this.LastName = value; } }
    public DateTime dateofbirth { get { return DateOfBirth; } set { this.DateOfBirth = value; } }
    public string password { get { return Password; } set { this.Password = value; } }
    public string email { get { return Email; } set { this.Email = value; } }
    public string other { get { return Other; } set { this.Other = value; } }

}

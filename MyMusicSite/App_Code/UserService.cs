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
using System.Data.OleDb;

/// <summary>
/// Summary description for UserService
/// </summary>
public class UserService
{
    private OleDbConnection myConnection;

    public UserService()
    {
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
    }

    public int GetLastUserCode()
    {
        int LastUserCode;
        OleDbCommand mycmd = new OleDbCommand("spGetLastCodeUser", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        try
        {
            myConnection.Open();
            LastUserCode = int.Parse(mycmd.ExecuteScalar().ToString());
            return LastUserCode;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

    }
    public void InsertUser(UserDetails user)
    {
        OleDbCommand mycmd = new OleDbCommand("spInsertUser", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@UserName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = user.username;
        objpar = mycmd.Parameters.Add("@FirstName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = user.firstname;
        objpar = mycmd.Parameters.Add("@LastName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = user.lastname;
        objpar = mycmd.Parameters.Add("@DateOfBirth", OleDbType.Date);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = user.dateofbirth;
        objpar = mycmd.Parameters.Add("@Password", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = user.password;
        objpar = mycmd.Parameters.Add("@eMail", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = user.email;
        objpar = mycmd.Parameters.Add("@Other", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = user.other;
        try
        {
            myConnection.Open();
            mycmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }
    public bool CheckUserExistPassword(string username, string password)
    {
        if (password == null || username == null)
        {
            return false;
        }
        OleDbCommand mycmd = new OleDbCommand("spGetPassByUN", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@UserName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = username;
        try
        {
            myConnection.Open();
            string passwordchek = mycmd.ExecuteScalar().ToString();
            if (password == passwordchek)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }
    public bool CheckUserNameExist(string username)
    {
        OleDbCommand mycmd = new OleDbCommand("spChekUserExist", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@UserName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = username;
        try
        {

            myConnection.Open();
            if (mycmd.ExecuteScalar() != null)
            {
                return true;
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }

    public bool CheckEmailExist(string email)
    {
        OleDbCommand mycmd = new OleDbCommand("spChekEmailExist", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@eMail", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = email;
        try
        {

            myConnection.Open();
            if (mycmd.ExecuteScalar() != null)
            {
                return true;
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }

    public UserDetails GetAllUser(string username)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetAllUser", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@UserName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = username;
        try
        {
            myConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "UserDetails");
            UserDetails user = new UserDetails();
            DataRow UserRetrieved = dataSet.Tables["UserDetails"].Rows[0];
            user.codeuser = int.Parse(UserRetrieved["CodeUser"].ToString());
            user.username = UserRetrieved["UserName"].ToString();
            user.firstname = UserRetrieved["FirstName"].ToString();
            user.lastname = UserRetrieved["LastName"].ToString();
            user.dateofbirth = Convert.ToDateTime(UserRetrieved["DateOfBirth"].ToString());
            user.password = UserRetrieved["Password"].ToString();
            user.email = UserRetrieved["eMail"].ToString();
            user.other = UserRetrieved["Other"].ToString();
            return user;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

    }
    public void UpdateUser(UserDetails ud)
    {
        OleDbCommand mycmd = new OleDbCommand("spUpdateUser", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@UserName", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = ud.username;
        objpar = mycmd.Parameters.Add("@Password", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = ud.password;
        objpar = mycmd.Parameters.Add("@eMail", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = ud.email;
        objpar = mycmd.Parameters.Add("@Other", OleDbType.BSTR);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = ud.other;
        objpar = mycmd.Parameters.Add("@CodeUser", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = ud.codeuser;
        try
        {
            myConnection.Open();
            mycmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }
    public DataSet GetLists(int CodeUser)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetListsByCodeUser", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@CodeUser", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = CodeUser;
        try
        {
            myConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "tblLists");
            return dataSet;
        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }
    public DataSet GetSongsByList(int ListCode)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetSongInList", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@codeList", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = ListCode;
        try
        {
            myConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "tblSongsinlist");
            return dataSet;
        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }
    public DataSet GetSongsUploaded(int CodeUser)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetSongsUploaded", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objpar;
        objpar = mycmd.Parameters.Add("@CodeUser", OleDbType.Integer);
        objpar.Direction = ParameterDirection.Input;
        objpar.Value = CodeUser;
        try
        {
            myConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "tblSongsuploaded");
            return dataSet;
        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }

    public string CheckValidArtist(string artist)
    {

        localhostWebServiceArtists.WebServiceArtists webArt = new localhostWebServiceArtists.WebServiceArtists();
   
        //localhostWebServiceArtists.WebServiceArtists WebArt = new localhostWebServiceArtists.WebServiceArtists();
        string answer=webArt.CheckValidArtist(artist);
            return answer;
        
    }
}

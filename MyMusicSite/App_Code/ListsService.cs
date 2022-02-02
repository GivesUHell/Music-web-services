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
/// Summary description for ListsService
/// </summary>
public class ListsService
{
    private OleDbConnection myConnection;
    private OleDbTransaction objTrans;
	public ListsService()
	{
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
	}
    public DataSet GetAllLists(int CodeUser)
    {
        OleDbCommand myCmd;
        OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();

        try
        {
            myCmd = new OleDbCommand("spGetListsByCodeUser", myConnection);
            myCmd.CommandType = CommandType.StoredProcedure;
            OleDbParameter objpar;
            objpar = myCmd.Parameters.Add("@CodeUser", OleDbType.Integer);
            objpar.Direction = ParameterDirection.Input;
            objpar.Value = CodeUser;
            myDataAdapter.SelectCommand = myCmd;
            DataSet ds = new DataSet();
            myDataAdapter.Fill(ds, "tblLists");
            return ds;

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
    public void DeleteList(int codelist)
    {
        OleDbCommand mycmd = new OleDbCommand("spDeleteList", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objparam;
        objparam = mycmd.Parameters.Add("@ListCode", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = codelist;
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
    
    public void ChangeListName(int ListCode, string ListName)
    {
        OleDbCommand mycmd = new OleDbCommand("spUpdateList", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objparam;
        objparam = mycmd.Parameters.Add("@ListName", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = ListName;
        objparam = mycmd.Parameters.Add("@ListCode", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = ListCode;
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
    public void DeleteSongFromList(int songinlistcode)
    {
        OleDbCommand mycmd = new OleDbCommand("spDeleteSongFromList", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objparam;
        objparam = mycmd.Parameters.Add("@SongsInListCode", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = songinlistcode;
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

    
    public DataSet GetSongsInList(int codelist)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetSongsInList", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objparam;
        objparam = mycmd.Parameters.Add("@ListCode", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = codelist;
        OleDbDataAdapter adapter = new OleDbDataAdapter(mycmd);
        try
        {
            myConnection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tblSongsInList");
            return ds;
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

    public void AddSong(int CodeMusicUpload, int ListCode)
    {
        myConnection.Open();
        objTrans = myConnection.BeginTransaction();
        int PlaceInList = this.GetLastPlaceInList(ListCode);
        PlaceInList++;
        this.AddSongToList(CodeMusicUpload, ListCode, PlaceInList);
        try
        {
           
            objTrans.Commit();
        }
        catch (Exception ex)
        {
            objTrans.Rollback();
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }

    }

    private void AddSongToList(int CodeMusicUpload, int ListCode, int PlaceInList)
    {
        OleDbCommand mycmd = new OleDbCommand("spInsertSongToList", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        mycmd.Transaction = objTrans;
        OleDbParameter objparam;
        objparam = mycmd.Parameters.Add("@PlaceInList", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = PlaceInList;
        objparam = mycmd.Parameters.Add("@CodeMusicUpload", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = CodeMusicUpload;
        objparam = mycmd.Parameters.Add("@ListCode", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = ListCode;
        try
        {
            
            mycmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
           
        }
    }
    public int GetLastPlaceInList(int ListCode)
    {
        OleDbCommand mycmd = new OleDbCommand("spGetLastSongInListCode",myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        mycmd.Transaction=objTrans;
        OleDbParameter objparam;
        objparam = mycmd.Parameters.Add("@ListCode", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = ListCode;
        try
        {
            
            int LastPlaceInListCode = Convert.ToInt32(mycmd.ExecuteScalar());
            return LastPlaceInListCode;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
           
        }
    }

    public void AddSongFamous(int CodeSong, int ListCode)
    {
        myConnection.Open();
        objTrans = myConnection.BeginTransaction();
        int PlaceInList = this.GetLastPlaceInList(ListCode);
        PlaceInList++;
        this.AddSongFamousToList(CodeSong, ListCode, PlaceInList);
        try
        {
           
            objTrans.Commit();
        }
        catch (Exception ex)
        {
            objTrans.Rollback();
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }

    private void AddSongFamousToList(int CodeSong, int ListCode, int PlaceInList)
    {
        OleDbCommand mycmd = new OleDbCommand("spInsertSongFamousToList", myConnection);
        mycmd.CommandType = CommandType.StoredProcedure;
        mycmd.Transaction = objTrans;
        OleDbParameter objparam;
        objparam = mycmd.Parameters.Add("@PlaceInList", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = PlaceInList;
        objparam = mycmd.Parameters.Add("@CodeSong", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = CodeSong;
        objparam = mycmd.Parameters.Add("@ListCode", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = ListCode;
        try
        {
            
            mycmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
           
        }
    }
   
}
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserPage.aspx.cs" Inherits="UserPage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 23px;
        }
        #dewplayer
        {
            height: 89px;
            width: 286px;
        }
        .style3
        {
            width: 180px;
        }
        .style5
        {
            height: 42px;
        }
        .style6
        {
            width: 180px;
            height: 42px;
        }
        .style9
        {
            width: 264px;
        }
        .style10
        {
            height: 23px;
            width: 264px;
        }
        .style11
        {
            height: 42px;
            width: 264px;
        }
        .style12
        {
            width: 264px;
            height: 24px;
        }
        .style13
        {
            width: 180px;
            height: 24px;
        }
        .style14
        {
            height: 24px;
        }
        .style16
        {
            height: 11px;
            width: 180px;
        }
        .style17
        {
            height: 11px;
            width: 264px;
        }
        .style18
        {
            height: 11px;
        }
        .style19
        {
            height: 23px;
            width: 180px;
        }
    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style9">
                UserName: <asp:Label ID="LabelUserName" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style17">
                Other: <asp:Label ID="LabelOther" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="style16">
                <asp:Label ID="Label1" runat="server" Text="My Lists"></asp:Label>
                <br />
                <asp:ListBox ID="ListBoxMyList" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ListBoxMyList_SelectedIndexChanged">
                </asp:ListBox>
                <asp:ListBox ID="ListBoxMusicInList" runat="server" AutoPostBack="True" 
                    Visible="False" 
                    onselectedindexchanged="ListBoxMusicInList_SelectedIndexChanged"></asp:ListBox>
            </td>
            <td class="style18">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                &nbsp;</td>
            <td class="style13">
                <br />
                <asp:Label ID="Label2" runat="server" Text="My Uploads"></asp:Label>
                <br />
                Please Choose Song In Order to Play<br />
                <asp:ListBox ID="ListBoxUploads" runat="server" 
                    onselectedindexchanged="ListBoxUploads_SelectedIndexChanged" 
                    AutoPostBack="True"></asp:ListBox>
            </td>
            <td class="style14">
                Please Choose Song In Order to Play<br />
     
       <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" type="application/x-shockwave-flash" data="medias/dewplayer-bubble-vol.swf" 
            id="dewplayer" name="dewplayer" >
        <param name="movie" value="medias/dewplayer-bubble-vol.swf"  />
        <param name="flashvars" value="mp3=<%=MySong.Text%>" />
        <param name="wmode" value="transparent" />
        <embed src="medias/dewplayer-bubble-vol.swf"  
        quality="high"  
        pluginspage="http://www.macromedia.com/go/getflashplayer"  
        type="application/x-shockwave-flash" width="760" height="180" flashvars="mp3=<%=MySong.Text%>"></embed> 
        
    </object>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td class="style10">
                </td>
            <td class="style19">
                <asp:LinkButton ID="LinkButtonDelete" runat="server" ForeColor="Black" 
                    onclick="LinkButtonDelete_Click">Delete Selected Song</asp:LinkButton>
                <br />
                <br />
            </td>
            <td class="style2">
                <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="Black" 
                    onclick="LinkButton1_Click">Upload More Music</asp:LinkButton>
        <asp:Label ID="MySong" runat="server" Text="LableFASSC" 
            Visible="False"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="UserUpdate.aspx" 
                    ForeColor="Black">Update User :)</asp:HyperLink>
            </td>
            <td class="style6">
                <br />
                <br />
            </td>
            <td class="style5">
     
                </td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style19">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
     
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                </td>
            <td class="style19">
                </td>
            <td class="style2">
                </td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


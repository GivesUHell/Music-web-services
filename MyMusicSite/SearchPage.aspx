<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchPage.aspx.cs" Inherits="SearchPage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 210px;
        }
        #dewplayer
        {
            height: 89px;
            width: 286px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style4">
                <asp:Label ID="MySong" runat="server" Text="LableFASSC" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="GridViewSongs" runat="server" AutoGenerateColumns="False" 
                    EnableModelValidation="True" Height="262px" ShowFooter="True" 
                    style="margin-top: 0px" Width="725px" Visible="False" DataKeyNames="SongFile" 
                        onrowcommand="GridViewSongs_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="songname" HeaderText="Song Name" />
                            <asp:BoundField DataField="SongStyle" HeaderText="Style Name" />
                            <asp:BoundField HeaderText="Artist Name" DataField="SongArtist" />
                            <asp:BoundField HeaderText="Album Name" DataField="SongAlbum" />
                            <asp:TemplateField>
                                <FooterTemplate>
                                    <object ID="dewplayer" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" 
                                        data="medias/dewplayer-bubble-vol.swf" name="dewplayer" 
                                        type="application/x-shockwave-flash">
                                        <param name="movie" value="medias/dewplayer-bubble-vol.swf" />
                                        <param name="flashvars" value="mp3=<%=MySong.Text%>" />
                                        <param name="wmode" value="transparent" />
                                        <embed flashvars="mp3=<%=MySong.Text%>" height="180" 
                                            pluginspage="http://www.macromedia.com/go/getflashplayer" quality="high" 
                                            src="medias/dewplayer-bubble-vol.swf" type="application/x-shockwave-flash" 
                                            width="760"></embed>
                                    </object>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:ButtonField ButtonType="Image" CommandName="PlayMe" 
                                ImageUrl="~/Photos/Play Me.jpg" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


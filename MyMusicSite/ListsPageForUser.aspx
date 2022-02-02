<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListsPageForUser.aspx.cs" Inherits="ListsPageForUser" %>

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
        .style3
        {
        width: 541px;
    }
        .style4
        {
        height: 23px;
        width: 541px;
    }
        .style5
        {
            width: 541px;
            height: 25px;
        }
        .style6
        {
            height: 25px;
        }
    .style9
    {
        width: 49px;
    }
    .style10
    {
        height: 23px;
        width: 49px;
    }
    .style11
    {
        height: 25px;
        width: 49px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
     function op() {
         window.open("CreateList.aspx", "CreateList");
     }
  </script>
    <table class="style1">
        <tr>
            <td class="style3">
                <asp:Label ID="LabelError" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:GridView ID="GridViewLists" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="ObjectDataSourceLists" EnableModelValidation="True" 
                    onrowcommand="GridViewLists_RowCommand" DataKeyNames="ListCode" 
                   ShowFooter="True" onrowdatabound="GridViewLists_DataBound" 
                    onrowdeleting="GridViewLists_RowDeleting" 
                    onselectedindexchanged="GridViewLists_SelectedIndexChanged">
                   
                    <Columns>
                        <asp:BoundField DataField="ListName" HeaderText="List Name" />
                        <asp:BoundField DataField="NumOfSongs" HeaderText="Number Of Songs" 
                            ReadOnly="True" />
                        <asp:TemplateField HeaderText="Edit List" ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                    CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                 <input id="ButtonAddListJS" type="button" value="Add New List" runat="server" 
                                onclick="op()" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete List" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="deleteButton1" runat="server" CausesValidation="False" 
                                    CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Button" CommandName="ShowDetails" 
                            Text="Show List" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSourceLists" runat="server" 
                    onselecting="ObjectDataSourceLists_Selecting" SelectMethod="GetAllLists" 
                    TypeName="ListsService" 
                    UpdateMethod="ChangeListName">
                    <SelectParameters>
                        <asp:Parameter Name="CodeUser" Type="Int32" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ListCode" Type="Int32" />
                        <asp:Parameter Name="ListName" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>
            </td>
            <td class="style9">
                &nbsp;</td>
            <td>
                <asp:GridView ID="GridViewSongs" runat="server" AutoGenerateColumns="False" 
                    EnableModelValidation="True" Height="168px" 
                    onrowcancelingedit="GridViewSongs_RowCancelingEdit" 
                    onrowdatabound="GridViewSongs_DataBound" 
                    onrowediting="GridViewSongs_RowEditing" ShowFooter="True" 
                    style="margin-top: 0px; margin-right: 0px;" Width="555px" DataKeyNames="songinlistcode" 
                    onrowdeleting="GridViewSongs_RowDeleting" 
                    onrowupdating="GridViewSongs_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="Placeinlist" HeaderText="Number In List" />
                        <asp:BoundField DataField="songname" HeaderText="Song Name" />
                        <asp:BoundField DataField="date" HeaderText="Date Of Upload" />
                        <asp:BoundField DataField="SongStyle" HeaderText="Style Name" />
                        <asp:BoundField HeaderText="Artist Name" DataField="SongArtist" />
                        <asp:BoundField DataField="SongUploader" HeaderText="Uploader Name" />
                        <asp:BoundField HeaderText="Album Name" DataField="SongAlbum" />
                        <asp:TemplateField HeaderText="Edit Song Place" ShowHeader="False">
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                    CommandName="Update" Text="Update"></asp:LinkButton>
                                &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete Song" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="deleteButton" runat="server" CausesValidation="False" 
                                    CommandName="Delete" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <div style="height: 289px; width: 706px">
                    <asp:Panel ID="Panel1" runat="server" Height="257px" Width="648px">
                        <asp:GridView ID="GridViewFamous" runat="server" AutoGenerateColumns="False" 
                    EnableModelValidation="True" Height="201px" ShowFooter="True" 
                    style="margin-top: 0px" Width="557px" DataKeyNames="SongCode" 
                            onrowcommand="GridViewFamous_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="SongName" HeaderText="Song Name" />
                                <asp:BoundField DataField="NameStyle" HeaderText="Style Name" />
                                <asp:BoundField HeaderText="Artist Name" DataField="ArtistName" />
                                <asp:BoundField HeaderText="Album Name" DataField="AlbumName" />
                                <asp:ButtonField ButtonType="Button" CommandName="AddSong" Text="Add To List" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </td>
            <td class="style10">
            </td>
            <td class="style2">
                <div style="height: 307px; width: 738px">
                    <asp:Panel ID="Panel2" runat="server" Height="277px" Width="687px">
                        <asp:GridView ID="GridViewUploaded" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="CodeMusicUpload" EnableModelValidation="True" Height="168px" ShowFooter="True" 
                            style="margin-top: 0px" Width="530px" 
                            onrowcommand="GridViewUploaded_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="SongName" HeaderText="Song Name" />
                                <asp:BoundField DataField="DateOfUpload" HeaderText="Date Of Upload" />
                                <asp:BoundField DataField="NameStyle" HeaderText="Style Name" />
                                <asp:BoundField DataField="UserName" HeaderText="Uploader Name" />
                                <asp:ButtonField ButtonType="Button" CommandName="AddSongRegular" 
                                    Text="Add To List" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
            </td>
            <td class="style10">
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style10">
            </td>
            <td class="style2">
            </td>
        </tr>
        <tr>
            <td class="style5">
                </td>
            <td class="style11">
                </td>
            <td class="style6">
                </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


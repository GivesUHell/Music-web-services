<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateNewSong.aspx.cs" Inherits="CreateNewSong" Title="Untitled Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style9
    {
        width: 113px;
    }
    .style10
    {
        width: 397px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" style="height: 186px; width: 62%">
        <tr>
            <td class="style9">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Overline="False" 
                        Font-Underline="True" Text="My Own Song"></asp:Label>
                </td>
            <td class="style10">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                <asp:Label ID="Label4" runat="server" Text="SongFile"></asp:Label>
            </td>
            <td class="style10">
                    <asp:FileUpload ID="FileUpload1" runat="server" Height="34px" 
                    Width="270px" />
                </td>
            <td>
                    <asp:Label ID="LabelMessage" runat="server" ForeColor="Red" Text="Label" 
                        Visible="False"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style9">
                    <asp:Label ID="Label1" runat="server" Text="Song Name"></asp:Label>
                </td>
            <td class="style10">
                    <asp:TextBox ID="TextBoxSongName" runat="server" style="margin-left: 0px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxSongName" 
                    runat="server" ControlToValidate="TextBoxSongName" 
                    ErrorMessage="Enter Song Name"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                    <asp:Label ID="LabelStyle" runat="server" Text="Song Style"></asp:Label>
                </td>
            <td class="style10">
                    <asp:DropDownList ID="DropDownListStyles" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style10">
                    <asp:Button ID="UploadBtn" runat="server" onclick="UploadBtn_Click" 
                        Text="Add Song" />
                <asp:Label ID="UploadStatusLabel" runat="server" ForeColor="Red" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LabelUploaded" runat="server" ForeColor="Red" Text="Label" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style9">
                &nbsp;</td>
            <td class="style10">
                    <asp:Label ID="LabelError" runat="server" ForeColor="Red" 
                        Text="*You Can Only Upload One Song At Once"></asp:Label>
                </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


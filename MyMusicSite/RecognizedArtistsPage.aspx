<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecognizedArtistsPage.aspx.cs" Inherits="RecognizedArtistsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style9
    {
        width: 370px;
    }
        .style10
        {
            width: 142px;
        }
        .style11
        {
            width: 142px;
            height: 26px;
        }
        .style12
        {
            width: 370px;
            height: 26px;
        }
        .style13
        {
            height: 26px;
        }
        .style15
        {
            width: 425px;
        }
        .style16
        {
            width: 166px;
        }
        .style17
        {
            width: 234px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
<tr>
<td class="style16"></td>
<td class="style15">
    <asp:Label ID="LabelCheck1" runat="server" Font-Bold="True" Font-Size="X-Large" 
        ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </td>
<td class="style17"></td>
</tr>
</table>
<div style="height: 271px; width: 858px">

    <asp:Panel ID="Panel1" runat="server" Height="252px" Width="839px">
        <table class="style1">
            <tr>
                <td class="style10">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Underline="True" 
                        Text="Famous Song"></asp:Label>
                </td>
                <td class="style9">
                    <asp:Label ID="LabelCheck" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    SongFile</td>
                <td class="style9">
                    <asp:FileUpload ID="FileUpload1" runat="server" Height="34px" Width="270px" />
                    <asp:Label ID="LabelMessage" runat="server" ForeColor="Red" Text="Label" 
                        Visible="False"></asp:Label>
                    <asp:Label ID="UploadStatusLabel" runat="server" ForeColor="#FF5050" 
                        Text="Label" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="Label5" runat="server" Text="Song Name"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="TextBoxSongName0" runat="server" style="margin-left: 0px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TextBoxSongName0" ErrorMessage="Please Enter Song Name"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="LabelStyle0" runat="server" Text="Song Style"></asp:Label>
                </td>
                <td class="style9">
                    <asp:DropDownList ID="DropDownListStyles0" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="LabelAlbumByArtist" runat="server" Text="Song Album "></asp:Label>
                </td>
                <td class="style9">
                    <asp:DropDownList ID="DropDownListAlbumsByArtist" runat="server" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:LinkButton ID="LinkButtonNewAlbum" runat="server" 
                        onclick="LinkButtonNewAlbum_Click" CausesValidation="false" >Create 
            New Album!</asp:LinkButton>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="Label6" runat="server" Text="AlbumName"></asp:Label>
                </td>
                <td class="style12">
                    <asp:TextBox ID="TextBoxNewAlbum" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td class="style13">
                </td>
            </tr>
            <tr>
                <td class="style11">
                    </td>
                <td class="style12">
                    <asp:Button ID="UploadBtn" runat="server" onclick="UploadBtn_Click" 
                        Text="Upload" />
                </td>
                <td class="style13">
                    </td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style9">
                    <asp:Label ID="LabelUploaded" runat="server" Text="Label" ForeColor="Red" 
                        Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>

</div>
</asp:Content>


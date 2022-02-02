<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
                <asp:Label ID="Label2" runat="server" 
                    
        Text="Welcome to BlaBlaBla, Please enter Username And Password in order to login :)"></asp:Label>
</p>
    <table class="style1">
        <tr>
            <td>
                UserName</td>
            <td>
                <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="LabelMessage" runat="server" ForeColor="Red" Text="Label" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Password</td>
            <td>
                <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="ButtonSubmit" runat="server" onclick="ButtonSubmit_Click" 
                    Text="Login" />
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" ForeColor="Red" 
                    Text="UserName or password entered incorrectly" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:LinkButton ID="LinkButtonCreateUser" runat="server" 
                    CausesValidation="False" onclick="LinkButtonCreateUser_Click">Dont Have 
                User? Create One Here!</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>


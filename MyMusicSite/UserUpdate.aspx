<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserUpdate.aspx.cs" Inherits="UserUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
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
                USERNAMEUPDATE</td>
            <td>
                <asp:TextBox ID="TextBoxUserName" runat="server" ></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" 
                    ControlToValidate="TextBoxUserName" ErrorMessage="Please Enter UserName"></asp:RequiredFieldValidator>
                <asp:Label ID="LabelUserExist" runat="server" ForeColor="Red" 
                    Text="UserName Exist" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                PASSWORDUPDATE</td>
            <td>
                <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBoxPassword" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPass" 
                    runat="server" ControlToValidate="TextBoxPassword" 
                    ErrorMessage="Password Must Contain Atleast 5 Chars" 
                    ValidationExpression="\w{4}\w+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                PASSVAL</td>
            <td>
                <asp:TextBox ID="TextBoxPasswordTrue" runat="server" Height="22px"></asp:TextBox>
            </td>
            <td>
                <asp:CompareValidator ID="CompareValidatorPassword" runat="server" 
                    ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxPasswordTrue" 
                    ErrorMessage="Password Not Validated"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                EMAIL UPDATE</td>
            <td>
                <asp:TextBox ID="TextBoxEmail" runat="server" AutoPostBack="True"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBoxEmail" ErrorMessage="Please Enter E-mail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBoxEmail" ErrorMessage="Must Be from type @... .com" 
                    ValidationExpression="\w+\@\w+\.com"></asp:RegularExpressionValidator>
                <asp:Label ID="LabelEmailExist" runat="server" ForeColor="Red" 
                    Text="Email Exist" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                OTHER UPDATE</td>
            <td>
                <asp:TextBox ID="TextBoxOther" runat="server"></asp:TextBox>
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
                <asp:Button ID="ButtonUpdate" runat="server" EnableTheming="True" 
                    onclick="ButtonUpdate_Click" Text="Update User" />
            </td>
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


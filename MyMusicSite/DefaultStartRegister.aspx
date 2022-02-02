<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefaultStartRegister.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 128px;
        }
        .style5
        {
            width: 235px;
        }
        .style4
        {
            height: 25px;
            width: 128px;
        }
        .style6
        {
            height: 25px;
            width: 235px;
        }
        .style2
        {
            height: 25px;
        }
        .style7
        {
            width: 128px;
            height: 24px;
        }
        .style8
        {
            width: 235px;
            height: 24px;
        }
        .style9
        {
            height: 24px;
        }
        .style10
        {
            width: 128px;
            height: 61px;
        }
        .style11
        {
            width: 235px;
            height: 61px;
        }
        .style12
        {
            height: 61px;
        }
        .style13
        {
            width: 128px;
            height: 21px;
        }
        .style14
        {
            width: 235px;
            height: 21px;
        }
        .style15
        {
            height: 21px;
        }
        .style16
        {
            width: 128px;
            height: 111px;
        }
        .style17
        {
            width: 235px;
            height: 111px;
        }
        .style18
        {
            height: 111px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style10">
                <asp:Label ID="Label1" runat="server" BorderColor="#0066CC" 
                    BorderStyle="Double" Height="24px" Text="Registration Form" Width="123px"></asp:Label>
            </td>
            <td class="style11">
                &nbsp;</td>
            <td class="style12">
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                UserName</td>
            <td class="style6">
                <asp:TextBox ID="TextBoxUserName" runat="server" ></asp:TextBox>
            </td>
            <td class="style2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" 
                    ControlToValidate="TextBoxUserName" ErrorMessage="Please Enter UserName"></asp:RequiredFieldValidator>
                <asp:Label ID="LabelUserExist" runat="server" ForeColor="Red" 
                    Text="UserName Exist" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                FirstName</td>
            <td class="style5">
                <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName0" runat="server" 
                    ControlToValidate="TextBoxName" ErrorMessage="Please Enter Name"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" 
                    runat="server" ControlToValidate="TextBoxName" 
                    ErrorMessage="No Numbers Allowed" ValidationExpression="[a-z,A-Z]+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                LastName</td>
            <td class="style5">
                <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" runat="server" 
                    ControlToValidate="TextBoxLastName" ErrorMessage="Please Enter Last Name"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorLastName" 
                    runat="server" ControlToValidate="TextBoxLastName" 
                    ErrorMessage="No Numbers Allowed" ValidationExpression="[a-z,A-Z]+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Date Of Birth
                        </td>
                        <td class="style5">
                            <asp:DropDownList ID="DropDownListDay" runat="server" AutoPostBack="True">
                                <asp:ListItem Value="Day">Day</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListMonth" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="DropDownListMonth_SelectedIndexChanged" 
                                style="height: 22px">
                                <asp:ListItem Value="Month">Month</asp:ListItem>
                                <asp:ListItem Value="1"></asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem Value="8"></asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem Value="12"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListYear" runat="server" DataTextField="Year" >
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                ControlToValidate="DropDownListMonth" ErrorMessage="Please Enter Date" 
                                onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7">
                            Password</td>
            <td class="style8">
                <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            </td>
            <td class="style9">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBoxPassword" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPass" 
                    runat="server" ControlToValidate="TextBoxPassword" 
                    ErrorMessage="Password Must Contain Atleast 5 Chars" 
                    ValidationExpression="\w{4}\w+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                PasswordValidator</td>
            <td class="style5">
                <asp:TextBox ID="TextBoxPasswordTrue" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:CompareValidator ID="CompareValidatorPassword" runat="server" 
                    ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxPasswordTrue" 
                    ErrorMessage="Password Not Validated"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                E-mail Address</td>
            <td class="style5">
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
            <td class="style16">
                Other Information</td>
            <td class="style17">
                <asp:TextBox ID="TextBoxOther" runat="server" Height="106px" Width="228px"></asp:TextBox>
            </td>
            <td class="style18">
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:Button ID="ButtonSubmit" runat="server" onclick="ButtonSubmit_Click" 
                    Text="Register!" />
            </td>
            <td class="style14">
            </td>
            <td class="style15">
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>


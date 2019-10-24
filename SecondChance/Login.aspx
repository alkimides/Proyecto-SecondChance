<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SecondChance.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
 
</head>
<body style="height: 268px">
    <form id="form1" runat="server">
        <div style="background-image: url('Images/loginImage.jpg'); height:1080px">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />


        <div style="position:relative; height: 117px; width: 369px; top: 244px; left: 752px;">
            <table style="margin:auto;border:5px solid white">
                <tr>
                    <td>
                        <asp:Label ID="lblUsername" runat="server" Text="Username :" ForeColor="White"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text="Password: " ForeColor="White"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td>

                    </td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesion" OnClick="btnLogin_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnPostbackRegister" runat="server" Text="Registrarse" OnClick="btnPostbackRegister_Click" />
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                    <td>
                        <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        </div>
    </form>
</body>
</html>

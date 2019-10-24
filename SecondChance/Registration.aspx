<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="SecondChance.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-image: url('Images/space-624054.jpg'); height: 1080px;">
           
        <div style="position:relative; top: 396px; left: 672px; width: 324px;" >
            <asp:Label ID="lblRegisterTitle"  runat="server" Text="WELCOME" ForeColor="White" Font-Size="XX-Large"></asp:Label>
            <br />
            <br />

            <br />

             <table style="margin:auto;border:5px solid white">  
                
                <tr>  
                    <td>First Name</td>  
                    <td>  
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>  
                    </td>  
  
               </tr>  
                  <tr>  
                    <td>Last Name</td>  
                    <td>  
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>  
                    </td>  
  
               </tr>
                <tr>  
                    <td>Username</td>  
                    <td>  
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>  
                    </td>  
  
               </tr>    
                <tr>  
                    <td>Password</td>  
                     <td> <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>  
                </tr>  
                <tr>  
                    <td>Country</td>  
                    <td>  
                        <asp:DropDownList ID="ddlCountry" runat="server">   
                        </asp:DropDownList>  
                    </td>  
                </tr>
                 <tr>  
                    <td>Adress</td>  
                    <td>  
                        <asp:TextBox ID="txtAdress" runat="server"></asp:TextBox>  
                    </td>  
                </tr>   
               
                <tr>  
                    <td>Mail</td>  
                    <td>  
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>  
                    </td>  
                </tr> 
                 <tr>  
                    <td>Phone</td>  
                    <td>  
                        <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>  
                    </td>  
                </tr> 
                 <tr>  
                    <td>Birth Date</td>  
                    <td>  
                        <asp:TextBox ID="txtBirthDate" runat="server"  TextMode="Date"></asp:TextBox>  
                    </td>  
                </tr>   
                <tr>  
                    <td>  
                        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />  
                    </td>  
                </tr> 
                <tr>  
                    <td>  
                        <asp:Button ID="btnBacktoLogin" runat="server" Text="Already Registerded" OnClick="btnBacktoLogin_Click" />  
                    </td>  
                </tr>   
                <tr>
                    <td>
                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table> 
        </div>
           
            
        </div>
    </form>
</body>
</html>

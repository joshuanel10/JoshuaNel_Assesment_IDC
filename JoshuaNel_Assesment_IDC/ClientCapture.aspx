<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientCapture.aspx.cs" Inherits="JoshuaNel_Assesment_IDC.ClientCapture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
    <tr>
        <td>Client ID Number</td>
        <td>
            <asp:TextBox ID="txtIDNumber" runat="server"></asp:TextBox>
            

        </td>
    </tr>
    <tr>
        <td>Client Name</td>
        <td>
            <asp:TextBox ID="txtClientName" runat="server"></asp:TextBox>
           
        </td>
    </tr>
    <tr>
        <td>Client Surname</td>
        <td>
            <asp:TextBox ID="txtClientSurname" runat="server"></asp:TextBox>
            
        </td>
    </tr>
    <tr>
        <td>Contact Number</td>
        <td>
            <asp:TextBox ID="txtContactNumber" runat="server"></asp:TextBox>
            
        </td>
    </tr>
    <tr>
        <td>Call Centre Name</td>
        <td>
            <asp:TextBox ID="txtCallCentre" runat="server"></asp:TextBox>
            
        </td>
    </tr>
    <tr>
    <td>Client Email</td>
        <td>
            <asp:TextBox ID="txtClientEmail" runat="server"></asp:TextBox>
        
        </td>
    </tr>
    <tr>
    <td>Client Account Balance</td>
        <td>
            <asp:TextBox ID="txtAccBal" runat="server"></asp:TextBox>
    
        </td>
    </tr>
        <tr>
            <td>Captured By</td>
            <td>
                <asp:TextBox ID="txtCapturedBy" runat="server"></asp:TextBox>
        
            </td>
        </tr>
    <tr>
        <td>Capture Date</td>
        <td>
            <asp:Calendar ID="calCaptureDate" runat="server"></asp:Calendar>
            
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnFarmerCreate" runat="server" Text="Insert" OnClick="btnFarmerCreate_Click"/>
        </td>
    </tr>
</table>
        </div>
    </form>
</body>
</html>

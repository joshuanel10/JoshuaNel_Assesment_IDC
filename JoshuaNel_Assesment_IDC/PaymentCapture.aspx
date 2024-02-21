<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentCapture.aspx.cs" Inherits="JoshuaNel_Assesment_IDC.PaymentCapture" %>

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
                    <td>ClientID</td>
                    <td>
                        <asp:TextBox ID="txtClientID" runat="server"></asp:TextBox>
            
                    </td>
                </tr>
                <tr>
                    <td>PaymentAmount</td>
                    <td>
                        <asp:TextBox ID="txtPaymentAmount" runat="server"></asp:TextBox>
            
                    </td>
                </tr>
                <tr>
                    <td>Reference</td>
                    <td>
                        <asp:TextBox ID="txtReference" runat="server"></asp:TextBox>
            
                    </td>
                </tr>
                <tr>
                    <td>Payment Date</td>
                    <td>
                        <asp:Calendar ID="calPaymentDate" runat="server"></asp:Calendar>
        
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnPaymentAdd" runat="server" Text="Insert" OnClick="btnPaymentAdd_Click"  />
                    </td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblTest" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>

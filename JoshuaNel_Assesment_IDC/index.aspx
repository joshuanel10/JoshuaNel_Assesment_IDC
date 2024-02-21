<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="JoshuaNel_Assesment_IDC.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <div style="height: 57px">
        Client Management Software</div>
        </div>
        <asp:Button ID="clientCapturebtn" runat="server" Text="Client Capture" OnClick="clientCapturebtn_Click"   />
        <p>
            <asp:Button ID="clientOverviewbtn" runat="server" Text="Client Overview" OnClick="clientOverviewbtn_Click"  />
        </p>
        <asp:Button ID="paymentCapturebtn" runat="server" Text="Payment Capture" OnClick="paymentCapturebtn_Click" />
    </form>
</body>
</html>

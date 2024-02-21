<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientOverview.aspx.cs" Inherits="JoshuaNel_Assesment_IDC.ClientOverview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Enter Client ID:   "></asp:Label>
                <asp:TextBox ID="txtClientSearch" runat="server"></asp:TextBox>
                <br/>
                <asp:Button ID="btnClientSearch" runat="server" Text="Search" OnClick="btnClientSearch_Click"  />
            </div>

            <div>
                <table style="width: 800px; margin: auto">
                    <tr>
                        <td>
                            <asp:GridView ID="Client_View" runat="server" Width="100%"></asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table style="width: 800px; margin: auto">
                    <tr>
                        <td>
                            <asp:GridView ID="PaymentView" runat="server" Width="100%"></asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>

            <div>
                <asp:Label ID="Label2" runat="server" Text="Enter Client Email:   "></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <br/>
                <asp:Button ID="btnExport" runat="server" Text="Search" OnClick="btnExport_Click"    />
            </div>

        </div>
    </form>
</body>
</html>

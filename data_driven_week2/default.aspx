<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="data_driven_week2._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The form</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>            
            <asp:Label ID="MainTitle" runat="server" Text="Very interesting" Font-Bold="True" Font-Names="Arial Black" Font-Size="X-Large"></asp:Label>
            
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            
        </div>
    </form>
</body>
</html>

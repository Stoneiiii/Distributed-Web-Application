<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="web.Protected.Member" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><% Response.Write("Hello " + Context.User.Identity.Name + ", "); %> <asp:Button ID="Button1" runat="server" Text="Sign Out" OnClick="Button1_Click" /></h1>
            <p>
                Back to main page. <asp:Button ID="Button2" runat="server" Text="Main Page" OnClick="Button2_Click" />
            </p>
            <p>
                Your favorites:
                </p>
            <p>
            <asp:ListBox ID="ListBox1" runat="server" Height="186px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="211px"></asp:ListBox>
                </p>
            <p>
                <asp:Button ID="Button3" runat="server" Text="Get Info" OnClick="Button3_Click" />
                </p>
            <p>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>

        </div>
    </form>
</body>
</html>

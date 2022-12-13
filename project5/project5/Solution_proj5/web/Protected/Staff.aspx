<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="web.Protected.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><% Response.Write("Hello Administrators " + Context.User.Identity.Name + ", "); %> <asp:Button ID="Button1" runat="server" Text="Sign Out" OnClick="Button1_Click" /></h1>

            <p>
                We now have <asp:Label ID="Label1" runat="server" ForeColor="#FF3300"></asp:Label> member.
            </p>
            <p>
            <asp:ListBox ID="ListBox1" runat="server" Height="155px" Width="129px"></asp:ListBox>
                </p>
                <p>
                <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" /><asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </p>
            <p>
                <asp:ListBox ID="ListBox2" runat="server" Height="155px" Width="129px"></asp:ListBox>
                </p>


              <p>
            <asp:Button ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click"  /><asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                </p>
                        <p>
                Username: <asp:TextBox ID="TextBox1" runat="server" Width="160px"></asp:TextBox>
                </p>
                        <p>
                Password: <asp:TextBox ID="TextBox2" runat="server" Width="160px"></asp:TextBox>
                </p>
                    
            <p>
            <asp:Button ID="Button3" runat="server" Text="Add" OnClick="Button3_Click" />
                </p>

        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="web.StaffLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Welcome Staff!</h3>
            <p>
    User name:<asp:TextBox ID="TextBox1" runat="server" Width="177px"></asp:TextBox>
        </p>

        <p>
    Password :<asp:TextBox ID="TextBox2" runat="server" Width="177px" TextMode="Password" ></asp:TextBox>
        </p>

            <p>
        <asp:Button ID="Button1" runat="server" Text="Log In" OnClick="Button1_Click" />
        <asp:CheckBox ID="Persistent" runat="server" Text="Remember me"/>
    </p>
            <p>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                 </p>

        </div>
    </form>
</body>
</html>

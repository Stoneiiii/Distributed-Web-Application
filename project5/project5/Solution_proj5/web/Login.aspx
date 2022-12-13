<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Welcome!</h3>
            <p>Haven't joined us yet? Come on in!<asp:Button ID="Button3" runat="server" Text="Sign Up!" OnClick="Button3_Click" /></p>
        </div>

            <p>
    User name:<asp:TextBox ID="TextBox1" runat="server" Width="177px"></asp:TextBox>
        </p>

        <p>
    Password :<asp:TextBox ID="TextBox2" runat="server" Width="177px" TextMode="Password" ></asp:TextBox>
        </p>
    <p>
        <asp:Image ID="Image1" runat="server" Visible="False" />&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Get Captcha" OnClick="Button2_Click" />
        &nbsp;
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Log In" OnClick="Button1_Click" />
        <asp:CheckBox ID="Persistent" runat="server" Text="Remember me"/>
        

    </p>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </form>

</body>
</html>





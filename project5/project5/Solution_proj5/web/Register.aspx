<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="web.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h1>Welcome New User!
            </h1>
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            <p>
                If you sign up to be one of us, you can have your own favorites page to collect your favorite restaurants!
                </p>
            <p>
                (*)User name: <asp:TextBox ID="TextBox1" runat="server" Width="175px" style="margin-left: 121px"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300"></asp:Label>
                </p>
            <p>
                (*)Password:<asp:TextBox ID="TextBox2" runat="server" Width="175px" style="margin-left: 136px"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" ForeColor="#FF3300"></asp:Label>
                </p>
            <p>
                (*)Confirm Password:<asp:TextBox ID="TextBox3" runat="server" Width="175px" style="margin-left: 73px"></asp:TextBox>
                </p>
            <p>
                (*)Longitude of address:<asp:TextBox ID="TextBox4" runat="server" Width="175px" style="margin-left: 42px"></asp:TextBox>
                </p>
            <p>
                (*)Latitude of address:<asp:TextBox ID="TextBox5" runat="server" Width="175px" style="margin-left: 50px"></asp:TextBox>
                </p>
            <p>
                (*)Captcha :<asp:Button ID="Button2" runat="server" Text="Get Capcha" OnClick="Button2_Click" />
                <asp:TextBox ID="TextBox6" runat="server" Width="175px" style="margin-left: 33px"></asp:TextBox>
                </p>
            <p>
                <asp:Image ID="Image1" runat="server" />
                </p>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Register!" OnClick="Button1_Click" /><asp:Label ID="Label3" runat="server" ForeColor="#FF3300"></asp:Label>
    </form>
</body>
</html>

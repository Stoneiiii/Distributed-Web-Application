<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="web.TryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>TryIt Web</h1>
        <h3>Encryption DLL</h3>

    <p>Use MD5 to encrypt. Because MD5 cannot be decrypted, so after MD5 encryption of the user input password, check if it is the same.</p>
            <p>Input: String  Outpur: String after MD5.</p>
        <p>
            Password:<asp:TextBox ID="TextBox1" runat="server" Width="271px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Encryption" OnClick="Button1_Click" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Result:"></asp:Label>
        </p>
    </form>
</body>
</html>

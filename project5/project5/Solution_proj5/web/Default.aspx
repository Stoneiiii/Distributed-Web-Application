<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Welcome to Restaurant  Information</h1>
    <p>
        <asp:Button ID="Button3" runat="server" Text="Sign In" OnClick="Button3_Click" />&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" Text="Sign Out" Visible="False" OnClick="Button4_Click" />&nbsp;&nbsp;
        <a href="Protected/Member"><asp:Label ID="Label5" runat="server" Text="Go to member page"></asp:Label></a>
    </p>
    <h3>Enjoy life, enjoy food!</h3>
    <p>Find the restaurant you want to visit and get information.</p>
    <p>After you sign in, you can add you store to your private favorites list. We can also tell you how to get there by using Google Map!</p>
    <p>Hot Restaurant you can try serach: rusty-taco-tempe, happy-joe-coffee-tempe, shady-park-tempe</p>
    <p>    
        Restaurant:<asp:TextBox ID="TextBox1" runat="server" Width="172px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Find" OnClick="Button1_Click" />
        &nbsp;&nbsp; History: <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Result:"></asp:Label>
        </p>
    <p>
    Want to add to your favorites?<asp:Button ID="Button2" runat="server" Text="Do it!" OnClick="Button2_Click" />
        <asp:Label ID="Label4" runat="server" ForeColor="#FF3300"></asp:Label>
        </p>
    <p></p>
    <p>
        Staff Login:<asp:Button ID="Button5" runat="server" Text="Login" OnClick="Button5_Click" /></p>
</asp:Content>

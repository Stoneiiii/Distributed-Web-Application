<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="TryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <H2>TryIt of XML</H2>
    <H3>Operation 1: XML Verify</H3>
    <p>Input1:URL of an XML (.xml) file</p>
    <p>Input2:URL of the corresponding XMLS (.xsd) file</p>
    <p>Return:Errors information or No Error</p>
    <p>
    URL of an XML(.xml):<asp:TextBox ID="TextBox1" runat="server" Width="343px"></asp:TextBox>
        </p>
    <p>E.g. :https://www.public.asu.edu/~leihu3/Cruises.xml  or CruisesError.xml</p>
    <p>
    URL of an XMLS(.xsd):<asp:TextBox ID="TextBox2" runat="server" Width="333px"></asp:TextBox>
        </p>
    <p>E.g. :https://www.public.asu.edu/~leihu3/Cruises.xsd</p>
    <p>
    <asp:Button ID="Button1" runat="server" Text="Verify" OnClick="Button1_Click" Width="114px" />
        </p>
    <p>
    <asp:Label ID="Label1" runat="server" Text="Result:"></asp:Label>
        </p>


    <H3>Operation 2: XPATH Search</H3>
    <p>Input1:URL of an XML (.xml) file</p>
    <p>Input2:XPATH Expression</p>
    <p>Return:Errors Searching Result</p>
     <p>
    URL of an XML(.xml):<asp:TextBox ID="TextBox3" runat="server" Width="343px"></asp:TextBox>
        </p>
    <p>E.g. :https://www.public.asu.edu/~leihu3/Cruises.xml</p>
    <p>
    XPATH Expression:<asp:TextBox ID="TextBox4" runat="server" Width="354px"></asp:TextBox>
        </p>
    <p>E.g. :/Cruises/Cruise/Reservation/Phone</p>
    <p><asp:Button ID="Button2" runat="server" Text="Search" OnClick="Button2_Click" /></p>
    <p><asp:Label ID="Label2" runat="server" Text="Result:"></asp:Label></p>
</asp:Content>

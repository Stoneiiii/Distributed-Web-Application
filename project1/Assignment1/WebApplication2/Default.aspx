<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  
    <h2>Temperature Conversion(rounding)</h2>
    <p>Celsius to Fahrenheit(rounding)</p>

    <!  TextBox1:Receive input
        onkeypress:numbers are allowed to be entered
        onfocus:clear textbox when input
        onblur:Prompt for input when no input
    >
    <p><asp:TextBox ID="TextBox1" onkeypress="if (event.keyCode != 45 && (event.keyCode < 48 || event.keyCode >57)) event.returnValue = false;" runat="server" Width="226px" Forecolor="#999999" value="Please input Celsius degree" 
        onfocus="if(value == defaultValue){value='';this.style.color='#000'}" onblur="if(!value){value = 'Please input Celsius degree';this.style.color='#999'}">
       </asp:TextBox>℃ 
    <! Button1 for Celsius to Fahrenheit>   
    &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Convert" />
        
        <! Label1 for showing result>  
        &nbsp;&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>℉

    </p>

    <p>Fahrenheit to Celsius(rounding)</p>
   <!   TextBox2:Receive input
        onkeypress:numbers are allowed to be entered
        onfocus:clear textbox when input
        onblur:Prompt for input when no input
    >
    <p><asp:TextBox ID="TextBox2" onkeypress="if (event.keyCode != 45 && (event.keyCode < 48 || event.keyCode >57)) event.returnValue = false;" runat="server" Width="226px" Forecolor="#999999" value="Please input Fahrenheit degree"
        onfocus="if(value == defaultValue){value='';this.style.color='#000'}" onblur="if(!value){value = 'Please input Celsius degree';this.style.color='#999'}">


       </asp:TextBox>℉ 
    <! Button1 for Celsius to Fahrenheit>  
    &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Convert" />
        <! Label2 for showing result>  
        &nbsp;&nbsp;<asp:Label ID="Label2" runat="server"></asp:Label>℃

    </p>

    <br/>
 
</asp:Content>

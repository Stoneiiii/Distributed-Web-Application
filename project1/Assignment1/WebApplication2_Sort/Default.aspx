<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2_Sort._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Sorting Numbers In Ascending Order</h2>

<p>Please enter the number to be sorted, separated by commas.</p> 


<!  TextBox1: Receive input
    onkeypress: Only numbers, minus sign and commas are allowed to be entered
    onfocus:clear textbox when input
    onblur:Prompt for input when no input
    >
<p>
<asp:TextBox ID="TextBox1" onkeypress="if (event.keyCode != 44 && event.keyCode != 45 && (event.keyCode < 48 || event.keyCode >57 )) event.returnValue = false;" runat="server" Width="252px" value ="Enter numbers separated by comma"
    Forecolor="#999999" onfocus="if(value == defaultValue){value='';this.style.color='#000'}" onblur="if(!value){value = 'Enter numbers separated by comma';this.style.color='#999'}"
    ></asp:TextBox>
 
<! button for start sorting>
<asp:Button ID="Button1" runat="server" Text="Sort Numbers" OnClick="Button1_Click1" />
</p>

<! label1 for showing result>    
<p>
The result is:
<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</p>



</asp:Content>

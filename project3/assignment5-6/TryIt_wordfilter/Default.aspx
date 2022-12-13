<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryIt_wordfilter._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Word Filter Service</h2>
    <p>Analyze a string of words, then filter and remove the stop words, XML tags or attribute names, and so on, and finally return the string.</p>
    <p>URL:This is a local service</p>
    <p>https://localhost:XXXXX/api/wordfilter?str=YourString</p>
    <p>Input:String Output:String(*return a string without stop words)</p>       
  

      <!   TextBox1:Receive input for Word Filter Service
        onkeypress:numbers are allowed to be entered
        onfocus:clear textbox when input
        onblur:Prompt for input when no input
    >

    <p>
        <asp:TextBox ID="TextBox1" runat="server" Width="371px" Forecolor="#999999" value="Please input string"  onfocus="if(value == defaultValue){value='';this.style.color='#000'}" onblur="if(!value){value = 'Please input string';this.style.color='#999'}"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Filter!" />
        
        </p>

    <!  Label1 is user input
        Lable2 is result
    >
    <p>You iuput:<asp:Label ID="Label2" runat="server" Text="This is your input string"></asp:Label></p>
    <p>Result:<asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>
       
    <h2>Top 10 Content Words</h2>
    <p>Analyze a string of words, then return the ten most-frequently occurred words in the string.(punctuation, XML tags or attribute names, HTML tags are not counted)</p>
    <p>URL:This is a local service</p>
    <p>http://localhost:xxxx/Service1.svc</p>
    <p>Input:String Output:String(*return a string contains top10 words)</p>
    <p>Method1:Dictionary<string, int> CountWord(string str):Input a string, then return a dictionary contains words and their frequency</p>
    <p>Method2:List<string> Top10word(Dictionary<string, int> dic):Input a dictionary contains words and their frequency, return a string contain top10 words</p>
    <p>Method3:List<string> GetTop10(string str):Input a string, return a string contain top10 words directly</p>

    <!   TextBox2:Receive input for Top 10 Content Words
        onkeypress:numbers are allowed to be entered
        onfocus:clear textbox when input
        onblur:Prompt for input when no input
    >
    <p>
        <asp:TextBox ID="TextBox2" runat="server" Width="371px" Forecolor="#999999" value="Please input string" onfocus="if(value == defaultValue){value='';this.style.color='#000'}" onblur="if(!value){value = 'Please input string';this.style.color='#999'}"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="Count!" OnClick="Button2_Click" />
        </p>
    

    <p>Top 10 are as follows:</p>
      
    <!  Label3 is result>
    <p>    
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        </p>
    

</asp:Content>

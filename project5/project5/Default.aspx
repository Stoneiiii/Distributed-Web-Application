<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Summary Table</title>
    <style>
table{border-top:1px solid #333;border-left:1px solid #333;border-spacing:0;background-color:#fff;width:100%}
table td{border-bottom:1px solid #333;border-right:1px solid #333;font-size:13px;padding:5px}
.xl74{text-align:left;}
.font5{color:windowtext;}
.xl71{color:rgb(5, 99, 193);text-align:left;}
.xl75{color:black;text-align:left;}
.xl68{text-align:center;}
.font6{color:black;}
</style>
</head>
<body>
    <table style="width:933pt"> <!--StartFragment--> 
 <colgroup>
  <col width="126" style="mso-width-source:userset;mso-width-alt:4032;width:95pt"> 
  <col width="256" style="mso-width-source:userset;mso-width-alt:8192;width:192pt"> 
  <col width="380" style="mso-width-source:userset;mso-width-alt:12160;width:285pt"> 
  <col width="271" style="mso-width-source:userset;mso-width-alt:8672;width:203pt"> 
  <col width="210" style="mso-width-source:userset;mso-width-alt:6720;width:158pt"> 
 </colgroup>
 <tbody>
  <tr height="31"> 
   <td colspan="5" class="xl68">Application and Components Summary Table</td> 
  </tr> 
  <tr height="24"> 
   <td colspan="5" class="xl68">This page is at: <a href="http://webstrar86.fulton.asu.edu/Default.aspx">http://webstrar86.fulton.asu.edu/Default.aspx</a><br>The home page of our website is: <a href="http://webstrar86.fulton.asu.edu/page6/Default">http://webstrar86.fulton.asu.edu/page6/Default</a></td> 
    
  </tr> 
  <tr height="24"> 
   <td colspan="5" class="xl68">Percentage of contribution: Lei Hu(1226730260 50%), Shore Wang(1223586936 50%)</td> 
  </tr> 
  <tr height="76"> 
   <td class>Provider name</td> 
   <td class>Page and component type</td> 
   <td class="xl74">TryIT</td> 
   <td class>Component description</td> 
   <td class="xl74">Actual resources and methods used to implement the component and where this component is used.</td> 
  </tr> 
  <tr height="133"> 
   <td class>Ziyang Wang</td> 
   <td class>Staff.aspx <br>Authentication and Forms Security <br>XML file manipulation</td> 
   <td class="xl71"><a href="http://webstrar86.fulton.asu.edu/Page6/Protected/Staff">http://webstrar86.fulton.asu.edu/Page6/Protected/Staff</a></td> 
   <td class>This page can not be accessed if the user is not authenticated.<br> Administrators(Staff) can delete member users, add staff and delete staff by controling XML file.	</td> 
   <td class="xl74">GUI design and C# code behind GUI. Linked to the StaffLogin page. <br>Using Forms Security to protect this page if the user is not authenticated.<br>Accessing and modifying XML</td> 
  </tr> 
  <tr height="228"> 
   <td class>Ziyang Wang</td> 
   <td class>Member.aspx <br>Authentication and Forms Security <br>WCF service<br> XML file manipulation Cookie</td> 
   <td class="xl71"><a href="http://webstrar86.fulton.asu.edu/Page6/Protected/Member">http://webstrar86.fulton.asu.edu/Page6/Protected/Member</a></td> 
   <td class>This page can not be accessed if the user is not authenticated, and will jump to the Login page because of Forms Security.<br>And this is the user's personal page, user can see their favorite shop by accessing members' XML and getting information on this page.<br>If the user is already logged in, this page will be displayed directly by clicking the "log in" button or accessing the Login page. If not, go to the Default page.</td> 
   <td class="xl74">GUI design and C# code behind GUI. Linked to the Default page or Login page.<br> Accessing XML to check the username and show their favorites in the Listbox. <br> Using Forms Security to protect this page if the user is not authenticated.</td> 
  </tr> 
  <tr height="285"> 
   <td class>Lei Hu</td> 
   <td class>Default.aspx <br>Session state <br>SVC service <br>XML file manipulation</td> 
   <td class="xl71"><a href="http://webstrar86.fulton.asu.edu/page6/Default">http://webstrar86.fulton.asu.edu/page6/Default</a></td> 
   <td class>The public Default page call and links all other pages. And input the restaurant name(String), and return the restaurant information. Also,  input data can store as Session, and show in the history label.<br> If there is a cookie to display a welcome message while certain buttons are invisible. <br> Also, there is a button for adding a shop to the user's favorites by using XML file manipulation. User can see their favorites on their member page.</td> 
   <td class="xl74">GUI design and C# code behind GUI. This is the home page linked to all pages.<br> Calling Restful Service in WebStart to return restaurant information. The restful service is used Yelp API: https://www.yelp.com/developers/documentation/v3/get_started.<br> The button for adding a shop to the user's favorites is to access member.xml and write data in XML.</td> 
  </tr> 
  <tr height="190"> 
   <td class>Lei Hu</td> 
   <td class>Login.aspx <br>User control: captcha <br>Cookie <br>Authentication and Forms Security<br> XML file manipulation,</td> 
   <td class="xl71"><a href="http://webstrar86.fulton.asu.edu/page6/Login">http://webstrar86.fulton.asu.edu/page6/Login</a></td> 
   <td class>Log in page and use captcha verification.<br>  Use cookies to store user information. If the user has already logged in, this page will not show up, and directly go to the member page<br>  Check whether the account and password inputted by the user are legitimate by accessing the XML.	</td> 
   <td class="xl74">GUI design and C# code behind GUI. Linked to the Default page and member page.<br> Using Web Service in ASU repository to create image verification.<br> Accessing XML to check user input, if it is valid, logging in successfully, and go to the member page.</td> 
  </tr> 
  <tr height="95"> 
   <td class>Lei Hu</td> 
   <td class>DLL class <br>library modules</td> 
   <td class="xl71"><a href="http://webstrar86.fulton.asu.edu/page6/TryIt">http://webstrar86.fulton.asu.edu/page6/TryIt</a></td> 
   <td class>Encryption function by MD5.<br> Input:String <br>Output:String</td> 
   <td class="xl75">Use library class and local component to implement this library function. It will be used to store users' password in XML.</td> 
  </tr> 
  <tr height="114"> 
   <td class>Lei Hu</td> 
   <td class>XML file manipulation</td> 
   <td class="xl74"><a href="http://webstrar86.fulton.asu.edu/Page6/StaffLogin">http://webstrar86.fulton.asu.edu/Page6/StaffLogin</a></td> 
   <td class="xl74">This is a page for Staff to log in.</td> 
   <td class="xl74">GUI design and C# code behind GUI. Linked to the Default page. <br>Check that the user and account and password are correct by accessing the XML</td> 
  </tr> 
  <tr height="190"> 
   <td class>Lei Hu</td> 
   <td class>Register.asap <br>Global.asax <br>Event handler</td> 
   <td class="xl74"><a href="http://webstrar86.fulton.asu.edu/page6/Register">http://webstrar86.fulton.asu.edu/page6/Register</a></td> 
   <td class="xl74">Using event handler to get the number of members in Global.asax and show in the Register page.</td> 
   <td class="xl74">GUI design and C# code behind GUI. Linked to the Default page and Login page. Every user access page will call event handler to update a variables that declared in the Global.asax, and lock this variables to avoid imultaneous registration of multiple users</td> 
  </tr> <!--EndFragment--> 
 </tbody>
</table>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login Form | CodingLab</title>
    <link rel="stylesheet" href="style.css">
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    
   <div class="container" >
      <div class="wrapper" >
        <div class="title"><span> User Login Form</span></div>
        <form1 action="#" >
        <asp:Label ID="Label_MSG" runat="server" Text=""></asp:Label>
          <div class="row">
            <i class="fas fa-user"></i>
            <asp:TextBox ID="TextBox1_Email" runat="server"></asp:TextBox>
            
          </div>
          <div class="row">
            <i class="fas fa-lock"></i>
            <asp:TextBox ID="TextBox2_Pass" runat="server"></asp:TextBox>
           
          </div>
          <div class="pass"><a href="#">Forgot password?</a></div>
          <div class="row button">
          <asp:Button ID="Button1" runat="server" Text="LOGIN NOW" onclick="Button1_Click"></asp:Button>
           
          </div>
          <div class="signup-link">Not a member? <a href="resisterUser.aspx">Register Now</a></div>
        </form1>
      </div>
    </div>
    

    </form>
</body>
</html>

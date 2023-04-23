<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resisterUser.aspx.cs" Inherits="loginUser_resisterUser" %>

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
   <div class="container">
      <div class="wrapper">
        <div class="title"><span> USER-REGISTRATION </span></div>
        <form1 action="#">
        <asp:Label ID="Label_MSG" runat="server" Text=""></asp:Label>
          <div class="row">
            <i class="fas fa-user"></i>
            <asp:TextBox ID="TextBox1_FullName" runat="server" placeholder="Full name" ></asp:TextBox>
            
          </div>
          <div class="row">
            <i class="fas fa-lock"></i>
            <asp:TextBox ID="TextBox2_Email" runat="server" placeholder="Email" ></asp:TextBox>
          </div>

            <div class="row">
            <i class="fas fa-lock"></i>
            <asp:TextBox ID="TextBox3_Password" runat="server" placeholder="Password" ></asp:TextBox>
          </div>

            <div class="row">
            <i class="fas fa-lock"></i>
            <asp:TextBox ID="TextBox4_Mobile" runat="server" placeholder="Mobile" ></asp:TextBox>
          </div>



          <div class="pass"><a href="#">Forgot password?</a></div>
          <div class="row button">
          <asp:Button ID="Button1" runat="server" Text="REGISTER NOW" onclick="Button1_Click"></asp:Button>
            
          </div>
          <div class="signup-link"><a href="Login.aspx">LOGIN</a></div>
        </form1>
      </div>
    </div>
    <asp:TextBox ID="TextBox_Autogen" runat="server" Visible="false"></asp:TextBox>
    </form>
</body>
</html>

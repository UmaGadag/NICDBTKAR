<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="NICDBTKar.DBTKar.UserLogin"  %>

<!DOCTYPE html>
<html>
<head>
<meta name="viewport" content="width=device-width, initial-scale=1">
     <!--include jQuery -->  
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"  
type="text/javascript"></script>   
<!--include jQuery Validation Plugin-->  
<script src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.12.0/jquery.validate.min.js"  
type="text/javascript"></script>

   
<style>
* {
  box-sizing: border-box;
}
 


input[type=text], select, textarea {
  width: 45%;
  padding: 12px;
  border: 1px solid #ccc;
  border-radius: 4px;
  resize: vertical;
}

label {
  padding: 12px 12px 12px 0;
  display: inline-block;
}

input[type=submit] {
  background-color: #04AA6D;
  color: white;
  padding: 12px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  float: left;

}

input[type=submit]:hover {
  background-color: #45a049;
}

.container {
  border-radius: 5px;
  background-color: #f2f2f2;
  padding: 20px;
  margin:20px 450px;
}

.col-25 {
  float: left;
  width: 25%;
}

.col-75 {
  float: left;
  width: 75%;
  margin-top: 6px;
}

/* Clear floats after the columns */
.row:after {
  content: "";
  display: table;
  clear: both;
}

.red {
    color:red;
}
@media screen and (max-width: 600px) {
  .col-25, .col-75, input[type=submit] {
    width: 100%;
    margin-top: 0;
  }
}
</style>
</head>
<body>
    <div class="container">
<h2>Login Details</h2>


  <form name="BD" runat="server">
     <div class="row">
  <div class="col-75">
      
      <asp:Label ID="lblError" runat="server" Text="Label" ForeColor="red" Visible="false"></asp:Label>
   
  </div>
         </div>
          <br />
      
    <div class="row">
      <div class="col-25">
        <label for="Username">User Name</label>
      </div>
      <div class="col-75">
          <asp:TextBox ID="txtUsername" runat="server" name="Username" ></asp:TextBox>
      <br />
          <asp:RequiredFieldValidator ID="reqUname" ControlToValidate="txtUsername" ValidationGroup="login"
  runat="server" ErrorMessage="*Username is required" CssClass="red"></asp:RequiredFieldValidator>

      </div>
    </div>
       <div class="row">
   <div class="col-25">
     <label for="psw">Password</label>
   </div>
   <div class="col-75">
       <asp:TextBox ID="txtpsw" runat="server" name="Password"  ></asp:TextBox>
       <br />
       <asp:RequiredFieldValidator ID="reqpsw" ControlToValidate="txtpsw" ValidationGroup="login"
      runat="server" ErrorMessage="*Password is required" CssClass="red"></asp:RequiredFieldValidator>
       </div>
 </div>
    
   <br />
    <div class="row">
        <asp:Button ID="login" runat="server" type="submit" Text="Login" Onclick="login_Click" ValidationGroup="login"/>
  </div>
  </form>
</div>

</body>
</html>
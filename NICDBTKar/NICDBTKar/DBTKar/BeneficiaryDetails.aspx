<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="BeneficiaryDetails.aspx.cs" Inherits="NICDBTKar.DBTKar.BeneficiaryDetails" %>

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
  width: 75%;
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
  margin:20px;
}

.col-25 {
  float: left;
  width: 25%;
  margin-top: 6px;
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
    <h2>Beneficiary Address</h2>
  <form name="BD" onsubmit="return validateForm()" runat="server">
      <div class="row">
  <div class="col-25">
      
      <asp:Label ID="lblError" runat="server" Text="Label" ForeColor="red" Visible="false"></asp:Label>
   
  </div>
          </div>
      <div class="row">
   <div class="col-25">
      <asp:TextBox ID="txtsearch" runat="server" name="search" ></asp:TextBox>
      <asp:RequiredFieldValidator ID="reqSearch" ControlToValidate="txtsearch" ValidationGroup="search"
        runat="server" ErrorMessage="please enter to search"></asp:RequiredFieldValidator>
       </div>
          <div class="col-25">
  <asp:Button ID="btnsearch" runat="server" Text="search"  ValidationGroup="search" Onclick="search_Click" />
              </div>

</div>
    <div class="row">
      <div class="col-25">
        <label for="Bname">Beneficiary Name</label>
      </div>
      <div class="col-75">
          <asp:TextBox ID="txtBname" runat="server" name="BeneficiaryName" ></asp:TextBox>
      <br />
          <asp:RequiredFieldValidator ID="reqBname" ControlToValidate="txtBname" ValidationGroup="submit"
  runat="server" ErrorMessage="*Please enter Beneficiary Name" CssClass="red"></asp:RequiredFieldValidator>

      </div>
    </div>
       <div class="row">
   <div class="col-25">
     <label for="Address">Address</label>
   </div>
   <div class="col-75">
       <asp:TextBox ID="txtAddress" runat="server" name="Address" TextMode="MultiLine" ></asp:TextBox>
       <br />
       <asp:RequiredFieldValidator ID="reqAddress" ControlToValidate="txtAddress" ValidationGroup="submit"
      runat="server" ErrorMessage="*Please enter Address" CssClass="red"></asp:RequiredFieldValidator>
       </div>
 </div>
    <div class="row">
      <div class="col-25">
        <label for="Aadhaar">Aadhaar Number</label>
      </div>
      <div class="col-75">
            <asp:TextBox ID="txtAadhaar" runat="server" length="12" name="Aadhaar" width="25%"></asp:TextBox>
       <br />
          <asp:RequiredFieldValidator ID="reqAadhaar" ControlToValidate="txtAadhaar" ValidationGroup="submit"
        runat="server" ErrorMessage="*Please enter Aadhaar number" CssClass="red"></asp:RequiredFieldValidator>
           </div>
       
    </div>
    <div class="row">
      <div class="col-25">
        <label for="Department">Department</label>
      </div>
      <div class="col-75">
          <asp:DropDownList id="ddlDepartment" runat="server"  DataTextField="0" DataValueField="--Select Department--" 
                    onselectedindexchanged="ddlDepartment_SelectedIndexChanged" AutoPostBack = "true"></asp:DropDownList>
      <br />
          <asp:RequiredFieldValidator id="reqDepartment"  InitialValue="0" ValidationGroup="submit"
              ControlToValidate="ddlDepartment" Runat="server" ErrorMessage="*Please select department" CssClass="red"/> 
      </div>
    </div>
      <div class="row">
  <div class="col-25">
    <label for="Scheme">Scheme</label>
  </div>
  <div class="col-75">
      <asp:DropDownList ID="ddlScheme" runat="server" ValidationGroup="submit"></asp:DropDownList>
    <br />
    <asp:RequiredFieldValidator id="reqScheme"  InitialValue="0" ValidationGroup="submit"
        ControlToValidate="ddlScheme" Runat="server" ErrorMessage="*Please select Scheme" CssClass="red"/> 
   
  </div>
          
</div>
   <br />
    <div class="row">
        <asp:Button ID="submit" runat="server" type="submit" Text="Save" Onclick="submit_Click" ValidationGroup="submit"/>
  </div>
  </form>
</div>

</body>
</html>


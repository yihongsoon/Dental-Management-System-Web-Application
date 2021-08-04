<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/dmsMasterpage.Master" CodeBehind="mainPage.aspx.cs" Inherits="DMS.mainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

  <style type="text/css">
      .button{
          width: 100px;
          margin-left: 20px;
      }
      .button-search{
          width: 100px;
          margin-left: 20px;
          background-color: Highlight;
          border-radius : 10px;
          padding: 12px 20px;
          color: white;
          font-weight:bold;
      }
      .button-searchApp{
          background-color:Highlight;
      }
      .button-grey{
          background-color:darkgrey;
      }
      .font-colour{
          color:white;
      }
      .ddList-align{
          margin-left: 20px;
          width:auto;
          padding: 12px 20px;
          box-sizing: border-box;
      }   
      
      .font-bold{
          font-weight:bold;
      }

      .textbox{
          margin-left: 20px;
          width: 40%;
          padding: 12px 20px;
          box-sizing: border-box;
          background-color: lightgrey;
          border-radius : 10px;  
      }
      .container-result{
          margin-left: 35px;
          height:350px; 
          width:600px;
          border-radius:10px;
      }
  </style>

    <div style="height: auto; width: auto; max-width: 100%;" class="container font-colour">
        <br/><button id="btnSearchApp" type="button" class="w3-button w3-round-large  button-searchApp button"><i class="fa fa-search">&nbsp;Search</i></button>
        <button id="btnAddApp" type="button" class="w3-button w3-round-large button-grey button"><i class="fa fa-plus">&nbsp;Add</i></button>
        <button id="btnUpdateApp" type="button" class="w3-button w3-round-large button-grey button"><i class="fa fa-pencil-square-o">&nbsp;Update</i></button>
        <button id="btnDeleteApp" type="button" class="w3-button w3-round-large button-grey button"><i class="fa fa-trash">&nbsp;Delete</i></button>
    </div>
    <br/>

        <div style="height: auto; width: auto; max-width: 100%;" class="form-group">
            <div class="col-md-12">
            <asp:DropDownList ID="ddlSearchType" runat="server" CssClass="ddList-align font-bold">
                <asp:ListItem Selected="True">By Date</asp:ListItem>
                <asp:ListItem>By Time</asp:ListItem>
                <asp:ListItem>By Appointment ID</asp:ListItem>
                <asp:ListItem>By Patient ID</asp:ListItem>
                <asp:ListItem>By Staff Register</asp:ListItem>
            </asp:DropDownList>
            </div>
        </div>
        <br />
        <br />
        <div class="form-group">
            <div class="col-md-12">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox"></asp:TextBox>
                <button id="btnSearch" type="button" class="w3-button w3-round-large button-search">Search</button>
            </div>
        </div>
        <br />
        <br />
        <div class="w3-display-container w3-grey container w3-responsive container-result">
        
        </div>

</asp:Content>

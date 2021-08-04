    <%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/dmsMasterpage.Master" CodeBehind="searchAppointment.aspx.cs" Inherits="DMS.mainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <style type="text/css">
        .button-primary{
            background-color:Highlight;
            font-size:large;
            color:white;
            width:100px;
        }
        .button-sec{
            background-color: grey;
            margin-left:20px;
            font-size:large;
            color:white;
            width:100px;
        }
        .search-ddl {
            width: auto;
            padding: 12px 20px;
            box-sizing: border-box;
        }
        .textbox{
            width:600px;
            padding: 12px 20px;
            margin-left:25px;
            background-color: lightgray;
            border-radius:10px;
            border:hidden;
        }
    </style>

    <div class="container" id="searchAppointmentDiv">
        <a href="#" class="w3-button w3-round-large button-primary" id="btnSearchApp"><i class="fa fa-search">&nbsp;Search</i></a>
        <a href="#" class="w3-button w3-round-large button-sec" id="btnAddApp"><i class="fa fa-plus">&nbsp;Add</i></a>
        <a href="#" class="w3-button w3-round-large button-sec" id="btnUpdateApp"><i class="fa fa-pencil-square-o">&nbsp;Update</i></a>
        <a href="#" class="w3-button w3-round-large button-sec" id="btnDeleteApp"><i class="fa fa-trash-o">&nbsp;Delete</i></a>
        <br />
        <br />

        <div class="w3-display-container w3-white table-responsive" style="height:700px;" id="searchApp">
            <div class="form-group">
                <div class="col-md-12">
                    <br />
                    <asp:DropDownList runat="server" CssClass="search-ddl font-weight-bold border-0" ID="ddlSearchType">
                        <asp:ListItem Selected="True">By Appointment Date</asp:ListItem>
                        <asp:ListItem>By Appointment Time</asp:ListItem>
                        <asp:ListItem>By Appointment ID</asp:ListItem>
                        <asp:ListItem>By Patient ID</asp:ListItem>
                        <asp:ListItem>By Staff Register</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-md-12">
                    <br />
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox"></asp:TextBox>
                    <a href="#" class="w3-button w3-round-large button-primary font-weight-bold" id="btnSearch" style="margin-left:20px">Search</a>
                </div>

                <div class="col-md-12">
                    <br />
                    <div class="w3-display-container w3-dark-grey table-responsive" style="height:500px; width:67%; border-radius:10px; margin-left:25px;" id="lblResult">
                        <div class="w3-display-bottomleft w3-padding" id="divResultFound">
                            <asp:Label ID="lblResultFound" runat="server" Text="Result Found" Font-Bold="True" ForeColor="Black"></asp:Label>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    </asp:Content>

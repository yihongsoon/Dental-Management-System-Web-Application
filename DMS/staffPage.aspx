<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/dmsMasterpage.Master" CodeBehind="staffPage.aspx.cs" Inherits="DMS.staffPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <style type="text/css">
        .ddl {
            border: 2px solid #3f6ad8;
            border-radius: 5px;
            padding: 3px;
            color: #3f6ad8;
        }
    </style>
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div>
                    Staff
                        <div class="page-title-subheading">
                            Manage Staff Details Here
                        </div>
                </div>
            </div>
        </div>
    </div>
    <ul class="body-tabs body-tabs-layout tabs-animated body-tabs-animated nav">
        <li class="nav-item"> 
            <asp:LinkButton ID="lnkSearch" CssClass="nav-link show active" OnClick="lnkSearch_Click" runat="server"><span>Search</span></asp:LinkButton>
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkAdd" CssClass="nav-link show" OnClick="lnkAdd_Click" runat="server"><span>Add</span></asp:LinkButton>
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkUpdate" CssClass="nav-link show" OnClick="lnkUpdate_Click" runat="server"><span>Update</span></asp:LinkButton>
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkDelete" CssClass="nav-link show" OnClick="lnkDelete_Click" runat="server"><span>Delete</span></asp:LinkButton>
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkAttendance" CssClass="nav-link show" OnClick="lnkAttendance_Click" runat="server"><span>Attendance</span></asp:LinkButton>
        </li>
    </ul>
    <div class="tab-content">
        <asp:Panel ID="tabstaffSearch" Visible="true" runat="server">
             <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="ddlSearchCriteria" CssClass="ddl" runat="server">
                                            <asp:ListItem Value="name" Selected="true" Text="By Name"></asp:ListItem>
                                            <asp:ListItem Value="contact" Text="By Contact"></asp:ListItem>
                                            <asp:ListItem Value="id" Text="By ID"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:TextBox ID="txtSearch" CssClass="form-control" placeholder="Type and search" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnSearchProfile" CssClass="mt-2 btn btn-primary" runat="server" Text="Search"></asp:Button>
                                        <asp:Button ID="btnBackSearch" CssClass="mt-2 btn btn-primary" runat="server" Visible="false" Text="Back"></asp:Button>
                                    </div>
                                </div>
                            </div>
                            <div class="alert alert-info fade show" runat="server" id="noResult" visible="false">
                                <asp:Label runat="server" Text="No Result Found"></asp:Label>
                            </div>
                            <asp:Panel runat="server" ID="pnlsearchResult" Visible="false">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label1" runat="server" Text="ID"></asp:Label>
                                            <asp:TextBox ID="txtID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                            <%--<asp:Label ID="emptyEmail" runat="server" CssClass="invalid-feedbackEmptyField" Visible="false" Text="Please Fill In The Field."></asp:Label>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label9" runat="server" Text="Position"></asp:Label>
                                            <asp:TextBox ID="txtPosition" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label2" runat="server" Text="Name"></asp:Label>
                                            <asp:TextBox ID="txtName" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label3" runat="server" Text="IC"></asp:Label>
                                            <asp:TextBox ID="txtIC" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label4" runat="server" Text="Age"></asp:Label>
                                            <asp:TextBox ID="txtAge" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label5" runat="server" Text="Gender"></asp:Label>
                                            <asp:TextBox ID="txtGender" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label6" runat="server" Text="Email"></asp:Label>
                                            <asp:TextBox ID="txtEmail" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label7" runat="server" Text="Contact No."></asp:Label>
                                            <asp:TextBox ID="txtContactNo" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label12" runat="server" Text="Address"></asp:Label>
                                            <asp:TextBox ID="txtAddress1" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label13" runat="server" Text="Address 2"></asp:Label>
                                            <asp:TextBox ID="txtAddress2" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label14" runat="server" Text="City"></asp:Label>
                                            <asp:TextBox ID="txtCity" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label15" runat="server" Text="State"></asp:Label>
                                            <asp:TextBox ID="txtState" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label16" runat="server" Text="Zip"></asp:Label>
                                            <asp:TextBox ID="txtZip" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="tabstaffAdd" Visible="false" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label8" runat="server" Text="ID"></asp:Label>
                                        <asp:TextBox ID="txtAddID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>                                        
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label17" runat="server" Text="Position"></asp:Label>
                                        <asp:DropDownList ID="ddlAddPosition" Enabled="true" CssClass="ddl form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="nurse">Nurse</asp:ListItem>
                                            <asp:ListItem  Value="dentist">Dentist</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label18" runat="server" Text="Name"></asp:Label>
                                        <asp:TextBox ID="txtAddName" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtAddName" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="^[a-zA-Z][a-zA-Z ]*$" ErrorMessage="Only Alphabets are allowed"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtAddName" ForeColor="Red" SetFocusOnError="true" EnableClientScript="False" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label19" runat="server" Text="IC"></asp:Label>
                                        <asp:TextBox ID="txtAddIC" Enabled="true"  MaxLength="12"  Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtAddIC" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="\d{12}" ErrorMessage="Invalid IC "></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtAddIC" ForeColor="Red" SetFocusOnError="true" EnableClientScript="False" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                    </div>                                    
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label20" runat="server" Text="Age"></asp:Label>
                                        <asp:TextBox ID="txtAddAge" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidator1" SetFocusOnError="true" MinimumValue="1" MaximumValue="200" EnableClientScript="False" ForeColor="Red" ControlToValidate="txtAddAge" runat="server" ErrorMessage="Not a valid age"></asp:RangeValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtAddAge" ForeColor="Red" SetFocusOnError="true" EnableClientScript="False" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label21" runat="server" Text="Gender"></asp:Label>
                                        <asp:DropDownList ID="ddlAddGender" Enabled="true" CssClass="ddl form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="male">Male</asp:ListItem>
                                            <asp:ListItem  Value="female">Female</asp:ListItem>
                                            <asp:ListItem  Value="other">Other</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label22" runat="server" Text="Email"></asp:Label>
                                        <asp:TextBox ID="txtAddEmail" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtAddEmail" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$" ErrorMessage="Wrong Email Format"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtAddEmail" ForeColor="Red" SetFocusOnError="true" EnableClientScript="False" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label23" runat="server" Text="Contact No."></asp:Label>
                                        <asp:TextBox ID="txtAddContactNo" Enabled="true" MaxLength="10" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtAddContactNo" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="\d{10}" ErrorMessage="Invalid Phone Number "></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtAddContactNo" ForeColor="Red" SetFocusOnError="true" EnableClientScript="False" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label24" runat="server" Text="Address"></asp:Label>
                                        <asp:TextBox ID="txtAddAddress1" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtAddAddress1" ForeColor="Red" SetFocusOnError="true" EnableClientScript="False" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label25" runat="server" Text="Address 2"></asp:Label>
                                        <asp:TextBox ID="txtAddAddress2" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label26" runat="server" Text="City"></asp:Label>
                                        <asp:TextBox ID="txtAddCity" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtAddCity" ForeColor="Red" SetFocusOnError="true" EnableClientScript="False" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label27" runat="server" Text="State"></asp:Label>
                                        <asp:TextBox ID="txtAddState" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtAddState" ForeColor="Red" SetFocusOnError="true" EnableClientScript="False" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label28" runat="server" Text="Zip"></asp:Label>
                                        <asp:TextBox ID="txtAddZip" Enabled="true" Text="" runat="server" MaxLength="5" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtAddZip" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="\d{5}" ErrorMessage="Invalid Zip Code"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtAddZip" ForeColor="Red" SetFocusOnError="true" EnableClientScript="False" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Button ID="btnAdd" CssClass="mt-2 btn btn-primary" OnClick="btnAdd_Click" runat="server" Text="Add" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="tabstaffUpdate" Visible="false" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="ddlUpdateSearchCriteria" CssClass="ddl" runat="server">
                                            <asp:ListItem Value="name" Selected="true" Text="By Name"></asp:ListItem>
                                            <asp:ListItem Value="contact" Text="By Contact"></asp:ListItem>
                                            <asp:ListItem Value="id" Text="By ID"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:TextBox ID="txtUpdateSearch" CssClass="form-control" placeholder="Type and search" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnUpdateSearch" CssClass="mt-2 btn btn-primary" runat="server" Text="Search"></asp:Button>
                                        <asp:Button ID="btnUpdateBack" CssClass="mt-2 btn btn-primary" runat="server" Visible="false" Text="Back"></asp:Button>
                                    </div>
                                </div>
                            </div>
                            <div class="alert alert-info fade show" runat="server" id="Div1" visible="false">
                                <asp:Label runat="server" Text="No Result Found"></asp:Label>
                            </div>
                            <asp:Panel runat="server" ID="pnlUpdateSearchResult" Visible="false">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label10" runat="server" Text="ID"></asp:Label>
                                            <asp:TextBox ID="txtUpdateID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                            <%--<asp:Label ID="emptyEmail" runat="server" CssClass="invalid-feedbackEmptyField" Visible="false" Text="Please Fill In The Field."></asp:Label>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label11" runat="server" Text="Position"></asp:Label>
                                            <asp:TextBox ID="txtUpdatePosition" Enabled="true" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label29" runat="server" Text="Name"></asp:Label>
                                            <asp:TextBox ID="txtUpdateName" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label30" runat="server" Text="IC"></asp:Label>
                                            <asp:TextBox ID="txtUpdateIC" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label31" runat="server" Text="Age"></asp:Label>
                                            <asp:TextBox ID="txtUpdateAge" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label32" runat="server" Text="Gender"></asp:Label>
                                            <asp:TextBox ID="txtUpdateGender" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label33" runat="server" Text="Email"></asp:Label>
                                            <asp:TextBox ID="txtUpdateEmail" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label34" runat="server" Text="Contact No."></asp:Label>
                                            <asp:TextBox ID="txtUpdateContact" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label35" runat="server" Text="Address"></asp:Label>
                                            <asp:TextBox ID="txtUpdateAddress1" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label36" runat="server" Text="Address 2"></asp:Label>
                                            <asp:TextBox ID="txtUpdateAddress2" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label37" runat="server" Text="City"></asp:Label>
                                            <asp:TextBox ID="txtUpdateCity" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label38" runat="server" Text="State"></asp:Label>
                                            <asp:TextBox ID="txtUpdateState" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label39" runat="server" Text="Zip"></asp:Label>
                                            <asp:TextBox ID="txtUpdateZip" Enabled="true" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnUpdate" CssClass="mt-2 btn btn-primary" runat="server" Text="Update" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="tabstaffDelete" Visible="false" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="DropDownList1" CssClass="ddl" runat="server">
                                            <asp:ListItem Value="name" Selected="true" Text="By Name"></asp:ListItem>
                                            <asp:ListItem Value="contact" Text="By Contact"></asp:ListItem>
                                            <asp:ListItem Value="id" Text="By ID"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Type and search" runat="server"></asp:TextBox>
                                        <asp:Button ID="Button1" CssClass="mt-2 btn btn-primary" runat="server" Text="Search"></asp:Button>
                                        <asp:Button ID="Button2" CssClass="mt-2 btn btn-primary" runat="server" Visible="false" Text="Back"></asp:Button>
                                    </div>
                                </div>
                            </div>
                            <div class="alert alert-info fade show" runat="server" id="Div2" visible="false">
                                <asp:Label runat="server" Text="No Result Found"></asp:Label>
                            </div>
                            <asp:Panel runat="server" ID="pnlDeleteSearchResult" Visible="false">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label40" runat="server" Text="ID"></asp:Label>
                                            <asp:TextBox ID="txtDeleteID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                            <%--<asp:Label ID="emptyEmail" runat="server" CssClass="invalid-feedbackEmptyField" Visible="false" Text="Please Fill In The Field."></asp:Label>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label41" runat="server" Text="Position"></asp:Label>
                                            <asp:TextBox ID="txtDeletePosition" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label42" runat="server" Text="Name"></asp:Label>
                                            <asp:TextBox ID="txtDeleteName" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label43" runat="server" Text="IC"></asp:Label>
                                            <asp:TextBox ID="txtDeleteIC" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label44" runat="server" Text="Age"></asp:Label>
                                            <asp:TextBox ID="txtDeleteAge" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label45" runat="server" Text="Gender"></asp:Label>
                                            <asp:TextBox ID="txtDeleteGender" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label46" runat="server" Text="Email"></asp:Label>
                                            <asp:TextBox ID="txtDeleteEmail" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label47" runat="server" Text="Contact No."></asp:Label>
                                            <asp:TextBox ID="txtDeleteContactNo" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label48" runat="server" Text="Address"></asp:Label>
                                            <asp:TextBox ID="txtDeleteAddress1" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label49" runat="server" Text="Address 2"></asp:Label>
                                            <asp:TextBox ID="txtDeleteAddress2" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label50" runat="server" Text="City"></asp:Label>
                                            <asp:TextBox ID="txtDeleteCity" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label51" runat="server" Text="State"></asp:Label>
                                            <asp:TextBox ID="txtDeleteState" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label52" runat="server" Text="Zip"></asp:Label>
                                            <asp:TextBox ID="txtDeleteZip" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnDelete" CssClass="mt-2 btn btn-primary" runat="server" Text="Delete" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="tabstaffAttendance" Visible="false" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="ddlAttendanceSearchCriteria" CssClass="ddl" runat="server">
                                            <asp:ListItem Value="name" Selected="true" Text="By Name"></asp:ListItem>
                                            <asp:ListItem Value="contact" Text="By Contact"></asp:ListItem>
                                            <asp:ListItem Value="id" Text="By ID"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:TextBox ID="txtAttendanceSearch" CssClass="form-control" placeholder="Type and search" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnAttendanceSearch" CssClass="mt-2 btn btn-primary" runat="server" Text="Search"></asp:Button>
                                        <asp:Button ID="btnAttendanceBack" CssClass="mt-2 btn btn-primary" runat="server" Visible="false" Text="Back"></asp:Button>
                                    </div>
                                </div>
                            </div>
                            <div class="alert alert-info fade show" runat="server" id="Div3" visible="false">
                                <asp:Label runat="server" Text="No Result Found"></asp:Label>
                            </div>
                            <asp:Panel runat="server" ID="pnlAttendanceSearchResult" Visible="false">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label53" runat="server" Text="ID"></asp:Label>
                                            <asp:TextBox ID="txtAttendanceID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                            <%--<asp:Label ID="emptyEmail" runat="server" CssClass="invalid-feedbackEmptyField" Visible="false" Text="Please Fill In The Field."></asp:Label>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label54" runat="server" Text="Position"></asp:Label>
                                            <asp:TextBox ID="txtAttendancePosition" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label55" runat="server" Text="Name"></asp:Label>
                                            <asp:TextBox ID="txtAttendanceName" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label56" runat="server" Text="IC"></asp:Label>
                                            <asp:TextBox ID="txtAttendanceIC" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label57" runat="server" Text="Month"></asp:Label>
                                            <asp:TextBox ID="txtAttendanceMonth" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label58" runat="server" Text="Attendance No."></asp:Label>
                                            <asp:TextBox ID="txtAttendanceNo" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label59" runat="server" Text="Leave Taken"></asp:Label>
                                            <asp:TextBox ID="txtAttendanceLeave" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="label60" runat="server" Text="Off Day"></asp:Label>
                                            <asp:TextBox ID="txtAttendanceOffDay" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Button ID="btnGenerateQR" runat="server" CssClass="mt-2 btn btn-primary" Text="Generate QR Code" />
                                        <asp:Button ID="btnAttendanceDetails" runat="server" CssClass="mt-2 btn btn-primary" Text="Details" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

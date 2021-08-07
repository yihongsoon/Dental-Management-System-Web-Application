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
            <a role="tab" class="nav-link show active" id="tab-0" data-toggle="tab" href="#tab-staffSearch" aria-selected="true">
                <span>Search</span>
            </a>
        </li>
        <li class="nav-item">
            <a role="tab" class="nav-link show" id="tab-1" data-toggle="tab" href="#tab-SearchAdd" aria-selected="false">
                <span>Add</span>
            </a>            
        </li>
        <li class="nav-item">
            <a role="tab" class="nav-link show" id="tab-2" data-toggle="tab" href="#tab-content-1" aria-selected="false">
                <span>Update</span>
            </a>            
        </li>
        <li class="nav-item">
            <a role="tab" class="nav-link show" id="tab-3" data-toggle="tab" href="#tab-content-1" aria-selected="false">
                <span>Delete</span>
            </a>            
        </li>
        <li class="nav-item">
            <a role="tab" class="nav-link show" id="tab-4" data-toggle="tab" href="#tab-content-1" aria-selected="false">
                <span>Attendance</span>
            </a>            
        </li>
    </ul>
    <div class="tab-content">
        <div class="tab-pane tabs-animation fade active show" id="tab-staffSearch" role="tabpanel">
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
                            <div class="alert alert-info fade show" runat="server" id="loginFail" visible="false">
                                <asp:Label runat="server" Text="No Result Found"></asp:Label>
                            </div>
                            <asp:Panel runat="server" ID="searchResult" Visible="true">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="main-card mb-3 card">
                                            <div class="card-body">
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
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="tab-pane tabs-animation fade" id="tab-SearchAdd" role="tabpanel">

            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="position-relative form-group">
                                                            <asp:Label ID="label8" runat="server" Text="ID"></asp:Label>
                                                            <asp:TextBox ID="TextBox1" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                                            <%--<asp:Label ID="emptyEmail" runat="server" CssClass="invalid-feedbackEmptyField" Visible="false" Text="Please Fill In The Field."></asp:Label>--%>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="position-relative form-group">
                                                            <asp:Label ID="label17" runat="server" Text="Position"></asp:Label>
                                                            <asp:TextBox ID="TextBox2" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="position-relative form-group">
                                                            <asp:Label ID="label18" runat="server" Text="Name"></asp:Label>
                                                            <asp:TextBox ID="TextBox3" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="position-relative form-group">
                                                            <asp:Label ID="label19" runat="server" Text="IC"></asp:Label>
                                                            <asp:TextBox ID="TextBox4" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="position-relative form-group">
                                                            <asp:Label ID="label20" runat="server" Text="Age"></asp:Label>
                                                            <asp:TextBox ID="TextBox5" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="position-relative form-group">
                                                            <asp:Label ID="label21" runat="server" Text="Gender"></asp:Label>
                                                            <asp:TextBox ID="TextBox6" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="position-relative form-group">
                                                            <asp:Label ID="label22" runat="server" Text="Email"></asp:Label>
                                                            <asp:TextBox ID="TextBox7" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="position-relative form-group">
                                                            <asp:Label ID="label23" runat="server" Text="Contact No."></asp:Label>
                                                            <asp:TextBox ID="TextBox8" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="position-relative form-group">
                                                            <asp:Label ID="label24" runat="server" Text="Address"></asp:Label>
                                                            <asp:TextBox ID="TextBox9" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="position-relative form-group">
                                                            <asp:Label ID="label25" runat="server" Text="Address 2"></asp:Label>
                                                            <asp:TextBox ID="TextBox10" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="position-relative form-group">
                                                            <asp:Label ID="label26" runat="server" Text="City"></asp:Label>
                                                            <asp:TextBox ID="TextBox11" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="position-relative form-group">
                                                            <asp:Label ID="label27" runat="server" Text="State"></asp:Label>
                                                            <asp:TextBox ID="TextBox12" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="position-relative form-group">
                                                            <asp:Label ID="label28" runat="server" Text="Zip"></asp:Label>
                                                            <asp:TextBox ID="TextBox13" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="tab-pane tabs-animation fade" id="checkOutScreen" role="tabpanel">
            <div class="row">
                <div class="col-md-6">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label10" runat="server" Text="IC"></asp:Label>
                                        <asp:TextBox ID="txtCheckOutIC" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label11" runat="server" Text="Password"></asp:Label>
                                        <asp:TextBox ID="txtCheckOutPassword" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Button ID="btnCheckOut" runat="server" CssClass="mt-2 btn btn-primary" Text="Check Out" />
                                    <div class="row">
                                        <div class="col-md-5">
                                            <asp:LinkButton ID="lnkbtnQRCheckOut" runat="server" Text="QR Code">
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="tab-pane tabs-animation fade" id="DetailsScreen" role="tabpanel">
            <div class="row">
                <div class="col-md-4">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <asp:Button ID="btnGenerateExcel" runat="server" CssClass="mt-2 btn btn-primary" Text="Generate as Excel" />
                            <asp:Button ID="btnGeneratePDF" runat="server" CssClass="mt-2 btn btn-primary" Text="Generate as PDF" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

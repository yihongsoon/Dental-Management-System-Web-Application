<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/dmsMasterpage.Master" CodeBehind="patientManagement.aspx.cs" Inherits="DMS.PatientManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <style type="text/css">
        .ddl
        {
            border:2px solid #3f6ad8;
            border-radius:5px;
            padding:3px;
            color: #3f6ad8;
        }
        .btn-bottom{
            position:absolute;
            right:0;
            bottom:0;
        }
    </style>

    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div>
                    Patient Management
                        <div class="page-title-subheading">
                            Manage Patient Details Here
                        </div>
                </div>
            </div>
        </div>
    </div>

    <ul class="body-tabs body-tabs-layout tabs-animated body-tabs-animated nav">
        <li class="nav-item">
            <a role="tab" class="nav-link show active" id="tab-search" data-toggle="tab" href="#tab-content-search" aria-selected="true">
                <span>Search</span>
            </a>
        </li>

        <li class="nav-item">
            <a role="tab" class="nav-link show" id="tab-add" data-toggle="tab" href="#tab-content-add" aria-selected="false">
                <span>Add</span>
            </a>            
        </li>

        <li class="nav-item">
            <a role="tab" class="nav-link show" id="tab-update" data-toggle="tab" href="#tab-content-update" aria-selected="false">
                <span>Update</span>
            </a>            
        </li>

        <li class="nav-item">
            <a role="tab" class="nav-link show" id="tab-delete" data-toggle="tab" href="#tab-content-delete" aria-selected="false">
                <span>Delete</span>
            </a>            
        </li>
    </ul>

    <div class="tab-content">

        <div class="tab-pane tabs-animation fade active show" id="tab-content-search" role="tabpanel">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="ddlSearchType"  CssClass="ddl" runat="server">
                                            <asp:ListItem Value="name" Selected="true" Text="By Name"></asp:ListItem>
                                            <asp:ListItem Value="contactNo" Text="By Contact No."></asp:ListItem>
                                            <asp:ListItem Value="patientId" Text="By Patient ID"></asp:ListItem>
                                            <asp:ListItem Value="icNo" Text="By IC No."></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row form-inline">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <div class="search-wrapper active">
                                            <div class="input-holder">
                                                <input type="text" class="search-input" placeholder="Enter search criteria" id="txtSearchType">
                                            </div>
                                        </div>
                                        <asp:Button ID="btnSearchType" CssClass="mt-2 btn btn-primary" runat="server" Text="Search"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="tab-pane tabs-animation fade active show" id="tab-content-add" role="tabpanel">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblPatientID" runat="server" Text="Patient ID :"></asp:Label>
                                        <asp:TextBox ID="txtPatientID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblIcNo" runat="server" Text="Identification Card No. :"></asp:Label>
                                        <asp:TextBox ID="txtIcNo" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblName" runat="server" Text="Name :"></asp:Label>
                                        <asp:TextBox ID="txtName" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblAge" runat="server" Text="Age :"></asp:Label>
                                        <asp:TextBox ID="txtAge" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblGender" runat="server" Text="Gender :"></asp:Label>
                                        <asp:TextBox ID="txtGender" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblContactNo" runat="server" Text="Contact No. :"></asp:Label>
                                        <asp:TextBox ID="txtContactNo" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-10">
                                    <div class="position-relative">
                                        <asp:Label ID="lblAllergies" runat="server" Text="Allergies :"></asp:Label><br />
                                        <asp:TextBox ID="txtAllergies" runat="server" TextMode="MultiLine" Height="150px" Width="70%" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="mt-2 btn btn-primary btn-bottom" Font-Bold="true" Font-Size="Large" Width="80px"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>

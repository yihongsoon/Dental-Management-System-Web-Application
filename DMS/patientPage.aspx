<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/dmsMasterpage.Master" CodeBehind="patientPage.aspx.cs" Inherits="DMS.patientPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <style type="text/css">
        .ddl {
            border: 2px solid #3f6ad8;
            border-radius: 5px;
            padding: 3px;
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
            <a role="tab" class="nav-link show active" id="tab-patient-search" data-toggle="tab" href="#tab-patientSearch" aria-selected="true">
                <span>Search</span>
            </a>
        </li>
        <li class="nav-item">
            <a role="tab" class="nav-link show" id="tab-patient-add" data-toggle="tab" href="#tab-patientAdd" aria-selected="false">
                <span>Add</span>
            </a>
        </li>
        <li class="nav-item">
            <a role="tab" class="nav-link show" id="tab-patient-update" data-toggle="tab" href="#tab-patientUpdate" aria-selected="false">
                <span>Update</span>
            </a>
        </li>
        <li class="nav-item">
            <a role="tab" class="nav-link show" id="tab-patient-delete" data-toggle="tab" href="#tab-patientDelete" aria-selected="false">
                <span>Delete</span>
            </a>
        </li>
    </ul>

    <div class="tab-content">
        <div class="tab-pane tabs-animation fade active show" id="tab-patientSearch" role="tabpanel">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="ddlSearchType" CssClass="ddl" runat="server">
                                            <asp:ListItem Value="name" Selected="true" Text="By Name"></asp:ListItem>
                                            <asp:ListItem Value="icNo" Text="By IC No."></asp:ListItem>
                                            <asp:ListItem Value="patientID" Text="By Patient ID"></asp:ListItem>
                                            <asp:ListItem Value="contact" Text="By Contact No."></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:TextBox ID="txtSearchType" CssClass="form-control" placeholder="Type and search" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnSearch" CssClass="mt-2 btn btn-primary" runat="server" Text="Search"></asp:Button>
                                        <asp:Button ID="btnBackSearch" CssClass="mt-2 btn btn-primary" runat="server" Visible="false" Text="Back"></asp:Button>
                                    </div>
                                </div>
                            </div>

                            <div class="alert alert-info fade show" runat="server" id="patientSearchNotFound" visible="false">
                                <asp:Label runat="server" Text="No Patient Details Found"></asp:Label>
                            </div>

                            <asp:Panel runat="server" ID="pnlSearchPatient" Visible="false">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblSearchID" runat="server" Text="Patient ID :"></asp:Label>
                                            <asp:TextBox ID="txtSearchID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblSearchIcNo" runat="server" Text="Identification Card No. :"></asp:Label>
                                            <asp:TextBox ID="txtSearchIcNo" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblSearchName" runat="server" Text="Name :"></asp:Label>
                                            <asp:TextBox ID="txtSearchName" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblSearchAge" runat="server" Text="Age :"></asp:Label>
                                            <asp:TextBox ID="txtSearchAge" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblSearchGender" runat="server" Text="Gender :"></asp:Label>
                                            <asp:TextBox ID="txtSearchGender" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblSearchContactNo" runat="server" Text="Contact No. :"></asp:Label>
                                            <asp:TextBox ID="txtSearchContactNo" Text="" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative">
                                            <asp:Label ID="lblSearchAllergies" runat="server" Text="Allergies :"></asp:Label><br />
                                            <asp:TextBox ID="txtSearchAllergies" runat="server" TextMode="MultiLine" Height="150px" Width="100%" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="tab-pane tabs-animation fade" id="tab-patientAdd" role="tabpanel">
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
                                        <asp:TextBox ID="txtAge" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

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
                                <div class="col-md-12">
                                    <div class="position-relative">
                                        <asp:Label ID="lblAllergies" runat="server" Text="Allergies :"></asp:Label><br />
                                        <asp:TextBox ID="txtAllergies" runat="server" TextMode="MultiLine" Height="150px" Width="100%" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Button ID="btnAddPatient" CssClass="mt-2 btn btn-primary" runat="server" Text="Add" Font-Bold="true"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="tab-pane tabs-animation fade" id="tab-patientUpdate" role="tabpanel">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="ddlUpdateSearchType" CssClass="ddl" runat="server">
                                            <asp:ListItem Value="name" Selected="true" Text="By Name"></asp:ListItem>
                                            <asp:ListItem Value="icNo" Text="By IC No."></asp:ListItem>
                                            <asp:ListItem Value="patientID" Text="By Patient ID"></asp:ListItem>
                                            <asp:ListItem Value="contact" Text="By Contact No."></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:TextBox ID="txtUpdatePatientSearch" CssClass="form-control" placeholder="Type and search" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnUpdatePatientSearch" CssClass="mt-2 btn btn-primary" runat="server" Text="Search"></asp:Button>
                                        <asp:Button ID="btnBackUpdate" CssClass="mt-2 btn btn-primary" runat="server" Visible="false" Text="Back"></asp:Button>
                                    </div>
                                </div>
                            </div>

                            <div class="alert alert-info fade show" runat="server" id="patientUpdateNotFound" visible="false">
                                <asp:Label runat="server" Text="No Result Found"></asp:Label>
                            </div>

                            <asp:Panel runat="server" ID="pnlUpdatePatient" Visible="false">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateID" runat="server" Text="Patient ID :"></asp:Label>
                                            <asp:TextBox ID="txtUpdatePatientID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateIcNo" runat="server" Text="Identification Card No. :"></asp:Label>
                                            <asp:TextBox ID="txtUpdateIcNo" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateName" runat="server" Text="Name :"></asp:Label>
                                            <asp:TextBox ID="txtUpdatePatientName" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateAge" runat="server" Text="Age :"></asp:Label>
                                            <asp:TextBox ID="txtUpdatePatientAge" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateGender" runat="server" Text="Gender :"></asp:Label>
                                            <asp:TextBox ID="txtUpdatePatientGender" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateContact" runat="server" Text="Contact No. :"></asp:Label>
                                            <asp:TextBox ID="txtUpdatePatientContact" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative">
                                            <asp:Label ID="lblUpdateAllergy" runat="server" Text="Allergies :"></asp:Label><br />
                                            <asp:TextBox ID="txtUpdateAllergy" runat="server" TextMode="MultiLine" Height="150px" Width="100%" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnUpdatePatient" CssClass="mt-2 btn btn-primary" runat="server" Text="Update" Font-Bold="true"/>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="tab-pane tabs-animation fade" id="tab-patientDelete" role="tabpanel">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="ddlDeleteSearchType" CssClass="ddl" runat="server">
                                            <asp:ListItem Value="name" Selected="true" Text="By Name"></asp:ListItem>
                                            <asp:ListItem Value="icNo" Text="By IC No."></asp:ListItem>
                                            <asp:ListItem Value="patientID" Text="By Patient ID"></asp:ListItem>
                                            <asp:ListItem Value="contact" Text="By Contact No."></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:TextBox ID="txtDeletePatientSearch" CssClass="form-control" placeholder="Type and search" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnDeletePatientSearch" CssClass="mt-2 btn btn-primary" runat="server" Text="Search"></asp:Button>
                                        <asp:Button ID="btnBackDelete" CssClass="mt-2 btn btn-primary" runat="server" Visible="false" Text="Back"></asp:Button>
                                    </div>
                                </div>
                            </div>

                            <div class="alert alert-info fade show" runat="server" id="patientDeleteNotFound" visible="false">
                                <asp:Label runat="server" Text="No Result Found"></asp:Label>
                            </div>

                            <asp:Panel runat="server" ID="pnlDeletePatient" Visible="false">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDeleteID" runat="server" Text="Patient ID :"></asp:Label>
                                            <asp:TextBox ID="txtDeletePatientID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDeleteIcNo" runat="server" Text="Identification Card No. :"></asp:Label>
                                            <asp:TextBox ID="txtDeleteIcNo" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDeleteName" runat="server" Text="Name :"></asp:Label>
                                            <asp:TextBox ID="txtDeletePatientName" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDeleteAge" runat="server" Text="Age :"></asp:Label>
                                            <asp:TextBox ID="txtDeletePatientAge" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDeleteGender" runat="server" Text="Gender :"></asp:Label>
                                            <asp:TextBox ID="lblDeletePatientGender" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDeleteContact" runat="server" Text="Contact No. :"></asp:Label>
                                            <asp:TextBox ID="txtDeletePatientContact" Text="" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative">
                                            <asp:Label ID="lblDeleteAllergy" runat="server" Text="Allergies :"></asp:Label><br />
                                            <asp:TextBox ID="txtDeleteAllergy" runat="server" TextMode="MultiLine" Height="150px" Width="100%" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnDeletePatient" CssClass="mt-2 btn btn-primary" runat="server" Text="Delete" Font-Bold="true"/>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

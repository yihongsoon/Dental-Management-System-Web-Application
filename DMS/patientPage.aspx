<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/dmsMasterpage.Master" CodeBehind="patientPage.aspx.cs" Inherits="DMS.patientPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <style type="text/css">
        .ddl {
            border: 2px solid #3f6ad8;
            border-radius: 5px;
            padding: 3px;
            color: #3f6ad8;
        }

        .btn-visit {
            color: #fff;
            background-color: #6c757d;
            border-color: #6c757d
        }

        .btn-visit:hover {
            color: #fff;
            background-color:Highlight;
            border-color: #545b62
        }

        .btn-visit:focus, .btn-visit.focus {
            box-shadow: 0 0 0 0 rgba(130,138,145,0.5)
        }

        .btn-visit.disabled, .btn-visit:disabled {
            color: #fff;
            background-color: #6c757d;
            border-color: #6c757d
        }

        .btn-visit:not(:disabled):not(.disabled):active, .btn-visit:not(:disabled):not(.disabled).active, .show > .btn-visit.dropdown-toggle {
            color: #fff;
            background-color: #545b62;
            border-color: #4e555b
        }

        .btn-visit:not(:disabled):not(.disabled):active:focus, .btn-visit:not(:disabled):not(.disabled).active:focus, .show > .btn-visit.dropdown-toggle:focus {
            box-shadow: 0 0 0 0 rgba(130,138,145,0.5)
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
            <asp:LinkButton ID="lnkSearchPatient" CssClass="nav-link show active" OnClick="lnkSearchPatient_Click" runat="server"><span>Search</span></asp:LinkButton>
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkAddPatient" CssClass="nav-link show" OnClick="lnkAddPatient_Click" runat="server"><span>Add</span></asp:LinkButton>
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkUpdatePatient" CssClass="nav-link show" OnClick="lnkUpdatePatient_Click" runat="server"><span>Update</span></asp:LinkButton>     
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkDeletePatient" CssClass="nav-link show" OnClick="lnkDeletePatient_Click" runat="server"><span>Delete</span></asp:LinkButton>
        </li>
    </ul>

    <div class="tab-content">
        <asp:Panel ID="tabSearchPatient" Visible="true" runat="server">
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
                                            <asp:ListItem Value="contactNo" Text="By Contact No."></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:TextBox ID="txtSearchType" CssClass="form-control" placeholder="Type and search" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnSearch" CssClass="mt-2 btn btn-primary" runat="server" Text="Search" OnClick="btnSearch_Click"></asp:Button>
                                        <asp:Button ID="btnBackSearch" CssClass="mt-2 btn btn-primary" runat="server" Visible="false" Text="Back" OnClick="btnBackSearch_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>

                            <div class="alert alert-info fade show" runat="server" id="patientSearchNotFound" visible="false">
                                <asp:Label runat="server" Text="No Patient Details Found"></asp:Label>
                            </div>

                            <asp:Panel runat="server" ID="pnlSearchPatient" Visible="false">
                                <hr />
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
                                            <asp:TextBox ID="txtSearchAllergies" runat="server" TextMode="MultiLine" Height="200px" Width="100%" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="tabAddPatient" Visible="false" runat="server">
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
                                        <asp:TextBox ID="txtIcNo" Text="" runat="server" CssClass="form-control" placeHolder="Enter IC Number without '-'"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorIC" ControlToValidate="txtIcNo" SetFocusOnError="true"
                                            EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="\d{12}" ErrorMessage="Invalid IC No.!"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorIC" ControlToValidate="txtIcNo" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblName" runat="server" Text="Name :"></asp:Label>
                                        <asp:TextBox ID="txtName" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" ControlToValidate="txtName" SetFocusOnError="true"
                                            EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="^[a-zA-Z][a-zA-Z ]*$" ErrorMessage="Alphabets Only!"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ControlToValidate="txtName" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblAge" runat="server" Text="Age :"></asp:Label>
                                        <asp:TextBox ID="txtAge" Text="" runat="server" CssClass="form-control" Enabled="true"></asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidatorAge" SetFocusOnError="true" Type="Integer" MinimumValue="1" MaximumValue="150" EnableClientScript="False" ForeColor="Red" 
                                            ControlToValidate="txtAge" runat="server" ErrorMessage="Please enter a valid age!"></asp:RangeValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" ControlToValidate="txtAge" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblGender" runat="server" Text="Gender :"></asp:Label>
                                        <asp:DropDownList ID="ddlAddPatGender" Enabled="true" CssClass="ddl form-control" runat="server">
                                            <asp:ListItem Value="male">Male</asp:ListItem>
                                            <asp:ListItem Value="female">Female</asp:ListItem>
                                            <asp:ListItem Value="other">Other</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" ControlToValidate="ddlAddPatGender" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblContactNo" runat="server" Text="Contact No. :"></asp:Label>
                                        <asp:TextBox ID="txtContactNo" Text="" CssClass="form-control" runat="server" placeHolder="Enter Contact Number without '-'"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorContact" ControlToValidate="txtContactNo" SetFocusOnError="true"
                                            EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="\d{10}" ErrorMessage="Invalid Phone Number!"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorContact" ControlToValidate="txtContactNo" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative">
                                        <asp:Label ID="lblAllergies" runat="server" Text="Allergies :"></asp:Label><br />
                                        <asp:TextBox ID="txtAllergies" runat="server" TextMode="MultiLine" Height="200px" Width="100%" CssClass="form-control" placeHolder="If no allergies please insert '-'"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAllergy" ControlToValidate="txtAllergies" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Button ID="btnAddPatient" CssClass="mt-2 btn btn-primary" runat="server" Text="Add" Font-Bold="true" OnClick="btnAddPatient_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="tabUpdatePatient" Visible="false" runat="server">
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
                                            <asp:ListItem Value="contactNo" Text="By Contact No."></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:TextBox ID="txtUpdatePatientSearch" CssClass="form-control" placeholder="Type and search" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnUpdatePatientSearch" CssClass="mt-2 btn btn-primary" runat="server" Text="Search" OnClick="btnUpdatePatientSearch_Click"></asp:Button>
                                        <asp:Button ID="btnBackUpdate" CssClass="mt-2 btn btn-primary" runat="server" Visible="false" Text="Back" OnClick="btnBackUpdate_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>

                            <div class="alert alert-info fade show" runat="server" id="patientUpdateNotFound" visible="false">
                                <asp:Label runat="server" Text="No Result Found"></asp:Label>
                            </div>

                            <asp:Panel runat="server" ID="pnlUpdatePatient" Visible="false">
                                <hr />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative form-group">
                                            <asp:Button ID="btnAddVisit" CssClass="mt-2 btn btn-visit" runat="server" Text="Add Visit Details" OnClick="btnAddVisit_Click"></asp:Button>
                                            <asp:Button ID="btnViewVisit" CssClass="mt-2 btn btn-visit left" runat="server" Text="View Visit Record" OnClick="btnViewVisit_Click"></asp:Button>
                                        </div>
                                    </div>
                                </div>

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
                                            <asp:TextBox ID="txtUpdateIcNo" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateName" runat="server" Text="Name :"></asp:Label>
                                            <asp:TextBox ID="txtUpdatePatientName" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtUpdatePatientName" SetFocusOnError="true"
                                            EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="^[a-zA-Z][a-zA-Z ]*$" ErrorMessage="Alphabets Only!"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtUpdatePatientName" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateAge" runat="server" Text="Age :"></asp:Label>
                                            <asp:TextBox ID="txtUpdatePatientAge" Text="" runat="server" CssClass="form-control" Enabled="true"></asp:TextBox>
                                            <asp:RangeValidator ID="RangeValidator1" SetFocusOnError="true" Type="Integer" MinimumValue="1" MaximumValue="150" EnableClientScript="False" ForeColor="Red" 
                                            ControlToValidate="txtUpdatePatientAge" runat="server" ErrorMessage="Please enter a valid age!"></asp:RangeValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtUpdatePatientAge" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateGender" runat="server" Text="Gender :"></asp:Label>
                                            <asp:DropDownList ID="ddlUpdateGender" Enabled="true" CssClass="ddl form-control" runat="server">
                                                <asp:ListItem Value="male">Male</asp:ListItem>
                                                <asp:ListItem Value="female">Female</asp:ListItem>
                                                <asp:ListItem Value="other">Other</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateContact" runat="server" Text="Contact No. :"></asp:Label>
                                            <asp:TextBox ID="txtUpdatePatientContact" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtUpdatePatientContact" SetFocusOnError="true"
                                            EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="\d{10,11}" ErrorMessage="Invalid Phone Number!"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtUpdatePatientContact" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative">
                                            <asp:Label ID="lblUpdateAllergy" runat="server" Text="Allergies :"></asp:Label><br />
                                            <asp:TextBox ID="txtUpdateAllergy" runat="server" TextMode="MultiLine" Height="200px" Width="100%" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtUpdateAllergy" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnUpdatePatient" CssClass="mt-2 btn btn-primary" runat="server" Text="Update" Font-Bold="true" OnClick="btnUpdatePatient_Click"/>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="tabDeletePatient" Visible="false" runat="server">
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
                                            <asp:ListItem Value="contactNo" Text="By Contact No."></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:TextBox ID="txtDeletePatientSearch" CssClass="form-control" placeholder="Type and search" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnDeletePatientSearch" CssClass="mt-2 btn btn-primary" runat="server" Text="Search" OnClick="btnDeletePatientSearch_Click"></asp:Button>
                                        <asp:Button ID="btnBackDelete" CssClass="mt-2 btn btn-primary" runat="server" Visible="false" Text="Back" OnClick="btnBackDelete_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>

                            <div class="alert alert-info fade show" runat="server" id="patientDeleteNotFound" visible="false">
                                <asp:Label runat="server" Text="No Result Found"></asp:Label>
                            </div>

                            <asp:Panel runat="server" ID="pnlDeletePatient" Visible="false">
                                <hr />
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
                                            <asp:TextBox ID="txtDeletePatientGender" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
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
                                            <asp:TextBox ID="txtDeleteAllergy" runat="server" TextMode="MultiLine" Height="200px" Width="100%" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnDeletePatient" CssClass="mt-2 btn btn-primary" runat="server" Text="Delete" Font-Bold="true" OnClick="btnDeletePatient_Click" OnClientClick="Confirm()"/>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>

    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");

            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";

            if (confirm("Are you sure to delete selected patient details?")) {
                confirm_value.value = "Yes";
            }
            else {
                confirm_value.value = "No";
            }

            document.forms[0].appendChild(confirm_value);
        }
    </script>

</asp:Content>

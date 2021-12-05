<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/dmsMasterpage.Master" CodeBehind="patientVisitPage.aspx.cs" Inherits="DMS.patientVisitPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <style type="text/css">
        .btn-bck {
            color: #fff;
            background-color: #6c757d;
            border-color: #6c757d
        }

        .btn-bck:hover {
            color: #fff;
            background-color:Highlight;
            border-color: #545b62
        }

        .btn-bck:focus, .btn-bck.focus {
            box-shadow: 0 0 0 0 rgba(130,138,145,0.5)
        }

        .btn-bck.disabled, .btn-bck:disabled {
            color: #fff;
            background-color: #6c757d;
            border-color: #6c757d
        }

        .btn-bck:not(:disabled):not(.disabled):active, .btn-bck:not(:disabled):not(.disabled).active, .show > .btn-bck.dropdown-toggle {
            color: #fff;
            background-color: #545b62;
            border-color: #4e555b
        }

        .btn-bck:not(:disabled):not(.disabled):active:focus, .btn-bck:not(:disabled):not(.disabled).active:focus, .show > .btn-bck.dropdown-toggle:focus {
            box-shadow: 0 0 0 0 rgba(130,138,145,0.5)
        }
    </style>

    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div>
                    Patient Visit Details
                        <div class="page-title-subheading">
                            Add New Patient Visit Details Here
                        </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="position-relative form-group">
                <asp:Button ID="btnBackPage" CssClass="mt-2 btn btn-bck" runat="server" Text="Back" OnClick="btnBackPage_Click"></asp:Button>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="main-card mb-3 card">
                <div class="card-body">
                    <asp:Panel runat="server" ID="pnlAddVisit">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="position-relative form-group">
                                    <asp:Label ID="lblVisitID" runat="server" Text="Visit ID :"></asp:Label>
                                    <asp:TextBox ID="txtVisitID" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="position-relative form-group">
                                    <asp:Label ID="lblPatientID" runat="server" Text="Patient ID :"></asp:Label>
                                    <asp:TextBox ID="txtPatientID" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="position-relative form-group">
                                    <asp:Label ID="lblDateVisit" runat="server" Text="Date Visit :"></asp:Label>
                                    <asp:TextBox ID="txtDateVisit" Text="" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" ControlToValidate="txtDateVisit" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="position-relative form-group">
                                    <asp:Label ID="lblPresence" runat="server" Text="Presence :"></asp:Label>
                                    <%--<asp:TextBox ID="txtPresence" Text="" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddlPresence" Enabled="true" CssClass="ddl form-control" runat="server">
                                            <asp:ListItem Value="present">Present</asp:ListItem>
                                            <asp:ListItem Value="absent">Absent</asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="position-relative form-group">
                                    <asp:Label ID="lblDentisitVisit" runat="server" Text="Dentist Visited :"></asp:Label>
                                    <asp:DropDownList ID="ddlAddDentist" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="position-relative form-group">
                                    <asp:Label ID="lblRoomNo" runat="server" Text="Room No. :"></asp:Label>
                                    <asp:TextBox ID="txtRoomNo" Text="" runat="server" CssClass="form-control" placeHolder="If patient absent, please enter '0'"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorRoom" ControlToValidate="txtRoomNo" SetFocusOnError="true"
                                            EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="\d{1,3}" ErrorMessage="Invalid Room No.!"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRoom" ControlToValidate="txtRoomNo" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="position-relative">
                                    <asp:Label ID="lblDiagnosis" runat="server" Text="Diagnosis :"></asp:Label><br />
                                    <asp:TextBox ID="txtDiagnosis" runat="server" TextMode="MultiLine" Height="200px" Width="100%" CssClass="form-control" placeHolder="If patient absent, please enter '-'"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDiagnosis" ControlToValidate="txtDiagnosis" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="position-relative">
                                    <asp:Label ID="lblMedicineGiven" runat="server" Text="Medicine Given :"></asp:Label><br />
                                    <asp:TextBox ID="txtMedicineGiven" runat="server" TextMode="MultiLine" Height="200px" Width="100%" CssClass="form-control" placeHolder="If patient absent, please enter '-'"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMed" ControlToValidate="txtMedicineGiven" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <asp:Button ID="btnAddVisitDetails" CssClass="mt-2 btn btn-primary" runat="server" Text="Add" Font-Bold="true" OnClick="btnAddVisitDetails_Click"/>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

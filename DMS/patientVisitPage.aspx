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
                            Add new patient visit details here
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
                                    <asp:TextBox ID="txtDateVisit" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="position-relative form-group">
                                    <asp:Label ID="lblPresence" runat="server" Text="Presence :"></asp:Label>
                                    <asp:TextBox ID="txtPresence" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="position-relative form-group">
                                    <asp:Label ID="lblDentisitVisit" runat="server" Text="Dentist Visited :"></asp:Label>
                                    <asp:TextBox ID="txtDentistVisit" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="position-relative form-group">
                                    <asp:Label ID="lblRoomNo" runat="server" Text="Room No. :"></asp:Label>
                                    <asp:TextBox ID="txtRoomNo" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="position-relative">
                                    <asp:Label ID="lblDiagnosis" runat="server" Text="Diagnosis :"></asp:Label><br />
                                    <asp:TextBox ID="txtDiagnosis" runat="server" TextMode="MultiLine" Height="200px" Width="100%" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="position-relative">
                                    <asp:Label ID="lblMedicineGiven" runat="server" Text="Medicine Given :"></asp:Label><br />
                                    <asp:TextBox ID="txtMedicineGiven" runat="server" TextMode="MultiLine" Height="200px" Width="100%" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <asp:Button ID="btnAddVisitDetails" CssClass="mt-2 btn btn-primary" runat="server" Text="Add" Font-Bold="true"/>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/dmsMasterpage.Master" CodeBehind="attendancePage.aspx.cs" Inherits="DMS.attendancePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div>
                    Attendance
                        <div class="page-title-subheading">
                            Manage Your Attendance Here
                        </div>
                </div>
            </div>
        </div>
    </div>
    <ul class="body-tabs body-tabs-layout tabs-animated body-tabs-animated nav">
        <li class="nav-item">
            <asp:LinkButton ID="lnkAttendance" CssClass="nav-link show active" OnClick="lnkAttendance_Click" runat="server"><span>Attendance</span></asp:LinkButton>
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkCheckIn" CssClass="nav-link show" OnClick="lnkCheckIn_Click" runat="server"><span>Check In</span></asp:LinkButton>
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkCheckOut" CssClass="nav-link show" OnClick="lnkCheckOut_Click" runat="server"><span>Check Out</span></asp:LinkButton>
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkDetails" CssClass="nav-link show" OnClick="lnkDetails_Click" runat="server"><span>Details</span></asp:LinkButton>
        </li>
    </ul>
    <div class="tab-content">
        <asp:Panel runat="server" Visible="true" ID="pnlAttendance">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label1" runat="server" Text="ID"></asp:Label>
                                        <asp:TextBox ID="txtID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
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
                                        <asp:Label ID="label4" runat="server" Text="Month"></asp:Label>
                                        <asp:TextBox ID="txtMonth" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label5" runat="server" Text="Total Attendance"></asp:Label>
                                        <asp:TextBox ID="txtTotalAttendance" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label6" runat="server" Text="Leave Taken"></asp:Label>
                                        <asp:TextBox ID="txtLeaveTaken" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label7" runat="server" Text="Off Day"></asp:Label>
                                        <asp:TextBox ID="txtOffDay" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>--%>

                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" Visible="false" ID="pnlCheckIn">
            <div class="row">
                <div class="col-md-6">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="alert alert-danger fade show" runat="server" ID="checkInFail" visible="false">
                                    <asp:Label  runat="server" Text="Incorrect IC or Password! Please Try Again"></asp:Label></div> 
                            <div class="alert alert-warning fade show" id="emptyField" runat="server" visible="false">
                                    <asp:Label runat="server" Text="Please Complete All Field"></asp:Label></div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label111" runat="server" Text="IC"></asp:Label>
                                        <asp:TextBox ID="txtCheckInIC" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label8" runat="server" Text="Password"></asp:Label>
                                        <asp:TextBox ID="txtCheckInPass" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 text-center">
                                    <asp:Button ID="btnCheckIn" runat="server" OnClick="btnCheckIn_Click" CssClass="mt-2 btn btn-primary" Text="Check In" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 text-center">
                                    <asp:LinkButton ID="lnkbtnQRCheckIn" runat="server" Text="QR Code">
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" Visible="false" ID="pnlCheckOut">
            <div class="row">
                <div class="col-md-6">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="alert alert-danger fade show" runat="server" ID="checkOutInvalid" visible="false">
                                    <asp:Label  runat="server" Text="Incorrect IC or Password! Please Try Again"></asp:Label></div> 
                            <div class="alert alert-warning fade show" id="checkOutEmpty" runat="server" visible="false">
                                    <asp:Label runat="server" Text="Please Complete All Field"></asp:Label></div>
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
                                        <asp:TextBox ID="txtCheckOutPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 text-center">
                                    <asp:Button ID="btnCheckOut" runat="server" OnClick="btnCheckOut_Click" CssClass="mt-2 btn btn-primary" Text="Check Out" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 text-center">
                                    <asp:LinkButton ID="lnkbtnQRCheckOut" runat="server" Text="QR Code">
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" Visible="false" ID="pnlDetails">
            <div class="row">
                <div class="col-md-6 text-center">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <asp:Button ID="btnGenerateExcel" runat="server" CssClass="mt-2 btn btn-primary" Text="Generate as Excel" />
                            <asp:Label ID="Label6" runat="server" Text="OR"></asp:Label>
                            <asp:Button ID="btnGeneratePDF" runat="server" CssClass="mt-2 btn btn-primary" Text="Generate as PDF" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

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
    <div class="tab-content">
        <div class="tab-pane tabs-animation fade active show" id="tab-content-0" role="tabpanel">
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
                            <div class="row">
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
                            </div>
                            <a role="tab" class="mt-2 btn btn-primary" id="checkIn" data-toggle="tab" href="#checkInScreen" aria-selected="false">
                                <span>Check In</span>
                            </a>
                            <a role="tab" class="mt-2 btn btn-primary" id="checkOut" data-toggle="tab" href="#checkOutScreen" aria-selected="false">
                                <span>Check Out</span>
                            </a>
                            <a role="tab" class="mt-2 btn btn-primary" id="Detail" data-toggle="tab" href="#DetailsScreen" aria-selected="false">
                                <span>Details</span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="tab-pane tabs-animation fade" id="checkInScreen" role="tabpanel">
            <div class="row">
                <div class="col-md-6">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
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
                                        <asp:TextBox ID="txtCheckInPass" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Button ID="btnCheckIn" runat="server" CssClass="mt-2 btn btn-primary" Text="Check In" />
                                    <div class="row">
                                        <div class="col-md-5">
                                            <asp:LinkButton ID="lnkbtnQRCheckIn" runat="server" Text="QR Code">
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

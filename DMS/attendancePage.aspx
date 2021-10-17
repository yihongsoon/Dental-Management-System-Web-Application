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
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="alert alert-danger fade show" runat="server" id="checkInFail" visible="false">
                                <asp:Label runat="server" Text="Incorrect IC or Password! Please Try Again"></asp:Label>
                            </div>
                            <div class="alert alert-warning fade show" id="emptyField" runat="server" visible="false">
                                <asp:Label runat="server" Text="Please Complete All Field"></asp:Label>
                            </div>
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
                                    <asp:LinkButton ID="lnkbtnQRCheckIn" runat="server" OnClick="lnkbtnQRCheckIn_Click" Text="QR Code">
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
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="alert alert-danger fade show" runat="server" id="checkOutInvalid" visible="false">
                                <asp:Label runat="server" Text="Incorrect IC or Password! Please Try Again"></asp:Label>
                            </div>
                            <div class="alert alert-warning fade show" id="checkOutEmpty" runat="server" visible="false">
                                <asp:Label runat="server" Text="Please Complete All Field"></asp:Label>
                            </div>
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
                                    <asp:LinkButton ID="lnkbtnQRCheckOut" OnClick="lnkbtnQRCheckOut_Click" runat="server" Text="QR Code">
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
                <div class="col-md-12 text-center">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <asp:Button ID="btnGenerateExcel" runat="server" OnClick="btnGenerateExcel_Click" CssClass="mt-2 btn btn-primary" Text="Generate as Excel" />
                            &nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="OR"></asp:Label>&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnGeneratePDF" runat="server" OnClick="btnGeneratePDF_Click" CssClass="mt-2 btn btn-primary" Text="Generate as PDF" />
                            
                            <asp:GridView ID="GridViewPrint" Visible="true" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" PagerStyle-CssClass="pager" CssClass="mydatagrid" OnPageIndexChanging="onPageIndexChanging"
                                   HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" Width="100%">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="workingDate" HeaderText="Working Date" DataFormatString = "{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="checkInTime" HeaderText="Check In" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="checkOutTime" HeaderText="Check Out" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="day" HeaderText="Day" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="month" HeaderText="Month" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="year" HeaderText="Year" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" HorizontalAlign="Center" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" Visible="false" ID="pnlQrCode">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="et_pb_code_inner"></div>
                                    <div class="et_pb_module et_pb_code et_pb_code_1">
                                        <div class="et_pb_code_inner">
                                            <style>
                                                #preview {
                                                    width: 300px;
                                                    height: 300px;
                                                    margin: 0px auto;
                                                }
                                            </style>
                                            <video id="preview"></video>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="et_pb_module et_pb_code et_pb_code_2">
                                        <div class="et_pb_code_inner">
                                            <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
                                            <script src="https://rawgit.com/schmich/instascan-builds/master/instascan.min.js"></script>
                                            <script type="text/javascript">
                                                var scanner = new Instascan.Scanner({ video: document.getElementById('preview'), scanPeriod: 1, mirror: false, refractoryPeriod: 10000 });
                                                scanner.addListener('scan', function (content) {
                                                    Checking(content);
                                                });
                                                Instascan.Camera.getCameras().then(function (cameras) {
                                                    if (cameras.length > 0) {
                                                        scanner.start(cameras[0]);
                                                    } else {
                                                        console.error('No cameras found.');
                                                        alert('No cameras found.');
                                                    }
                                                }).catch(function (e) {
                                                    console.error(e);
                                                    alert(e);
                                                });
                                                function Checking(value) {
                                                    alert("Scanned");                                                    
                                                    document.getElementById('<%=HiddenField1.ClientID%>').value = value;
                                                    document.getElementById('<%=QRCheckIn.ClientID%>').click();
                                                }
                                            </script>
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="display:none;">
                                <asp:Button ID="QRCheckIn" runat="server" OnClick="QRCheckIn_Click" CssClass="mt-2 btn btn-primary" Text="Yes" />
                            </div>                            
                            <asp:Button ID="btnBackCheckIn" runat="server" OnClick="btnBackQRCheckIn_Click" CssClass="mt-2 btn btn-primary" Text="Back" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" Visible="false" ID="pnlQrCodeCheckOut">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="et_pb_code_inner"></div>
                                    <div class="et_pb_module et_pb_code et_pb_code_1">
                                        <div class="et_pb_code_inner">
                                            <style>
                                                #previewCheckOut {
                                                    width: 300px;
                                                    height: 300px;
                                                    margin: 0px auto;
                                                }
                                            </style>
                                            <video id="previewCheckOut"></video>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="et_pb_module et_pb_code et_pb_code_2">
                                        <div class="et_pb_code_inner">  
                                            <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
                                            <script src="https://rawgit.com/schmich/instascan-builds/master/instascan.min.js"></script>
                                            <script type="text/javascript">
                                                var scanner = new Instascan.Scanner({ video: document.getElementById('previewCheckOut'), scanPeriod: 1, mirror: false, refractoryPeriod: 10000 });
                                                scanner.addListener('scan', function (content) {
                                                    Checking(content);
                                                });
                                                Instascan.Camera.getCameras().then(function (cameras) {
                                                    if (cameras.length > 0) {
                                                        scanner.start(cameras[0]);
                                                    } else {
                                                        console.error('No cameras found.');
                                                        alert('No cameras found.');
                                                    }
                                                }).catch(function (e) {
                                                    console.error(e);
                                                    alert(e);
                                                });
                                                function Checking(value) {
                                                    alert("Scanned");
                                                    document.getElementById('<%=HiddenField2.ClientID%>').value = value;
                                                    document.getElementById('<%=btnQRCheckOut.ClientID%>').click();
                                                }
                                            </script>
                                            <asp:HiddenField ID="HiddenField2" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="display:none;">
                                <asp:Button ID="btnQRCheckOut" runat="server" OnClick="btnQRCheckOut_Click" CssClass="mt-2 btn btn-primary" Text="Yes" />
                            </div>                            
                            <asp:Button ID="btnBackQRCheckOut" runat="server" OnClick="btnBackQRCheckOut_Click" CssClass="mt-2 btn btn-primary" Text="Back" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

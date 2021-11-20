<%@ Page Title="" Language="C#" MasterPageFile="~/dmsMasterpage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DMS.Home" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div>
                    Today Appointments
                    <div class="page-title-subheading">
                        Dentist Management System
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">   
        <div class="col-md-12">
            <div class="main-card mb-3 card">
                <div class="card-body">
                    <asp:Panel runat="server" ID="pnlGridToday" Visible="true">
                        <asp:GridView ID="GridViewTodayAppoint" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" PagerStyle-CssClass="pager" CssClass="mydatagrid"
                            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="GridViewTodayAppoint_PageIndexChanging" 
                            DataKeyNames="appointmentID" OnSelectedIndexChanged="GridViewTodayAppoint_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="true" />
                                <asp:BoundField DataField="appointmentID" HeaderText="Appointment ID" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="icNo" HeaderText="Patient IC No." ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="appointmentName" HeaderText="Patient Name" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dentistToVisit" HeaderText="Dentist In Charge" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="appointmentDate" HeaderText="Appointment Date" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="appointmentTime" HeaderText="Appointment Time" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="staffID" HeaderText="Staff Register" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="appointmentPurpose" HeaderText="Appointment Purpose" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </asp:Panel>

                    <asp:Panel runat="server" id="pnlNotFound" Visible="true">
                        <div class="alert alert-info fade show" runat="server" id="todayAppointNotFound">
                            <asp:Label runat="server" Text="No Appointment Today!"></asp:Label>
                        </div>
                    </asp:Panel>
         
                    <asp:Panel runat="server" ID="pnlTodayDetails" Visible="false">
                                <hr />
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnBackToday" CssClass="mt-2 btn btn-primary" runat="server" Text="Back" OnClick="btnBackToday_Click"/>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblAppointID" runat="server" Text="Appointment ID :"></asp:Label>
                                            <asp:TextBox ID="txtAppointID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblIC" runat="server" Text="Patient IC :"></asp:Label>
                                            <asp:TextBox ID="txtIcNo" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblName" runat="server" Text="Patient Name :"></asp:Label>
                                            <asp:TextBox ID="txtName" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDentToVisit" runat="server" Text="Dentist To Visit :"></asp:Label>
                                            <asp:TextBox ID="txtDentToVisit" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblAppointDate" runat="server" Text="Appointment Date :"></asp:Label>
                                            <asp:TextBox ID="txtAppointDate" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblAppointTime" runat="server" Text="Appointment Time :"></asp:Label>
                                            <asp:TextBox ID="txtAppointTime" Text="" runat="server" CssClass="form-control timepicker" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblStaffReg" runat="server" Text="Staff Register :"></asp:Label>
                                            <asp:TextBox ID="txtStaffReg" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative">
                                            <asp:Label ID="lblPurpose" runat="server" Text="Appointment Purpose :"></asp:Label><br />
                                            <asp:TextBox ID="txtPurpose" runat="server" TextMode="MultiLine" Height="200px" Width="100%" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnReminderToday" CssClass="mt-2 btn btn-primary" runat="server" Text="Send Appointment Reminder" Font-Bold="true" OnClick="btnReminderToday_Click"/>
                                    </div>
                                </div>
                            </asp:Panel>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

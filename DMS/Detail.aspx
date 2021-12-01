<%@ Page Title="" Language="C#" MasterPageFile="~/dmsMasterpage.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="DMS.Detail" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div>
                     Appointment Details
                    <div class="page-title-subheading">
                        Dentist Management System
                    </div>
                </div>
            </div>
        </div>
    </div>

    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="btnBackCalendar" CssClass="mt-2 btn btn-primary" runat="server" Text="Back" OnClick="btnBackCalendar_Click"/>
        </div>
    </div>
    <br />

    <ul class="body-tabs body-tabs-layout tabs-animated body-tabs-animated nav">
        <li class="nav-item">
            <asp:LinkButton ID="lnkSendRem" CssClass="nav-link show active" OnClick="lnkSendRem_Click" runat="server"><span>Send Reminder</span></asp:LinkButton>
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkUpdateApp" CssClass="nav-link show" OnClick="lnkUpdateApp_Click" runat="server"><span>Update Appointment</span></asp:LinkButton>
        </li>
    </ul>

    <div class="tab-content">
        <asp:Panel ID="tabSendRem" Visible="true" runat="server">
            <div class="row">   
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
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
                                        <asp:Button ID="btnCalendarReminder" CssClass="mt-2 btn btn-primary" runat="server" Text="Send Appointment Reminder" Font-Bold="true" OnClick="btnCalendarReminder_Click"/>
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="tabUpdateApp" Visible="false" runat="server">
            <div class="row">   
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUptAppointID" runat="server" Text="Appointment ID :"></asp:Label>
                                            <asp:TextBox ID="txtUptAppointID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateIC" runat="server" Text="Patient IC :"></asp:Label>
                                            <asp:TextBox ID="txtUpdateIC" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtUpdateIC" SetFocusOnError="true"
                                                EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="\d{12}" ErrorMessage="Invalid IC No.!"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUpdateIC" ForeColor="Red" SetFocusOnError="true" 
                                                EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateName" runat="server" Text="Patient Name :"></asp:Label>
                                            <asp:TextBox ID="txtUpdateName" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateToVisit" runat="server" Text="Dentist To Visit :"></asp:Label>
                                            <asp:DropDownList ID="ddlUpdateDentist" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateDate" runat="server" Text="Appointment Date :"></asp:Label>
                                            <asp:TextBox ID="txtUpdateDate" runat="server" Text="" CssClass="form-control" TextMode="Date" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtUpdateDate" ForeColor="Red" SetFocusOnError="true" 
                                                EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateTime" runat="server" Text="Appointment Time :"></asp:Label>
                                                <asp:DropDownList ID="ddlUpdateTime" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="Please Select">Please Select A Time</asp:ListItem>
                                                    <asp:ListItem Text="09:30:00" Value="09:30:00">09:30 AM </asp:ListItem>
                                                    <asp:ListItem Text="10:00:00" Value="10:00:00">10:00 AM </asp:ListItem> 
                                                    <asp:ListItem Text="10:30:00" Value="10:30:00">10:30 AM </asp:ListItem>
                                                    <asp:ListItem Text="11:00:00" Value="11:00:00">11:00 AM </asp:ListItem>
                                                    <asp:ListItem Text="11:30:00" Value="11:30:00">11:30 AM </asp:ListItem>
                                                    <asp:ListItem Text="12:00:00" Value="12:00:00">12:00 PM </asp:ListItem>
                                                    <asp:ListItem Text="13:30:00" Value="13:30:00">1:30 PM </asp:ListItem>
                                                    <asp:ListItem Text="14:00:00" Value="14:00:00">2:00 PM </asp:ListItem>
                                                    <asp:ListItem Text="14:30:00" Value="14:30:00">2:30 PM </asp:ListItem>
                                                    <asp:ListItem Text="15:00:00" Value="15:00:00">3:00 PM </asp:ListItem>
                                                    <asp:ListItem Text="15:30:00" Value="15:30:00">3:30 PM </asp:ListItem>
                                                    <asp:ListItem Text="16:00:00" Value="16:00:00">4:00 PM </asp:ListItem>
                                                    <asp:ListItem Text="16:30:00" Value="16:30:00">4:30 PM </asp:ListItem>
                                                    <asp:ListItem Text="17:00:00" Value="17:00:00">5:00 PM </asp:ListItem>
                                                    <asp:ListItem Text="17:30:00" Value="17:30:00">5:30 PM </asp:ListItem>
                                                </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblUpdateStaff" runat="server" Text="Staff Register :"></asp:Label>
                                            <asp:TextBox ID="txtUpdateStaff" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative">
                                            <asp:Label ID="lblUpdatePurpose" runat="server" Text="Appointment Purpose :"></asp:Label><br />
                                            <asp:TextBox ID="txtUpdatePurpose" runat="server" TextMode="MultiLine" Height="200px" Width="100%" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtUpdatePurpose" ForeColor="Red" SetFocusOnError="true" 
                                                EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnUpdateApp" CssClass="mt-2 btn btn-primary" runat="server" Text="Update Appointment" Font-Bold="true" OnClick="btnUpdateApp_Click"/>
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>

    <%--<asp:Panel runat="server" ID="pnlSearchAppointBroad" Visible="false">
                        <asp:GridView ID="GridViewCalendar" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" PagerStyle-CssClass="pager" CssClass="mydatagrid"
                            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="GridViewCalendar_PageIndexChanging" 
                            DataKeyNames="appointmentID" OnSelectedIndexChanged="GridViewCalendar_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
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
                    </asp:Panel>--%>

</asp:Content>

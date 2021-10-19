    <%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/dmsMasterpage.Master" CodeBehind="Appointment.aspx.cs" Inherits="DMS.mainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
     <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <link href="assets/CSS/webform.css" rel="stylesheet" />

    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.css">
    <script src="//cdnjs.cloudflare.com/ajax/libs/timepicker/1.3.5/jquery.timepicker.min.js"></script>       


    <style type="text/css">
        .ddl {
            border: 2px solid #3f6ad8;
            border-radius: 5px;
            padding: 3px;
            color: #3f6ad8;
        }
    </style>

    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div>
                    Appointment
                        <div class="page-title-subheading">
                            Manage Appointment Details Here
                        </div>
                </div>
            </div>
        </div>
    </div>

    <ul class="body-tabs body-tabs-layout tabs-animated body-tabs-animated nav">
        <li class="nav-item">
            <asp:LinkButton ID="lnkSearchAppoint" CssClass="nav-link show active" OnClick="lnkSearchAppoint_Click" runat="server"><span>Search</span></asp:LinkButton>
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkAddAppoint" CssClass="nav-link show" OnClick="lnkAddAppoint_Click" runat="server"><span>Add</span></asp:LinkButton>
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkUpdateAppoint" CssClass="nav-link show" OnClick="lnkUpdateAppoint_Click" runat="server"><span>Update</span></asp:LinkButton>
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkDeleteAppoint" CssClass="nav-link show" OnClick="lnkDeleteAppoint_Click" runat="server"><span>Delete</span></asp:LinkButton>
        </li>
    </ul>

    <div class="tab-content">
        <asp:Panel ID="tabSearchAppoint" Visible="true" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="ddlSearchChoice" CssClass="ddl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSearchChoice_Select">
                                            <asp:ListItem Value="name" Selected="true" Text="By Name"></asp:ListItem>
                                            <asp:ListItem Value="icNo" Text="By Patient IC"></asp:ListItem>
                                            <asp:ListItem Value="appointDate" Text="By Appointment Date"></asp:ListItem>
                                            <asp:ListItem Value="appointTime" Text="By Appointment Time"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:TextBox ID="txtSearchChoice" CssClass="form-control" placeholder="Type and search" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtSearchDate" CssClass="form-control" runat="server" TextMode="Date" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txtSearchTime" CssClass="form-control" runat="server" TextMode="Time" Visible="false"></asp:TextBox>
                                        <asp:Button ID="btnSearch" CssClass="mt-2 btn btn-primary" runat="server" Text="Search" OnClick="btnSearch_Click"></asp:Button>
                                        <asp:Button ID="btnBackSearch" CssClass="mt-2 btn btn-primary" runat="server" Visible="false" Text="Back" OnClick="btnBackSearch_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>

                            <%--<div class="alert alert-info fade show" runat="server" id="appointSearchNotFound" visible="false">
                                <asp:Label runat="server" Text="No Patient Details Found"></asp:Label>
                            </div>--%>

                            <asp:Panel runat="server" ID="pnlSearchAppointBroad" Visible="false">
                                <asp:GridView ID="GridViewSearch" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" PagerStyle-CssClass="pager" CssClass="mydatagrid"
                                   HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="onPageIndexChanging" 
                                    DataKeyNames="appointmentID" OnSelectedIndexChanged="GridViewSearch_SelectedIndexChanged">
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
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnlSearchPatientSpecific" Visible="false">
                                <hr />
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
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="tabAddAppoint" Visible="false" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblAddAppID" runat="server" Text="Appointment ID :"></asp:Label>
                                        <asp:TextBox ID="txtAddAppID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblAddIC" runat="server" Text="Patient IC :"></asp:Label>
                                        <asp:TextBox ID="txtAddIC" Text="" CssClass="form-control" runat="server" placeHolder="Enter IC Number without '-'"  AutoPostBack="true" OnTextChanged="txtAddIC_TextChanged"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorIC" ControlToValidate="txtAddIC" SetFocusOnError="true"
                                            EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="\d{12}" ErrorMessage="Invalid IC No.!"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorIC" ControlToValidate="txtAddIC" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblAddName" runat="server" Text="Patient Name :"></asp:Label>
                                            <asp:TextBox ID="txtAddName" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblAddToVisit" runat="server" Text="Dentist To Visit :"></asp:Label>
                                            <%--<asp:TextBox ID="txtAddToVisit" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" ControlToValidate="txtAddToVisit" SetFocusOnError="true"
                                                EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="^[a-zA-Z][a-zA-Z ]*$" ErrorMessage="Alphabets Only!"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ControlToValidate="txtAddToVisit" ForeColor="Red" SetFocusOnError="true" 
                                                EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>--%>
                                            <asp:DropDownList ID="ddlAddDentist" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblAddDate" runat="server" Text="Appointment Date :"></asp:Label>
                                        <asp:TextBox ID="txtAddDate" runat="server" Text="" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" ControlToValidate="txtAddDate" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblAddTime" runat="server" Text="Appointment Time :"></asp:Label>
                                        <%--<asp:TextBox ID="txtAddTime" Text="" Enabled="true" runat="server" CssClass="form-control timepicker"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlAddTime" runat="server" CssClass="form-control timepicker">
                                            <asp:ListItem Value="Please Select" Selected="True">Please Select A Time</asp:ListItem>
                                            <asp:ListItem Text="09:30 AM" Value="09:30 AM">09:30 AM </asp:ListItem>
                                            <asp:ListItem Text="10:00 AM" Value="10:00 AM">10:00 AM </asp:ListItem> 
                                            <asp:ListItem Text="10:30 AM" Value="10:30 AM">10:30 AM </asp:ListItem>
                                            <asp:ListItem Text="11:00 AM" Value="11:00 AM">11:00 AM </asp:ListItem>
                                            <asp:ListItem Text="11:30 AM" Value="11:30 AM">11:30 AM </asp:ListItem>
                                            <asp:ListItem Text="11:30 AM" Value="11:30 AM">11:30 AM </asp:ListItem>
                                            <asp:ListItem Text="12:00 PM" Value="12:00 PM">12:00 PM </asp:ListItem>
                                            <asp:ListItem Text="1:30 PM" Value="1:30 PM">1:30 PM </asp:ListItem>
                                            <asp:ListItem Text="2:00 PM" Value="2:00 PM">2:00 PM </asp:ListItem>
                                            <asp:ListItem Text="2:30 PM" Value="2:30 PM">2:30 PM </asp:ListItem>
                                            <asp:ListItem Text="3:00 PM" Value="3:00 PM">3:00 PM </asp:ListItem>
                                            <asp:ListItem Text="3:30 PM" Value="3:30 PM">3:30 PM </asp:ListItem>
                                            <asp:ListItem Text="4:00 PM" Value="4:00 PM">4:00 PM </asp:ListItem>
                                            <asp:ListItem Text="4:30 PM" Value="4:30 PM">4:30 PM </asp:ListItem>
                                            <asp:ListItem Text="5:00 PM" Value="5:00 PM">5:00 PM </asp:ListItem>
                                            <asp:ListItem Text="5:30 PM" Value="5:30 PM">5:30 PM </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblAddStaff" runat="server" Text="Staff Register :"></asp:Label>
                                        <asp:TextBox ID="txtAddStaff" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative">
                                        <asp:Label ID="lblAddPurpose" runat="server" Text="Appointment Purpose :"></asp:Label><br />
                                        <asp:TextBox ID="txtAddPurpose" runat="server" TextMode="MultiLine" Height="200px" Width="100%" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPurpose" ControlToValidate="txtAddPurpose" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Button ID="btnAddAppointment" CssClass="mt-2 btn btn-primary" runat="server" Text="Add" Font-Bold="true" OnClick="btnAddAppointment_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="tabUpdateAppoint" Visible="false" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="ddlUpdateSearchType" CssClass="ddl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUpdateSearchType_Select">
                                            <asp:ListItem Value="name" Selected="true" Text="By Name"></asp:ListItem>
                                            <asp:ListItem Value="icNo" Text="By Patient IC"></asp:ListItem>
                                            <asp:ListItem Value="appointDate" Text="By Appointment Date"></asp:ListItem>
                                            <asp:ListItem Value="appointTime" Text="By Appointment Time"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:TextBox ID="txtUpdateAppointSearch" CssClass="form-control" placeholder="Type and search" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtUpdateSearchDate" CssClass="form-control" TextMode="Date" runat="server" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txtUpdateSearchTime" CssClass="form-control" TextMode="Time" runat="server" Visible="false"></asp:TextBox>
                                        <asp:Button ID="btnUpdateAppointSearch" CssClass="mt-2 btn btn-primary" runat="server" Text="Search" OnClick="btnUpdateAppointSearch_Click"></asp:Button>
                                        <asp:Button ID="btnBackUpdate" CssClass="mt-2 btn btn-primary" runat="server" Visible="false" Text="Back" OnClick="btnBackUpdate_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>

                            <div class="alert alert-info fade show" runat="server" id="patientUpdateNotFound" visible="false">
                                <asp:Label runat="server" Text="No Result Found"></asp:Label>
                            </div>

                            <asp:Panel runat="server" ID="pnlUpdateAppointBroad" Visible="false">
        
                                <asp:GridView ID="GridViewUpdate" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" PagerStyle-CssClass="pager" CssClass="mydatagrid"
                                   HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="onPageIndexChangingUpdate" OnSelectedIndexChanged="GridViewUpdate_SelectedIndexChanged">
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
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnlUpdateAppointSpecific" Visible="false">
                                <hr />
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
                                            <asp:TextBox ID="txtUpdateToVisit" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtUpdateToVisit" SetFocusOnError="true"
                                                EnableClientScript="False" runat="server" ForeColor="Red" ValidationExpression="^[a-zA-Z][a-zA-Z ]*$" ErrorMessage="Alphabets Only!"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtUpdateToVisit" ForeColor="Red" SetFocusOnError="true" 
                                                EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblUpdateDate" runat="server" Text="Appointment Date :"></asp:Label>
                                        <asp:TextBox ID="txtUpdateDate" runat="server" Text="" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtUpdateDate" ForeColor="Red" SetFocusOnError="true" 
                                            EnableClientScript="False" runat="server" ErrorMessage="Required Field!"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="lblUpdateTime" runat="server" Text="Appointment Time :"></asp:Label>
                                        <asp:DropDownList ID="ddlUpdateTime" runat="server" CssClass="form-control timepicker">
                                            <asp:ListItem Value="Please Select" Selected="True">Please Select A Time</asp:ListItem>
                                            <asp:ListItem Text="09:30 AM" Value="09:30 AM">09:30 AM </asp:ListItem>
                                            <asp:ListItem Text="10:00 AM" Value="10:00 AM">10:00 AM </asp:ListItem> 
                                            <asp:ListItem Text="10:30 AM" Value="10:30 AM">10:30 AM </asp:ListItem>
                                            <asp:ListItem Text="11:00 AM" Value="11:00 AM">11:00 AM </asp:ListItem>
                                            <asp:ListItem Text="11:30 AM" Value="11:30 AM">11:30 AM </asp:ListItem>
                                            <asp:ListItem Text="11:30 AM" Value="11:30 AM">11:30 AM </asp:ListItem>
                                            <asp:ListItem Text="12:00 PM" Value="12:00 PM">12:00 PM </asp:ListItem>
                                            <asp:ListItem Text="1:30 PM" Value="1:30 PM">1:30 PM </asp:ListItem>
                                            <asp:ListItem Text="2:00 PM" Value="2:00 PM">2:00 PM </asp:ListItem>
                                            <asp:ListItem Text="2:30 PM" Value="2:30 PM">2:30 PM </asp:ListItem>
                                            <asp:ListItem Text="3:00 PM" Value="3:00 PM">3:00 PM </asp:ListItem>
                                            <asp:ListItem Text="3:30 PM" Value="3:30 PM">3:30 PM </asp:ListItem>
                                            <asp:ListItem Text="4:00 PM" Value="4:00 PM">4:00 PM </asp:ListItem>
                                            <asp:ListItem Text="4:30 PM" Value="4:30 PM">4:30 PM </asp:ListItem>
                                            <asp:ListItem Text="5:00 PM" Value="5:00 PM">5:00 PM </asp:ListItem>
                                            <asp:ListItem Text="5:30 PM" Value="5:30 PM">5:30 PM </asp:ListItem>
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
                                    <asp:Button ID="btnUpdateAppoint" CssClass="mt-2 btn btn-primary" runat="server" Text="Update" Font-Bold="true" OnClick="btnUpdateAppoint_Click"/>
                                </div>
                            </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="tabDeleteAppoint" Visible="false" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="ddlDeleteSearchChoice" CssClass="ddl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDeleteSearchChoice_Select">
                                            <asp:ListItem Value="icNo" Selected="true" Text="By Name"></asp:ListItem>
                                            <asp:ListItem Value="name" Text="By Patient IC"></asp:ListItem>
                                            <asp:ListItem Value="appointDate" Text="By Appointment Date"></asp:ListItem>
                                            <asp:ListItem Value="appointTime" Text="By Appointment Time"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:TextBox ID="txtDeleteAppointSearch" CssClass="form-control" placeholder="Type and search" runat="server"></asp:TextBox>
                                        <asp:TextBox ID="txtDeleteAppointDate" CssClass="form-control" textmode="Date" runat="server" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txtDeleteAppointTime" CssClass="form-control" textmode="Time" runat="server" Visible="false"></asp:TextBox>
                                        <asp:Button ID="btnDeleteAppointSearch" CssClass="mt-2 btn btn-primary" runat="server" Text="Search" OnClick="btnDeleteAppointSearch_Click"></asp:Button>
                                        <asp:Button ID="btnBackDelete" CssClass="mt-2 btn btn-primary" runat="server" Visible="false" Text="Back" OnClick="btnBackDelete_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>

                            <div class="alert alert-info fade show" runat="server" id="patientDeleteNotFound" visible="false">
                                <asp:Label runat="server" Text="No Result Found"></asp:Label>
                            </div>

                            <asp:Panel runat="server" ID="pnlDeleteAppointBroad" Visible="false">
                                <asp:GridView ID="GridViewDelete" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" PagerStyle-CssClass="pager" CssClass="mydatagrid"
                                   HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="onPageIndexChangingDelete" OnSelectedIndexChanged="GridViewDelete_SelectedIndexChanged">
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
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </asp:Panel>

                            <asp:Panel runat="server" ID="pnlDeleteAppointSpecific" Visible="false">
                                <hr />
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDeleteAppointID" runat="server" Text="Appointment ID :"></asp:Label>
                                            <asp:TextBox ID="txtDeleteAppointID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDeleteIC" runat="server" Text="Patient IC :"></asp:Label>
                                            <asp:TextBox ID="txtDeleteIC" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDeleteName" runat="server" Text="Patient Name :"></asp:Label>
                                            <asp:TextBox ID="txtDeleteName" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDeleteToVisit" runat="server" Text="Dentist To Visit :"></asp:Label>
                                            <asp:TextBox ID="txtDeleteToVisit" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDeleteDate" runat="server" Text="Appointment Date :"></asp:Label>
                                            <asp:TextBox ID="txtDeleteDate" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDeleteTime" runat="server" Text="Appointment Time :"></asp:Label>
                                            <asp:TextBox ID="txtDeleteTime" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDeleteStaffReg" runat="server" Text="Staff Register :"></asp:Label>
                                            <asp:TextBox ID="txtDeleteStaffReg" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative">
                                            <asp:Label ID="lblDeletePurpose" runat="server" Text="Appointment Purpose :"></asp:Label><br />
                                            <asp:TextBox ID="txtDeletePurpose" runat="server" TextMode="MultiLine" Height="200px" Width="100%" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnDeleteAppointment" CssClass="mt-2 btn btn-primary" runat="server" Text="Delete" Font-Bold="true" OnClick="btnDeleteAppointment_Click"/>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>

    <script type="text/javascript">
        var mains = function () {
            var handleInitTimePicker = function () {
                $('.timepicker').timepicker({
                    timeFormat: 'hh:mm p',
                    interval: 60,
                    minTime: '10',
                    maxTime: '6:00pm',
                    defaultTime: '11',
                    startTime: '10:00',
                    dynamic: false,
                    dropdown: true,
                    scrollbar: true
                });
            };
            return {
                initTimePicker: function () {
                    handleInitTimePicker();
                }
            };
        }();


        mains.initTimePicker();
    </script>


    </asp:Content>

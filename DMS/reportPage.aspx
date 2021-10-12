<%@ Page Language="C#" MasterPageFile="~/dmsMasterpage.Master" AutoEventWireup="true" CodeBehind="reportPage.aspx.cs" Inherits="DMS.reportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
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
                    Report
                        <div class="page-title-subheading">
                            Manage Report Here
                        </div>
                </div>
            </div>
        </div>
    </div>
    <ul class="body-tabs body-tabs-layout tabs-animated body-tabs-animated nav">
        <li class="nav-item">
            <asp:LinkButton ID="lnkSearch" CssClass="nav-link show active" OnClick="lnkSearch_Click" runat="server"><span>Search</span></asp:LinkButton>
        </li>
        <li class="nav-item">
            <asp:LinkButton ID="lnkGenerate" CssClass="nav-link show" OnClick="lnkGenerate_Click" runat="server"><span>Generate</span></asp:LinkButton>
        </li>
    </ul>
    
    <div class="tab-content">
        <asp:Panel runat="server" ID="pnlSearch" Visible="true">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="ddlSearchCriteria" CssClass="ddl" runat="server">
                                            <asp:ListItem Value="name" Selected="true" Text="By Name"></asp:ListItem>
                                            <asp:ListItem Value="category" Text="By Category"></asp:ListItem>
                                            <asp:ListItem Value="year" Text="By Year"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:TextBox ID="txtSearch" CssClass="form-control" placeholder="Type and search" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnSearchReport" CssClass="mt-2 btn btn-primary" runat="server" Text="Search"></asp:Button>
                                        <asp:Button ID="btnBackSearch" CssClass="mt-2 btn btn-primary" runat="server" Visible="false" Text="Back"></asp:Button>
                                    </div>
                                </div>
                            </div>
                            <div class="alert alert-info fade show" runat="server" id="noResult" visible="false">
                                <asp:Label runat="server" Text="No Result Found"></asp:Label>
                            </div>
                            <asp:Panel runat="server" ID="pnlsearchResult" Visible="false">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:GridView ID="gridViewSearchResult" runat="server">
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlGenerate" Visible="false">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:Label runat="server" Text="Category"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="Attendance" Selected="true" Text="Attendance"></asp:ListItem>
                                            <asp:ListItem Value="PatientVisit" Text="Patient Visit"></asp:ListItem>                       
                                            <asp:ListItem Value="Appointment" Text="Appointment"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="ddlYear" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" runat="server">
                                            <asp:ListItem Value="2010" Text="2010"></asp:ListItem>
                                            <asp:ListItem Value="2011" Text="2011"></asp:ListItem>
                                            <asp:ListItem Value="2012" Text="2012"></asp:ListItem>
                                            <asp:ListItem Value="2013" Text="2013"></asp:ListItem>
                                            <asp:ListItem Value="2014" Text="2014"></asp:ListItem>
                                            <asp:ListItem Value="2015" Text="2015"></asp:ListItem>
                                            <asp:ListItem Value="2016" Text="2016"></asp:ListItem>
                                            <asp:ListItem Value="2017" Text="2017"></asp:ListItem>
                                            <asp:ListItem Value="2018" Text="2018"></asp:ListItem>
                                            <asp:ListItem Value="2019" Text="2019"></asp:ListItem>
                                            <asp:ListItem Value="2020" Text="2020"></asp:ListItem>
                                            <asp:ListItem Value="2021" Selected="True" Text="2021"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Button ID="BtnGen1" CssClass="mt-2 btn btn-primary" OnClick="BtnGen1_Click" Height="80px" Width="80px" runat="server" Text="1" />
                                    <asp:Button ID="BtnGen2" CssClass="mt-2 btn btn-primary" OnClick="BtnGen2_Click" Height="80px" Width="80px" runat="server" Text="2" />
                                    <asp:Button ID="BtnGen3" CssClass="mt-2 btn btn-primary" OnClick="BtnGen3_Click" Height="80px" Width="80px" runat="server" Text="3" />
                                    <asp:Button ID="BtnGen4" CssClass="mt-2 btn btn-primary" OnClick="BtnGen4_Click" Height="80px" Width="80px" runat="server" Text="4" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Button ID="BtnGen5" CssClass="mt-2 btn btn-primary" OnClick="BtnGen5_Click" Height="80px" Width="80px" runat="server" Text="5" />
                                    <asp:Button ID="BtnGen6" CssClass="mt-2 btn btn-primary" OnClick="BtnGen6_Click" Height="80px" Width="80px" runat="server" Text="6" />
                                    <asp:Button ID="BtnGen7" CssClass="mt-2 btn btn-primary" OnClick="BtnGen7_Click" Height="80px" Width="80px" runat="server" Text="7" />
                                    <asp:Button ID="BtnGen8" CssClass="mt-2 btn btn-primary" OnClick="BtnGen8_Click" Height="80px" Width="80px" runat="server" Text="8" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Button ID="BtnGen9" CssClass="mt-2 btn btn-primary" OnClick="BtnGen9_Click" Height="80px" Width="80px" runat="server" Text="9" />
                                    <asp:Button ID="BtnGen10" CssClass="mt-2 btn btn-primary" OnClick="BtnGen10_Click" Height="80px" Width="80px" runat="server" Text="10" />
                                    <asp:Button ID="BtnGen11" CssClass="mt-2 btn btn-primary" OnClick="BtnGen11_Click" Height="80px" Width="80px" runat="server" Text="11" />
                                    <asp:Button ID="BtnGen12" CssClass="mt-2 btn btn-primary" OnClick="BtnGen12_Click" Height="80px" Width="80px" runat="server" Text="12" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
    <asp:Panel runat="server" Visible="false" ID="pnlAttendance">
            <div class="row">
                <div class="col-md-6 text-center">
                    <div class="main-card mb-3 card">
                        <div class="card-body">                          
                            <asp:GridView ID="GridViewAttendance" Visible="true" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" PagerStyle-CssClass="pager" CssClass="mydatagrid" OnPageIndexChanging="GridViewAttendance_PageIndexChanging"
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
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>

                           <%--appointment--%>
                            <asp:GridView ID="GridViewAppointment" Visible="true" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" PagerStyle-CssClass="pager" CssClass="mydatagrid" OnPageIndexChanging="GridViewAppointment_PageIndexChanging"
                                   HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" Width="100%">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="appointmentID" HeaderText="Appointment ID" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="appointmentName" HeaderText="Name" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dentistToVisit" HeaderText="Dentist" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="appointmentDate" HeaderText="Date" DataFormatString = "{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="appointmentTime" HeaderText="Time" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="appointmentPurpose" HeaderText="Purpose" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="icNo" HeaderText="IC No" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="staffID" HeaderText="Staff ID" ItemStyle-HorizontalAlign="Center">
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

                             <%--patient visit--%>
                            <asp:GridView ID="GridViewPatientVisit" Visible="true" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" PagerStyle-CssClass="pager" CssClass="mydatagrid" OnPageIndexChanging="GridViewPatientVisit_PageIndexChanging"
                                   HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" Width="100%">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="visitID" HeaderText="Visit ID" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dateVisit" HeaderText="Date Visit" DataFormatString = "{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="status" HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="diagnosis" HeaderText="Diagnosis" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="medicineGiven" HeaderText="Medicine Given" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dentistVisited" HeaderText="Dentist" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="roomNo" HeaderText="Room No" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="totalVisit" HeaderText="Total Visit" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle CssClass="header-centered" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="patientID" HeaderText="Patient ID" ItemStyle-HorizontalAlign="Center">
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
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
</asp:Content>

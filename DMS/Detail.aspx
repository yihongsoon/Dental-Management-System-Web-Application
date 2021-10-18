<%@ Page Title="" Language="C#" MasterPageFile="~/dmsMasterpage.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="DMS.Detail" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div>
                     Appointments Detail
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
                    <asp:Panel runat="server" ID="pnlSearchAppointBroad" Visible="true">
                        <asp:GridView ID="GridViewSearch" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" PagerStyle-CssClass="pager" CssClass="mydatagrid"
                            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="GridViewSearch_PageIndexChanging" DataKeyNames="appointmentID" OnSelectedIndexChanged="GridViewSearch_SelectedIndexChanged">
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
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/dmsMasterpage.Master" AutoEventWireup="true" CodeBehind="PatientVisit.aspx.cs" Inherits="DMS.PatientVisit" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div>
                    Patient Visit Records
                        <div class="page-title-subheading">
                            View Patient Vist Records Here
                        </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-2">
                <asp:Button ID="btnBackPatient" CssClass="mt-2 btn btn-primary" runat="server" Text="Back" OnClick="btnBackPatient_Click"></asp:Button>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-md-12">
            <div class="main-card mb-3 card">
                <div class="card-body">
                    <asp:Panel runat="server" ID="pnlViewVisitBroad" Visible="true">
                        <asp:GridView ID="GridViewVisitRecord" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" PagerStyle-CssClass="pager" CssClass="mydatagrid"
                            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="GridViewVisitRecord_PageIndexChanging" 
                            DataKeyNames="visitID" OnSelectedIndexChanged="GridViewVisitRecord_SelectedIndexChanged" Visible="True">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="true" />
                                <asp:BoundField DataField="visitID" HeaderText="Visit ID" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="icNo" HeaderText="Patient IC No." ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PatientName" HeaderText="Patient Name" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dateVisit" HeaderText="Date Visit" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="status" HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dentistVisited" HeaderText="Dentist Visited" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="roomNo" HeaderText="Room No" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="diagnosis" HeaderText="Diagnosis" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle CssClass="header-centered" />
                                </asp:BoundField>
                                <asp:BoundField DataField="medicineGiven" HeaderText="Medicine Given" ItemStyle-HorizontalAlign="Center">
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

                    <asp:Panel runat="server" ID="pnlNoVisitRec" Visible="false">
                        <div class="alert alert-info fade show" runat="server" id="visitRecordNotFound">
                            <asp:Label runat="server" Text="No Visit Record Available!"></asp:Label>
                        </div>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlViewVisitSpec" Visible="false">
                                <hr />
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnBackVisit" CssClass="mt-2 btn btn-primary" runat="server" Text="Back" OnClick="btnBackVisit_Click"/>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblVisitID" runat="server" Text="Visit ID :"></asp:Label>
                                            <asp:TextBox ID="txtVisitID" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblPatientIC" runat="server" Text="Patient IC No :"></asp:Label>
                                            <asp:TextBox ID="txtPatientIC" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblPatientName" runat="server" Text="Patient Name :"></asp:Label>
                                            <asp:TextBox ID="txtPatientName" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDateVisit" runat="server" Text="Date Visit :"></asp:Label>
                                            <asp:TextBox ID="txtDateVisit" Enabled="false" Text="" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblStatus" runat="server" Text="Appointment Status :"></asp:Label>
                                            <asp:TextBox ID="txtStatus" Text="" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>    
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative">
                                            <asp:Label ID="lblDentVisited" runat="server" Text="Dentist Visited :"></asp:Label><br />
                                            <asp:TextBox ID="txtDentVisited" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="position-relative">
                                            <asp:Label ID="lblRoomNo" runat="server" Text="Room No :"></asp:Label><br />
                                            <asp:TextBox ID="txtRoomNo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblDiagnosis" runat="server" Text="Patient Diagnosis :"></asp:Label>
                                            <asp:TextBox ID="txtDiagnosis" Text="" runat="server" CssClass="form-control" Enabled="false" TextMode="MultiLine" Height="200px" Width="100%"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblMedGiven" runat="server" Text="Medicine Given :"></asp:Label>
                                            <asp:TextBox ID="txtMedGiven" Text="" runat="server" CssClass="form-control" Enabled="false" TextMode="MultiLine" Height="200px" Width="100%"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnDeleteVisit" CssClass="mt-2 btn btn-primary" runat="server" Text="Delete" Font-Bold="true" OnClick="btnDeleteVisit_Click" OnClientClick="Confirm()"/>
                                    </div>
                                </div>
                            </asp:Panel>

                </div>
            </div>
        </div>
    </div>

    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");

            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";

            if (confirm("Are you sure to delete selected patient visit details?")) {
                confirm_value.value = "Yes";
            }
            else {
                confirm_value.value = "No";
            }

            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>

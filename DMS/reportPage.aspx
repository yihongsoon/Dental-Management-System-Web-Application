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
            <a role="tab" class="nav-link show active" id="tab-0" data-toggle="tab" href="#tab-ReportSearch" aria-selected="true">
                <span>Search</span>
            </a>
        </li>
        <li class="nav-item">
            <a role="tab" class="nav-link show" id="tab-1" data-toggle="tab" href="#tab-ReportGenerate" aria-selected="false">
                <span>Generate</span>
            </a>
        </li>
        <li class="nav-item">
            <a role="tab" class="nav-link show" id="tab-2" data-toggle="tab" href="#tab-ReportPrint" aria-selected="false">
                <span>Print</span>
            </a>
        </li>
    </ul>
    <div class="tab-content">
        <div class="tab-pane tabs-animation fade active show" id="tab-ReportSearch" role="tabpanel">
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
        </div>
        <div class="tab-pane tabs-animation fade" id="tab-ReportGenerate" role="tabpanel">
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
                                            <asp:ListItem Value="attendance" Selected="true" Text="Attendance"></asp:ListItem>
                                            <asp:ListItem Value="staff" Text="Staff"></asp:ListItem>
                                            <asp:ListItem Value="patient" Text="Patient"></asp:ListItem>
                                            <asp:ListItem Value="appointment" Text="Appointment"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <asp:Panel runat="server" ID="pnlMonth" Visible="false">
                                
                            </asp:Panel>
                            <div class="row ">
                                <div class="col-md-6 text-right">
                                    <asp:Button ID="btnGenerate" runat="server" CssClass="mt-2 btn btn-primary" Text="Generate" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="tab-pane tabs-animation fade" id="tab-ReportPrint" role="tabpanel">
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
                                        <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="attendance" Selected="true" Text="Attendance"></asp:ListItem>
                                            <asp:ListItem Value="staff" Text="Staff"></asp:ListItem>
                                            <asp:ListItem Value="patient" Text="Patient"></asp:ListItem>
                                            <asp:ListItem Value="appointment" Text="Appointment"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <asp:Panel runat="server" ID="pnlPrintMonth" Visible="false">
                                
                            </asp:Panel>
                            <div class="row ">
                                <div class="col-md-6 text-right">
                                    <asp:Button ID="btnPrint" runat="server" CssClass="mt-2 btn btn-primary" Text="Print" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

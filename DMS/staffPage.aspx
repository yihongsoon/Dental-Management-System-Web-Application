<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/dmsMasterpage.Master" CodeBehind="staffPage.aspx.cs" Inherits="DMS.staffPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <style type="text/css">
        .ddl
        {
            border:2px solid #3f6ad8;
            border-radius:5px;
            padding:3px;
            color: #3f6ad8;
        }
</style>
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div>
                    Staff
                        <div class="page-title-subheading">
                            Manage Staff Details Here
                        </div>
                </div>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <div class="tab-pane tabs-animation fade active show" id="tab-staffSearch" role="tabpanel">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:DropDownList ID="ddlSearchCriteria"  CssClass="ddl" runat="server">
                                            <asp:ListItem Value="name" Selected="true" Text="By Name"></asp:ListItem>
                                            <asp:ListItem Value="contact" Text="By Contact"></asp:ListItem>
                                            <asp:ListItem Value="id" Text="By ID"></asp:ListItem>
                                            <asp:ListItem Value="gender" Text="By Gender"></asp:ListItem>
                                            <asp:ListItem Value="position" Text="By Position"></asp:ListItem>
                                            <asp:ListItem Value="age" Text="By Age"></asp:ListItem>
                                        </asp:DropDownList>                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row form-inline">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <div class="search-wrapper active">
                                            <div class="input-holder">
                                                <input type="text" class="search-input" placeholder="Type and search">
                                            </div>
                                        </div>
                                        <asp:Button ID="btnSearch" CssClass="mt-2 btn btn-primary" runat="server" Text="Search"></asp:Button>
                                    </div>
                                </div>
                            </div>
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

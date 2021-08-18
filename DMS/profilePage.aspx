<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/dmsMasterpage.Master" CodeBehind="profilePage.aspx.cs" Inherits="DMS.profilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div>
                    Profile
                        <div class="page-title-subheading">
                            Profile Information Detail
                        </div>
                </div>
            </div>
        </div>
    </div>
    <%--CONTENT BOBY --%>
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
                                        <%--<asp:Label ID="emptyEmail" runat="server" CssClass="invalid-feedbackEmptyField" Visible="false" Text="Please Fill In The Field."></asp:Label>--%>
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
                                        <asp:Label ID="label4" runat="server" Text="Age"></asp:Label>
                                        <asp:TextBox ID="txtAge" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label5" runat="server" Text="Gender"></asp:Label>
                                        <asp:TextBox ID="txtGender" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label6" runat="server" Text="Email"></asp:Label>
                                        <asp:TextBox ID="txtEmail" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label7" runat="server" Text="Contact No."></asp:Label>
                                        <asp:TextBox ID="txtContactNo" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label8" runat="server" Text="Address"></asp:Label>
                                        <asp:TextBox ID="txtAddress1" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>                               
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label11" runat="server" Text="City"></asp:Label>
                                        <asp:TextBox ID="txtCity" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label12" runat="server" Text="State"></asp:Label>
                                        <asp:TextBox ID="txtState" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>  
                                <div class="col-md-2">
                                    <div class="position-relative form-group">
                                        <asp:Label ID="label13" runat="server" Text="Zip"></asp:Label>
                                        <asp:TextBox ID="txtZip" Enabled="false" Text="" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>  
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/dmsMasterpage.Master" CodeBehind="ChangePassword.aspx.cs" Inherits="DMS.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div>
                    Change Password
                        <div class="page-title-subheading">
                            Change your password.
                        </div>
                </div>
            </div>
        </div>
    </div> 
    <ul class="body-tabs body-tabs-layout tabs-animated body-tabs-animated nav">
        <li class="nav-item">
            <asp:LinkButton ID="lnkLogin" CssClass="nav-link show active" runat="server"><span>Change Password</span></asp:LinkButton>
        </li>
    </ul>
    <div class="tab-content">
        <asp:Panel runat="server" Visible="true" ID="pnlPasswordChange">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">                           
                                <div class="alert alert-danger fade show" runat="server" ID="newPassNotMatch" visible="false">
                                    <asp:Label runat="server" Text="New Password Does not Match!"></asp:Label></div>
                            <div class="alert alert-danger fade show" runat="server" ID="oldPassNotMatch" visible="false">
                                    <asp:Label runat="server" Text="Wrong Old Password!"></asp:Label></div>
                                <div class="alert alert-warning fade show" id="passwordchangeEmpty" runat="server" visible="false">
                                    <asp:Label runat="server" Text="Please Complete All Field"></asp:Label></div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="Label1" runat="server" Text="Old Password"></asp:Label>
                                            <asp:TextBox ID="txtChangePassOld" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="Label2" runat="server" Text="New Password"></asp:Label>
                                            <asp:TextBox ID="txtChangePassNew1" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="Label3" runat="server" Text="Confirm New Password"></asp:Label>
                                            <asp:TextBox ID="txtChangePassNew2" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <asp:Button ID="btnPasswordChange" runat="server" Text="Submit" OnClick="btnPasswordChange_Click" CssClass="mt-2 btn btn-primary" />
                            
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
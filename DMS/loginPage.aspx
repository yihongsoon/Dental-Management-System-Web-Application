<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/dmsNoLoginMasterPage.Master" CodeBehind="loginPage.aspx.cs" Inherits="DMS.loginPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--PAGE TITLE START--%>
    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div>
                    Login
                        <div class="page-title-subheading">
                            Login to access the functions.
                        </div>
                </div>
            </div>
        </div>
    </div> 
    <%--PAGE TITLE END--%>
    <%--NAV BUTTON START--%>
    <ul class="body-tabs body-tabs-layout tabs-animated body-tabs-animated nav">
        <li class="nav-item">
            <asp:LinkButton ID="lnkLogin" CssClass="nav-link show active" OnClick="lnkLogin_Click" runat="server"><span>Login</span></asp:LinkButton>
        </li>
        <li class="nav-item">          
            <asp:LinkButton ID="lnkPasswordRecover" CssClass="nav-link show" OnClick="lnkPasswordRecover_Click" runat="server"><span>Password Recovery</span></asp:LinkButton>
        </li>
    </ul>
    <%--NAV BUTTON END--%>
    <%--CONTENT BOBY --%>
    <div class="tab-content">

        <%--LOGIN SCREEN--%>
        <asp:Panel runat="server" ID="pnllogin">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            
                            <%--ALERT BOX--%>
                                <div class="alert alert-danger fade show" runat="server" ID="loginFail" visible="false">
                                    <asp:Label  runat="server" Text="Incorrect Email or Password! Please Try Again"></asp:Label></div> 
                            <div class="alert alert-warning fade show" id="emptyField" runat="server" visible="false">
                                    <asp:Label runat="server" Text="Please Complete All Field"></asp:Label></div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                                            <asp:TextBox ID="txtEmail" runat="server" onkeypress="return event.keyCode != 13;" TextMode="Email" CssClass="form-control"></asp:TextBox>
                                            <%--<asp:Label ID="emptyEmail" runat="server" CssClass="invalid-feedbackEmptyField" Visible="false" Text="Please Fill In The Field."></asp:Label>--%>
                                        </div>                                       
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                                            <asp:TextBox ID="txtPassword" TextMode="Password" onkeypress="return event.keyCode != 13;" runat="server" CssClass="form-control"></asp:TextBox>                                          
                                        </div>
                                    </div>
                                </div>                            
                            <asp:Button ID="btnSignIn" runat="server" UseSubmitBehavior="false" Text="Sign in" OnClick="btnSignIn_Click" CssClass="mt-2 btn btn-primary" />                            
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <%--PASSWORD RECOVERY SCREEN--%>
        <asp:Panel runat="server" Visible="false" ID="pnlPasswordRecover">
            <div class="row">
                <div class="col-md-12">
                    <div class="main-card mb-3 card">
                        <div class="card-body">
                            
                                <div class="alert alert-danger fade show" runat="server" ID="failMatchIcEmail" visible="false">
                                    <asp:Label runat="server" Text="Email and IC Number Does not Match! Please Contact Admin"></asp:Label></div>
                                <div class="alert alert-warning fade show" id="emptyFieldPassRecovery" runat="server" visible="false">
                                    <asp:Label runat="server" Text="Please Complete All Field"></asp:Label></div>
                            <div class="alert alert-success fade show" id="success" runat="server" visible="false">
                                    <asp:Label runat="server" Text="Please Check Your Email."></asp:Label></div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblpassREmail" runat="server" Text="Email"></asp:Label>
                                            <asp:TextBox ID="txtpassREmail" TextMode="Email" onkeypress="return event.keyCode != 13;" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="position-relative form-group">
                                            <asp:Label ID="lblPassRICNo" runat="server" Text="IC Number Without Dash"></asp:Label>
                                            <asp:TextBox ID="txtPassRICNo" runat="server" onkeypress="return event.keyCode != 13;" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <asp:Button ID="btnPassR" runat="server" UseSubmitBehavior="false" Text="Submit" OnClick="btnPassR_Click" CssClass="mt-2 btn btn-primary" />
                            
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        

    </div>
</asp:Content>

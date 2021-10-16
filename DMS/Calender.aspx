<%@ Page Language="C#" MasterPageFile="~/dmsMasterpage.Master" AutoEventWireup="true" CodeBehind="Calender.aspx.cs" Inherits="DMS.Calender" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <div class="app-page-title">
        <div class="page-title-wrapper">
            <div class="page-title-heading">
                <div>
                    Calender
                        <div class="page-title-subheading">
                            Manage Appointment Details through Calender Here
                        </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Content Here -->
    <div class="row">
        <div class="col-md-12">
            <div class="main-card mb-3 card">
                <div class="card-body">
                    <div id='calendar'>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

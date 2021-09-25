<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DMS.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="et_pb_code_inner"></div>
        <div class="et_pb_module et_pb_code et_pb_code_1">
            <div class="et_pb_code_inner">
                <style>
                    #preview {
                        width: 500px;
                        height: 500px;
                        margin: 0px auto;
                    }
                </style>
                <video id="preview"></video>
            </div>
        </div>
        <div class="et_pb_module et_pb_code et_pb_code_2">
            <div class="et_pb_code_inner">
                <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
                <script src="https://rawgit.com/schmich/instascan-builds/master/instascan.min.js"></script>
                <script type="text/javascript">
                    var scanner = new Instascan.Scanner({ video: document.getElementById('preview'), scanPeriod: 1, mirror: false, refractoryPeriod: 10000 });
                    scanner.addListener('scan', function (content) {
                        alert(content);
                        <%--document.getElementById('<%=HiddenField1.ClientID%>').value = content;--%>
                        document.getElementById('<%=Label1.ClientID%>').textContent = content;
                        //window.open(content);
                        //window.location.href=content;
                    });
                    Instascan.Camera.getCameras().then(function (cameras) {
                        if (cameras.length > 0) {
                            scanner.start(cameras[0]);
                            //$('[name="options"]').on('change', function () {
                                //if ($(this).val() == 1) {
                                //    if (cameras[0] != "") {
                                //        scanner.start(cameras[0]);
                                //    } else {
                                //        alert('No Front camera found!');
                                //    }
                                //}
                                //else if ($(this).val() == 2) {
                                //    if (cameras[1] != "") {
                                //        scanner.start(cameras[1]);
                                //    } else {
                                //        alert('No Back camera found!');
                                //    }
                                //}
                            //});
                        } else {
                            console.error('No cameras found.');
                            alert('No cameras found.');
                        }
                    }).catch(function (e) {
                        console.error(e);
                        alert(e);
                    });
                </script>
                <%--<div class="btn-group btn-group-toggle mb-5" data-toggle="buttons">
                    <label class="btn btn-primary active">
                        <input type="radio" name="options" value="1" autocomplete="off" checked="">
                        Front Camera
                    </label>
                    <label class="btn btn-secondary">
                        <input type="radio" name="options" value="2" autocomplete="off">
                        Back Camera
                    </label>
                </div>--%>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Button" />
            </div>
        </div>
    </form>
</body>
</html>

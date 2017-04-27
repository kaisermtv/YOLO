<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="FrontEnd_Pages_Register" %>

<%@ Register Src="~/FrontEnd/Controls/Common/ReCaptcha.ascx" TagPrefix="uc1" TagName="ReCaptcha" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">
    <style>
        .mdkdn-lstres { margin-bottom: 30px; }
    </style>

    <div class="box-ctldkdn text-center"  style="position: relative;margin-top: 70px;">
        <h4 class="title-dkdn">Đăng ký tài khoản mới</h4>
        <p class="sapo-dkdn">Hãy điền đầy đủ thông tin theo mẫu dưới đây </p>
        <% if (this.Message != ""){ %>
        <div style="color: red; margin: 10px 0px;">
            <%=this.Message %>
        </div>
        <% } %>
        <form method="post">
        <ul class="mdkdn-lstres">
            <%--<li>
                <i class="ico ico-user Sprite-v1"></i>
                <input class="ttx" type="text" id="fullname" placeholder="Họ và tên" />
            </li>--%>
            <li>
                <i class="ico ico-user Sprite-v1"></i>
                <input class="ttx" type="text" id="account" name="account" value="<%=Account %>" placeholder="Tài khoản đăng nhập" />
            </li>
            <li>
                <i class="ico ico-email Sprite-v1"></i>
                <input class="ttx" type="text" id="email" name="email" value="<%=Email %>" placeholder="Email" />
            </li>
            <li>
                <i class="ico ico-phone Sprite-v1"></i>
                <input class="ttx" type="text" id="mobile" name="phone" value="<%=Phone %>" placeholder="Số điện thoại" />
            </li>
            <li>
                <i class="ico ico-password Sprite-v1"></i>
                <input class="ttx" type="password" id="password" name="password" placeholder="Mật khẩu" />
            </li>
            <li>
                <i class="ico ico-password Sprite-v1"></i>
                <input class="ttx" type="password" id="repassword" name="password2" placeholder="Nhập lại mật khẩu" />
            </li>
            <li class="rf-capcha">
                <uc1:ReCaptcha runat="server" ID="ReCaptcha1" />
            </li>
        </ul>
        <button type="submit" class="submit-dkdnh btn btn-dangerous" id="btnYoLo">Đăng ký</button>
            </form>
        <p class="ques-dkdn">
            <span>Bạn đã có tài khoản ?</span>
            <a href="/dang-nhap">Đăng nhập</a>
        </p>
    </div>
    <div class="banner-foot mgb20"></div>

    <div id="fb-root"></div>

    <script type="text/javascript">

        Register.Init();

        var temp_account = getCookie("temp_account");
        var temp_email = getCookie("temp_email");
        var temp_mobile = getCookie("temp_mobile");

        if (typeof (temp_fullname) != "undefined") {
            $("#account").val(temp_account);
            setCookie("temp_account", '', -1);
        }
        if (typeof (temp_email) != "undefined") {
            $("#email").val(temp_email);
            setCookie("temp_email", '', -1);
        }
        if (typeof (temp_mobile) != "undefined") {
            $("#mobile").val(temp_mobile);
            setCookie("temp_mobile", '', -1);
        }

        $(document).ready(function () {
            $('#menu-wraper, .search-w, .register-m').hide();
        });
    </script>
</asp:Content>

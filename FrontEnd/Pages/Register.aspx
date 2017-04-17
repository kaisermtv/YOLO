<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="FrontEnd_Pages_Register" %>

<%@ Register Src="~/FrontEnd/Controls/Common/ReCaptcha.ascx" TagPrefix="uc1" TagName="ReCaptcha" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">
    <style>
        .mdkdn-lstres { margin-bottom: 30px; }
    </style>

    <div class="box-ctldkdn text-center">
        <h4 class="title-dkdn">Đăng ký tài khoản mới</h4>
        <p class="sapo-dkdn">Hãy điền đầy đủ thông tin theo mẫu dưới đây </p>
        <ul class="mdkdn-lstres">
            <li>
                <i class="ico ico-user Sprite-v1"></i>
                <input class="ttx" type="text" id="fullname" placeholder="Họ và tên" />
            </li>
            <li>
                <i class="ico ico-email Sprite-v1"></i>
                <input class="ttx" type="text" id="email" placeholder="Email" />
            </li>
            <li>
                <i class="ico ico-phone Sprite-v1"></i>
                <input class="ttx" type="text" id="mobile" placeholder="Số điện thoại" />
            </li>
            <li>
                <i class="ico ico-password Sprite-v1"></i>
                <input class="ttx" type="password" id="password" placeholder="Mật khẩu" />
            </li>
            <li>
                <i class="ico ico-password Sprite-v1"></i>
                <input class="ttx" type="password" id="repassword" placeholder="Nhập lại mật khẩu" />
            </li>
            <li class="rf-capcha">
                <uc1:ReCaptcha runat="server" ID="ReCaptcha1" />
            </li>
        </ul>
        <a href="javascript:;" class="submit-dkdnh btn btn-dangerous" id="btnDekiru">Đăng ký</a>
        <p class="ques-dkdn">
            <span>Bạn đã có tài khoản ?</span>
            <a href="/login.htm">Đăng nhập</a>
        </p>
    </div>
    <div class="banner-foot mgb20"></div>

    <div id="fb-root"></div>

    <script type="text/javascript">

        Register.Init();

        var temp_fullname = getCookie("temp_fullname");
        var temp_email = getCookie("temp_email");
        var temp_mobile = getCookie("temp_mobile");

        if (typeof (temp_fullname) != "undefined") {
            $("#fullname").val(temp_fullname);
            setCookie("temp_fullname", '', -1);
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

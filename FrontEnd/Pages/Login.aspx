<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="FrontEnd_Pages_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">

    <div class="box-ctldkdn text-center" id="login-form" style="position: relative; margin-top: 70px;">
        <h4 class="title-dkdn">Đăng nhập</h4>
        <p class="sapo-dkdn">Bạn đã có tài khoản? Hãy đăng nhập tại đây</p>


        <form method="post" action="/dang-nhap">
            <ul class="mdkdn-lstres h-dkony">
                <li>
                    <i class="ico ico-user Sprite-v1"></i>
                    <input class="ttx" type="text" id="email" name="account" value="<%=Account %>" placeholder="Tài khoản" />
                </li>
                <li>
                    <i class="ico ico-password Sprite-v1"></i>
                    <input class="ttx" type="password" id="password" name="password" placeholder="Mật khẩu" />
                </li>
            </ul>
            <button type="submit" class="submit-dkdnh btn btn-dangerous" id="btnLogin">Đăng nhập</button>
        </form>
        <% if (this.Message != "")
            { %>
        <div style="color: #e35151; margin: 10px 0px; font-size: 12px;">
            <%=this.Message %>
        </div>
        <% } %>

        <p class="ques-dkdn">
            <span>Quên mật khẩu ?</span>
            <a href="javascript:;" id="forgotpass">Vào đây</a>
        </p>
        <%--<p class="dntkmxh">Hoặc đăng nhập bằng tài khoản mạng xã hội</p>
        <div class="dkdn-fb-google">
            <a href="javascript:;" class="fb Sprite-v1" id="btnFacebook"></a>
            <a href="javascript:;" class="google Sprite-v1" id="btnGoogle"></a>
        </div>--%>
        <a class="new-user" href="/dang-ky">Đăng ký tài khoản mới </a>
    </div>

    <div class="box-ctldkdn text-center" id="changepassword" style="display: none; position: relative; margin-top: 70px;">
        <p class="hoanthanh-dkdn">Vui lòng kiểm tra email <a href="javascript:;" class="sucssemail">ngochuan@gmail.com</a> và làm theo hướng dẫn để lấy lại mật khẩu truy cập website</p>
        <a href="/login.htm" class="submit-dkdnh">Hoàn thành</a>
    </div>
    <!--Lightbox boxforget pass-->

    <div class="box-ctldkdn" id="resetpassword" style="display: none; position: relative; margin-top: 70px;">
        <h4 class="title-dkdn paddingleft50">Lấy lại mật khẩu</h4>
        <p class="sapo-dkdn paddingleft50">Nhập địa chỉ email đăng nhập của bạn vào đây</p>
        <ul class="mdkdn-lstres h-dkony">
            <li>
                <i class="ico ico-email Sprite-v1"></i>
                <input class="ttx" type="text" placeholder="Email" id="emailreceivepass">
            </li>
        </ul>
        <a href="javascript:;" id="btnResetPassSubmit" class="submit-dkdnh newpass fr btn btn-dangerous">Xác nhận</a>
    </div>
    <input type="hidden" id="hdMail" value="" />
    <div class="banner-foot" style="margin-bottom: 100px;"></div>
    <div id="fb-root"></div>

    <script type="text/javascript">
        $(document).ready(function () {
            //$('.main-header, #menu-wraper, #footer, #copyright').hide();
            $('#Header_userName').hide();
        });
    </script>
</asp:Content>

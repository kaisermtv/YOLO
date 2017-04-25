<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="FrontEnd_Controls_Common_Header" %>


<div class="main-header">
    <div class="logo img-w">
        <a href="/">
            <img src="/images/Front-End/logo.png" />
        </a>
    </div>
    <div class="search-w hidden-xs hidden-sm">
        <form method="get" action="/tim-kiem">
            <input class="txt-search" name="Seach" placeholder="Nhập từ khóa tìm kiếm.." />
            <button type="submit" class="btn-search">Tìm kiếm</button>
        </form>
    </div>
    <div class="bar">
        <i class="fa fa-bars"></i>
    </div>
    <div class="login-w ">
        <div class="img-w user">
            <img src="/images/Front-End/user.png" />
        </div>
        <ul class="login-ul">
            <li class="login-m" id="userName" runat="server">
                <%--<a href="/dang-nhap">Đăng nhập</a>--%>
                <a href="javascript:;">Đăng nhập</a>
            </li>
            <li class="register-m" id="logout" runat="server">
                <%--<a href="/dang-ky">Đăng ký</a>--%>
                <a href="javascript:;" class="register-rv">Đăng ký</a>
            </li>
        </ul>
    </div>

</div>

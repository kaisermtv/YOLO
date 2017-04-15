<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="FrontEnd_Controls_Common_Header" %>


<div class="main-header">
    <div class="logo img-w">
        <img src="/images/Front-End/logo.png" />
    </div>
    <div class="search-w hidden-xs hidden-sm">
        <input id="txt-search" placeholder="Nhập từ khóa tìm kiếm.." />
        <a href="javascript:;" id="btn-search">Tìm kiếm</a>
    </div>
    <div class="bar">
        <i class="fa fa-bars"></i>
    </div>
    <div class="login-w ">
        <div class="img-w user">
            <img src="/images/Front-End/user.png" />
        </div>
        <ul class="login-ul">
            <li>
                <a href="#">Đăng nhập</a>
            </li>
            <li>
                <a href="#">Đăng ký</a>
            </li>
        </ul>
    </div>

</div>

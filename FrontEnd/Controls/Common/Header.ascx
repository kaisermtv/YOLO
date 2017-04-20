﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="FrontEnd_Controls_Common_Header" %>


<div class="main-header">
    <div class="logo img-w">
        <a href="/">
            <img src="/images/Front-End/logo.png" />
        </a>
    </div>
    <div class="search-w hidden-xs hidden-sm">
        <form method="get" action="/tim-kiem">
            <input class="txt-search" name="txtSeach" placeholder="Nhập từ khóa tìm kiếm.." />
            <input class="btn-search" value="Tìm kiếm" />
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
            <li class="login-m">
                <a href="#">Đăng nhập</a>
            </li>
            <li class="register-m">
                <a href="#">Đăng ký</a>
            </li>
        </ul>
    </div>

</div>

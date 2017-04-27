<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="FrontEnd_Controls_Common_Footer" %>


<div class="container-fluid" id="footer">
    <div class="main">
        <div class="row">
            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
                <ul class="footer-nav">
                    <li><a class="footer-no" href="#">YOLO</a></li>
                    <li><a href="<%= getUrlMenuById(0) %>">Gương mặt</a></li>
                    <li><a href="<%= getUrlMenuById(0) %>">Mỗi ngày một câu hỏi</a></li>
                </ul>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
                <ul class="footer-nav">
                    <li><a class="footer-no" href="#">Sống</a></li>
                    <li><a href="<%= getUrlMenuById(4) %>">Let’s work</a></li>
                    <li><a href="<%= getUrlMenuById(3) %>">Sống nơi công sở</a></li>
                </ul>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
                <ul class="footer-nav">
                    <li><a class="footer-no" href="#">Cafe công sở</a></li>
                    <li><a href="<%= getUrlMenuById(0) %>">Hạt dưa</a></li>
                    <li><a href="<%= getUrlMenuById(5) %>">Cafe Lắng</a></li>
                </ul>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
                <ul class="footer-nav">
                    <li><a class="footer-no" href="#">Mobifone công sở</a></li>
                    <li><a href="<%= getUrlMenuById(0) %>">Mobifone công sở</a></li>
                </ul>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <div class="rvtd-m">
                    <div class="rvtd">Số người online : <%=userOnline %></div>
                    <div class="rvtd">Số người tham gia : <%=userRegis %></div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="container-fluid" id="copyright">
    <div class="main">
        © Copyright 2017 MobiFone. Bản beta đang xin giấy phép.
    </div>
</div>

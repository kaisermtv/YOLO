<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CuocThiAnh.ascx.cs" Inherits="Controller_CuocThiAnh" %>

<!-- KHOI SO 2 - FANPER  -->
<div>
    <a name="fanper"></a>
    <section class="about" id="about" style="display: table;">
        <div class="container">
        <div class="row">
            <div class="col-sm-8 text-center animated wow fadeInLeft">
                <a href="https://www.facebook.com/yolomobifone/">
                    <div class="header">
                        #Facebook.com/yolomobifone
                           
                    </div>
                </a>
                <div class="features_list">
                    <h1 class="text-uppercase phoneHeader"><%= title %></h1>
                    <p><%= content %></p>
                    <a href="<%= link %>">
                        <img src="/images/buttonDetail.png" id = "buttonDetail" />
                    </a>
                </div>
            </div>
            <div class="col-sm-4 animated wow fadeInRight">
                <div style="margin-bottom: 60px"></div>
                <div class="iphone" style="max-width: 100%">
                    <img src="<%= img %>" style="max-width: 100%" alt="" title="">
                </div>
            </div>
        </div>
        </div>
    </section>
</div>
<!-- KET THUC KHOI SO 2 -->

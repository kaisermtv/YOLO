<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DanhMuc.ascx.cs" Inherits="FrontEnd_Controls_News_DanhMuc" %>


<div id="danhmuc-tintuc">
    <div class="header">Danh mục tin tức - sự kiện</div>
    <ul>
        <li>

            <div class="zc" id="guong-mat">
                <a href="#">Gương mặt</a>
            </div>

        </li>
        <li>

            <div class="zc" id="moi-ngay-mot-cau-hoi">
                <a href="#">Mỗi ngày một câu hỏi</a>
            </div>

        </li>
        <li>

            <div class="zc" id="let-work">
                <a href="#">Let's Work</a>
            </div>

        </li>
        <li>

            <div class="zc" id="song-noi-cong-so">
                <a href="#">Sống nơi công sở</a>
            </div>

        </li>
        <li>

            <div class="zc" id="hat-dua">
                <a href="#">Hạt dưa</a>
            </div>

        </li>
        <li>

            <div class="zc" id="cafe-lang">
                <a href="#">Cafe Lắng</a>
            </div>

        </li>
        <li>

            <div class="zc" id="mobifone-cong-so">
                <a href="#">Mobifone công sở</a>
            </div>

        </li>
    </ul>
</div>
<script>
    var UrlCatTabRight = $("#UrlCat").val();
    $("#danhmuc-tintuc ul li #" + UrlCatTabRight).addClass("active");
</script>

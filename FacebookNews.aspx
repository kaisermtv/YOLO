<%@ Page Title="Fanpage" Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/Site.master" CodeFile="FacebookNews.aspx.cs" Inherits="FacebookNews" %>

<%@ Register Src="~/Controller/DanhMucTin.ascx" TagPrefix="uc1" TagName="DanhMucTin" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/front-end.css">
    <link rel="stylesheet" type="text/css" href="/css/reset.css">
    <style>
        .fb_content {
        }

            .fb_content .image {
            }

                .fb_content .image img {
                    width: 100%;
                }

            .fb_content .fb_body {
            }

                .fb_content .fb_body fb_header {
                    width: 100%;
                }

        .fb_footer {
            width: 100%;
            background-color: #ffefef;
            height: 20px;
            margin-top: 10px;
        }

        h5 {
            margin-top: -5px;
            font-size: 22px;
            line-height: 30px;
            font-family: Arial;
            text-align: justify;
            margin-bottom: 15px;
        }

        p {
            font-size: 15px;
            font-family: Arial;
            text-align: justify;
            line-height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
    <div id="fb-root"></div>
    <script>
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.9&appId=1972725952949362";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));
    </script>

    <script>

        var isLoad = false;

        function loadNextPage(url) {
            if (!isLoad) {
                isLoad = true;

                $.get('/ajax/LoadMoreFacebook.aspx?after=' + url, returnJson)
            }
        }

        function returnJson(data, status, xhr) {
            if (status == "success") {
                //alert(data);

                $("#loadmore").remove();

                $("#fb_data").append(data);
            } else {
                alert('Error occured');
            }

            isLoad = false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="container-fluid">
            <div class="main">
                <div class="row show-grid">
                    <div class="news-wraper col-xs-12 col-md-12">
                        <div class="row show-grid">
                            <div class="clearfix visible"></div>
                            <div class="cleft col-xs-12 col-sm-8 col-md-8 ">
                                <img id="facebookCover" src="<%=pic_cover %>" style="width: 100%; margin-top: 10px" />

                                <div style="text-align: center; background-color: #2c90f7; padding: 10px; margin-top: 10px;">
                                    <h3 style="margin: 0px; color: #ffffff;">Liên kết Facebook</h3>
                                </div>

                                <div id="fb_data">
                                    <asp:Repeater ID="dtlData" runat="server">
                                        <ItemTemplate>
                                            <hr />
                                            <div class="row fb_content">
                                                <div class="image col-md-5">
                                                    <img src="<%# Eval("full_picture") %>" />
                                                </div>
                                                <div class="fb_body col-md-7">
                                                    <div class="fb_header">
                                                    </div>
                                                    <h5 id="facebookHeader"><%# (((dynamic)Container.DataItem).name != null)?Eval("name").ToString().Replace("Timeline Photos","Ảnh trên dòng thời gian"):"" %></h5>
                                                    <p id="facebookMeaasge"><%# (((dynamic)Container.DataItem).message != null)?Eval("message").ToString().Replace("\n","<br>"):"" %></p>
                                                </div>
                                            </div>
                                            <div class="fb_footer">
                                                <div style="float: left; margin-right:5px;">
                                                    <img src="../images/facebook-new-like-symbol-32.png" style="width: 20px;">
                                                </div>
                                                <div style="float: left; font-size: 12px; padding-top:5px;">
                                                    <%# this.objFacebook.getCountLikesById(Eval("Id").ToString()) %>
                                                </div>
                                                <div style="float: left; margin-left:10px; margin-right:5px;">
                                                    <img src="../images/comments-512.png" style="width: 18px; margin-top:2px;">
                                                </div>
                                                <div style="float: left; font-size: 12px; padding-top:5px;">
                                                    <%# this.objFacebook.getCountCommentsById(Eval("Id").ToString()) %>
                                                </div>
                                                 <div style="float: left; margin-left:10px; margin-right:5px;">
                                                    <img src="../images/shares.png" style="width: 18px; margin-top:2px;">
                                                </div>
                                                <div style="float: left; font-size: 12px; padding-top:5px;">
                                                    <%# this.objFacebook.getCountSharesById(Eval("link").ToString()) %>
                                                </div>
                                                <div style ="float:right; padding-top:5px; font-size: 12px; color:#849292;"><a href="<%# Eval("permalink_url") %>" style="float: right;">Xem trên facebook</a></div>
                                                <%--<div class="fb-like" data-href="<%# Eval("link") %>" data-layout="button_count" data-action="like" data-size="small" data-show-faces="false" data-share="false" style="width: 70%; float: left;"></div>--%>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <div id="loadmore" style="text-align: center; margin-top: 20px">
                                        <%--<asp:Button ID="prev" runat="server" OnClick="prev_Click" Text="Trước" />--%>
                                        <%--<asp:Button ID="next" runat="server" OnClick="next_Click" Text="Tiếp" />--%>

                                        <button id="loadbutton" class="btn btn-default" onclick="loadNextPage('<%= nextUrl %>')">Tải thêm</button>
                                    </div>
                                </div>

                                <br />
                                <hr />
                                <div class="fb-comments"
                                    data-href="http://113.164.227.242:4083<%=Request.RawUrl %>"
                                    data-width="auto">
                                </div>
                            </div>

                            <div class="cright col-xs-6 col-sm-4 col-md-4 hidden-xs" style="margin-top: 30px;">
                                <uc1:DanhMucTin ID="danhMuc" runat="server" />
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

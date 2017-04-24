﻿<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="News_Detail.aspx.cs" Inherits="FrontEnd_Pages_News_Detail" %>


<%@ Register Src="~/FrontEnd/Controls/News/DanhMuc.ascx" TagPrefix="uc1" TagName="DanhMuc" %>
<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">

    <div id="fb-root"></div>
    <div class="container-fluid">
        <div class="main">
            <div class="row show-grid">
                <div class="news-wraper col-xs-12 col-md-12">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <ul id="NavDetail">
                                <li><a href="/">Trang chủ</a></li>
                                <li class="active"><a href="#"><%=groupname %></a></li>
                            </ul>

                        </div>
                    </div>
                    <div class="row show-grid">
                        <div class="clearfix visible"></div>
                        <div class="cleft col-xs-12 col-sm-8 col-md-8 ">

                            <div class="row">
                                <div id="" class="col-xs-12 col-sm-12 col-md-12">
                                    <h3 class="tieu-de" style="margin-top: 10px; margin-bottom: 10px; font-size: 24px;"><%= objData["Title"] %></h3>
                                    <a href="javascript:;" id="btn-save" title="Download">
                                        <img src="../../images/word-download.png" style="height: 30px;" />
                                    </a>
                                    <label class="time">Ngày đăng: <%= ((DateTime)objData["DayPost"]).ToString("dd/MM/yyyy h:mm:ss tt") %> </label>
                                    <p id="article_new" class="sapo" style="font-weight: bold; margin-bottom: 30px; font-size: 19px;">
                                        <%=objData["ShortContent"]  %>
                                    </p>
                                    <div>
                                        <img onerror="this.src='/images/Front-End/no-image-available.png';" src="/Images/News/<%=objData["ImgUrl"] %>" alt="" style="margin: 10px auto 20px; display: block;" />
                                    </div>
                                    <div id="article_new_content" class="content-detail">
                                        <%=objData["Content"]  %>
                                    </div>

                                </div>
                            </div>


                            <div class="row related-news">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <h3 class="tieu-de">Tin mới hơn</h3>
                                    <ul class="lst-news-r">
                                        <asp:Repeater ID="dtlTinMoi" runat="server" EnableViewState="False">
                                            <ItemTemplate>
                                                <li>
                                                    <a href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>" title="<%#Eval("Title") %>">
                                                        <div class="img-w">
                                                            <img onerror="this.src='/images/Front-End/no-image-available.png';" src="/Images/News/<%# Eval("ImgUrl") %>" alt="" />
                                                        </div>
                                                        <div class="re-news-title">
                                                            <%# Eval("Title") %>
                                                            <span><%# ((DateTime)Eval("DayPost")).ToString("dd/MM/yyy") %></span>
                                                        </div>
                                                    </a>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <div class="row related-news">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <h3 class="tieu-de">Tin cũ hơn</h3>
                                    <ul class="lst-news-r">
                                        <asp:Repeater ID="dtlTinCu" runat="server" EnableViewState="False">
                                            <ItemTemplate>
                                                <li>
                                                    <a href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>" title="<%#Eval("Title") %>">
                                                        <div class="img-w">
                                                            <img onerror="this.src='/images/Front-End/no-image-available.png';" src="/Images/News/<%# Eval("ImgUrl") %>" alt="" />
                                                        </div>
                                                        <div class="re-news-title">
                                                            <%# Eval("Title") %>
                                                            <span><%# ((DateTime)Eval("DayPost")).ToString("dd/MM/yyy") %></span>
                                                        </div>
                                                    </a>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <h3 class="tieu-de">Bình luận </h3>

                                    <div class="fb-comments" data-href="https://www.http://125.212.130.234:4083/posts/<%=itemId.ToString() %>" data-width="800" data-numposts="5"></div>
                                </div>


                            </div>

                        </div>
                        <div class="cright col-xs-6 col-sm-4 col-md-4 hidden-xs">
                            <%--<uc1:DanhMuc runat="server" ID="DanhMuc" />--%>
                            <uc1:QuangCao runat="server" ID="QuangCao1" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <script type="text/javascript">
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/en_GB/sdk.js#xfbml=1&version=v2.9&appId=1929429900621768";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));

        $("#btn-save").click(function () {
            var text = document.getElementById('article_new').textContent + '\n'
                + document.getElementById('article_new_content').textContent;
            var filename = 'yolo'
            var blob = new Blob([text], { type: "text/plain;charset=utf-8" });
            saveAs(blob, filename + ".txt");
        });
    </script>


    <script src="../../js/FileSaver.min.js"></script>
</asp:Content>

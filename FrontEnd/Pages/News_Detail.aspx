<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="News_Detail.aspx.cs" Inherits="FrontEnd_Pages_News_Detail" %>


<%@ Register Src="~/FrontEnd/Controls/News/DanhMuc.ascx" TagPrefix="uc1" TagName="DanhMuc" %>
<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>
<asp:Content ID="head" ContentPlaceHolderID="headerContent" runat="server">

<meta property="og:title" content="<%=objData["Title"] %>"/>
<meta property="og:image" content="http://113.164.227.242:4083/Images/News/<%=objData["ImgUrl"] %>" />
<meta property="og:description" content=" <%=objData["ShortContent"] %>"/>
<meta property="og:author" content="yolo"/>
<meta property="og:keywords" content="<%=objData["Title"] %>"
<meta property="twitter:url" content="http://113.164.227.242:4083/" />
<meta property="twitter:title"  content="<%=objData["Title"] %>" />
<meta property="twitter:image" content="http://113.164.227.242:4083/Images/News/<%=objData["ImgUrl"] %>" />

</asp:Content>
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
                                <li><a href="/<%=SystemClass.convertToUnSign2(groupname) %>-cat<%=group %>"><%=groupname %></a></li>
                                <li></li>
                            </ul>
                        </div>
                    </div>
                    <div class="row show-grid">
                        <div class="clearfix visible"></div>
                        <div class="cleft col-xs-12 col-sm-12 col-md-8 col-lg-8 ">

                            <div class="row">
                                <div id="" class="col-xs-12 col-sm-12 col-md-12">
                                    <h3 class="tieu-de" style="margin-top: 10px; margin-bottom: 10px; font-size: 24px;"><%= objData["Title"] %></h3>
                                  
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
                            <div class="row" style="margin-top: 50px; margin-bottom: 50px;">

                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                    <a href="https://www.facebook.com/sharer.php?&u=http://113.164.227.242:4083/<%=Request.RawUrl %>"><i id="social-fb" class="fa fa-facebook-square fa-3x social"></i></a>
	                                  <a href="https://twitter.com/intent/tweet?&url=http://113.164.227.242:4083/<%=Request.RawUrl %>"><i id="social-tw" class="fa fa-twitter-square fa-3x social"></i></a>
	                                <a href="https://plus.google.com?&url=http://113.164.227.242:4083/<%=Request.RawUrl %>"><i id="social-gp" class="fa fa-google-plus-square fa-3x social"></i></a>
	                                <a href="javascript:;" id="btn-save" style="position:static !important"  title="Download"><img src="../../images/word-download.png" height="30" /></a>
                                              <hr />
                                    <h3 class="tieu-de">Bình luận </h3>
                                  <div class="fb-comments"
                                   data-href="http://113.164.227.242:4083<%=Request.RawUrl %>"
                                   data-width="750"></div>
                                </div>
                            </div>
                            <asp:Repeater ID="dtlTinMoi" runat="server" EnableViewState="False">
                                <HeaderTemplate>
                                    <div class="row related-news">
                                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                            <h3 class="tieu-de">Tin mới hơn</h3>
                                            <ul class="lst-news-r">
                                </HeaderTemplate>
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
                                <FooterTemplate>
                                    </ul>
                                </div>
                            </div>
                                </FooterTemplate>
                            </asp:Repeater>
                            <div class="row related-news">
                                <asp:Repeater ID="dtlTinCu" runat="server" EnableViewState="False">
                                    <HeaderTemplate>
                                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                            <h3 class="tieu-de">Tin cũ hơn</h3>
                                            <ul class="lst-news-r">
                                    </HeaderTemplate>
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
                                    <FooterTemplate>
                                        </ul>
                                </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="cright hidden-xs   col-sm-12 col-md-4 col-xs-4">
                            <uc1:DanhMuc runat="server" ID="DanhMuc" />
                            <uc1:QuangCao runat="server" ID="QuangCao1" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="fb-root"></div>
<script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.6";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

    <script type="text/javascript">
        
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

<%@ Page Title="Dịch vụ Mobifone" Language="C#" MasterPageFile="~/App_Master/Site.master" AutoEventWireup="true" CodeFile="CatView.aspx.cs" Inherits="CatView" %>

<%@ Register Src="~/Controller/Paging.ascx" TagPrefix="uc1" TagName="Paging" %>
<asp:Content ID="head" ContentPlaceHolderID="HeadContent" runat="server">


    <meta property="fb:app_id" content="<%= FacebookAPI.App_id %>" />

<meta property="og:title" content="<%=objData["Title"] %>"/>
<meta property="og:image" content="http://113.164.227.242:4083<%=objData["ImgUrl"] %>" />
<meta property="og:description" content=" <%=objData["ShortContent"] %>"/>
<meta property="og:author" content="yolo"/>
<meta property="og:keywords" content="<%=objData["Title"] %>"
<meta property="twitter:url" content="http://113.164.227.242:4083/" />
<meta property="twitter:title"  content="<%=objData["Title"] %>" />
<meta property="twitter:image" content="http://113.164.227.242:4083<%=objData["ImgUrl"] %>" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="Server">
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
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container" id ="ImgCatView">
        <div class="row col-md-12">
            <div style="width: 100%;">
                <h1 style="font-family: Arial; font-size: 25px; font-weight: bold; text-align: center;" id = "H1CatView"><%= objData["Title"] %></h1>
                <div class="single-before-header col-xs-12 noPadding">
                    <div class="fb-like" data-href="http://113.164.227.242:4083<%=Request.RawUrl %>" data-width="auto" data-layout="standard" data-action="like" data-show-faces="false" data-share="true"></div>
                </div>

                <div class="article-content-wrapper single-content-wrapper col-xs-12 noPadding">
                    <div class="kv-media col-xs-12 noPadding mgB20">
                        <div style="text-align: center;">
                            <img onerror="imgCatchError(this)" src="<%=objData["ImgUrl"] %>" alt="" style="margin: 10px auto 20px; display: block;" />
                        </div>
                    </div>
                    <%=objData["Content"]  %>
                    <div dir="ltr">&nbsp;</div>
                </div>
            </div>
            <!-- KET THUC PHAN CHI TIET -->
        </div>
    </div>
    
    <div class="container">
        <hr />
        <a href="https://www.facebook.com/sharer.php?&u=http://113.164.227.242:4083<%=Request.RawUrl %>"><i id="social-fb" class="fa fa-facebook-square fa-3x social"></i></a>
        <a href="https://twitter.com/intent/tweet?&url=http://113.164.227.242:4083<%=Request.RawUrl %>"><i id="social-tw" class="fa fa-twitter-square fa-3x social"></i></a>
        <a href="https://plus.google.com?&url=http://113.164.227.242:4083<%=Request.RawUrl %>"><i id="social-gp" class="fa fa-google-plus-square fa-3x social"></i></a>
        <hr />
        <h3 class="tieu-de">Bình luận </h3>
        <fb:comments xid="<%=objData["Id"]  %>" data-width="100%"></fb:comments>
        <%--<div class="fb-comments"
            data-href="http://113.164.227.242:4083<%=Request.RawUrl %>"
            data-width="auto">
        </div>--%>
            <hr />

<%--        <asp:Repeater ID="dtlComment" runat="server">
            <ItemTemplate>
                <h4><%# Eval("Subject") %></h4>
                <div>
                    <%# Eval("Content").ToString().Replace("\n","<br />") %>
                </div>
                <div style="width:60%">
                    <hr  />
                </div>
            </ItemTemplate>
            <FooterTemplate>
                
            </FooterTemplate>
        </asp:Repeater>
        <uc1:Paging ID="pageId" runat="server" />
        --%>
        <div id ="FeedBackCatView" class="col-md-9" >
            <div class="form-area">
                <form role="form" method="post">
                    <br style="clear: both">
                    <h3 style="margin-bottom: 25px; text-align: center;" id = "H3CatView">ĐỂ ĐÓNG GÓP Ý KIẾN CỦA BẠN HAY ĐIỀN THÔNG TIN THEO MẪU</h3>
                    <div class="form-group">
                        <input type="text" class="form-control" id="name" name="name" placeholder="Họ và tên" required>
                    </div>
                    <div class="form-group">
                        <input type="text" class="form-control" id="email" name="email" placeholder="Địa chỉ email" required>
                    </div>
                    <div class="form-group">
                        <input type="text" class="form-control" id="mobile" name="mobile" placeholder="Số điện thoại" required>
                    </div>
                    <div class="form-group">
                        <select class="form-control" id="city" name="CityID">
                            <option value="0">Chọn tỉnh thành</option>
                            <option value="1">Nghệ An</option>
                            <option value="2">Hà Tĩnh</option>
                            <option value="3">Thanh Hóa</option>
                            <option value="4">Quảng Bình</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <input type="text" class="form-control" id="subject" name="subject" placeholder="Chủ đề" required>
                    </div>
                    <div class="form-group">
                        <textarea class="form-control" name="message" id="message" placeholder="Nội dung liên hệ" maxlength="140" rows="7"></textarea>
                        <span class="help-block warning"><%=message %></span>
                    </div>

                    <button type="submit" class="btn btn-primary pull-right" style="margin-bottom:20px">Gửi thông tin</button>
                </form>
            </div>
        </div>
    </div>
</asp:Content>


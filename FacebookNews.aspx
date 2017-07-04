<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/Site.master" CodeFile="FacebookNews.aspx.cs" Inherits="FacebookNews" %>


<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .fb_content{

        }

        .fb_content .image{
            
        }

        .fb_content .image img{
            width:100%
        }

        .fb_content .fb_body{
            
        }

        .fb_content .fb_body fb_header{
            width:100%;
        }

        .fb_footer{
            width:100%;
            background-color: #ffefef;
            height:20px;
            margin-top:10px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="fb-root"></div>
<script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.9&appId=1972725952949362";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

    <div class="container">
        <div class="container-fluid">
            <div class="main">
                <div class="row show-grid">
                    <div class="news-wraper col-xs-12 col-md-12">
                        <div class="row show-grid">
                            <div class="clearfix visible"></div>
                            <div class="cleft col-xs-12 col-sm-8 col-md-8 ">
                               <img src="<%=pic_cover %>" style="width:100%;margin-top:10px" />

                                <div style="text-align:center;background-color: #000000;padding:10px">
                                    <h2 style="margin:0px;color:#ffffff;">Liên kết Facebook</h2>
                                </div>
                                <asp:Repeater ID="dtlData" runat="server">
                                    <ItemTemplate>
                                        <hr />
                                        <div class="row fb_content">
                                            <div class="image col-md-5" >
                                                <img src="<%# Eval("full_picture") %>" />
                                            </div>
                                            <div class="fb_body col-md-7" >
                                                <div class="fb_header">

                                                </div>
                                                <h5><%# Eval("name").ToString().Replace("Timeline Photos","Ảnh trên dòng thời gian") %></h5>
                                                <p><%# Eval("message") %></p>
                                            </div>
                                        </div>
                                        <div class="fb_footer">
                                            <div class="fb-like" data-href="<%# Eval("link") %>" data-layout="button_count" data-action="like" data-size="small" data-show-faces="false" data-share="false"></div>
                                            <a href="<%# Eval("permalink_url") %>" style="float:right;" >Xem trên facebook</a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>


                                <div style="text-align:center;margin-top:20px">
                                    <button class="btn btn-default">Load more...</button>
                                </div>
                                
                                <br />
                                <hr />
                                <div class="fb-comments"
                                    data-href="http://113.164.227.242:4083<%=Request.RawUrl %>"
                                    data-width="auto">
                                </div>
                            </div>
                            
                            <div class="cright col-xs-6 col-sm-4 col-md-4 hidden-xs">
                                <%--<uc1:DanhMucTin ID="danhMuc" runat="server" />--%>
                                

                                
                            </div>
                        
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

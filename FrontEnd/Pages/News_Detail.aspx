<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="News_Detail.aspx.cs" Inherits="FrontEnd_Pages_News_Detail" %>


<%@ Register Src="~/FrontEnd/Controls/News/DanhMuc.ascx" TagPrefix="uc1" TagName="DanhMuc" %>
<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">

        <div id="fb-root"></div>
 

    <div class="container-fluid">
        <div class="main">
            <div class="row show-grid">
                <div class="news-wraper col-xs-12 col-md-12">
                    <div class="row show-grid">
                        <div class="clearfix visible"></div>
                        <div class="cleft col-xs-12 col-sm-8 col-md-8 " style="padding-top: 20px;">
                            <div class="row">
                                <div class="col-xs-12 col-sm-12 col-md-12">
                                    <h3 class="tieu-de" style="margin-top:  <img  onError="this.src='/images/Front-End/no-image-available.png';" ; margin-bottom:  <img  onError="this.src='/images/Front-End/no-image-available.png';" ;font-size: 24px;"><%= objData["Title"] %>

                                       <label style="float:right;margin-right:5%"> 
                                       <a  >
                                           <form runat="server">
                                           Download
                                           <asp:ImageButton ImageUrl="~/images/word-download.png" Height="20" AlternateText="Download" runat="server" ID="btnDownload" OnClick="btnDownload_Click" />
                                       </form>
                                           </a>
                                           </label>
                                    </h3>

                                    <label class="time">Ngày đăng: <%= ((DateTime)objData["DayPost"]).ToString("dd/MM/yyyy h:mm:ss tt") %></label>
                                    <p class="sapo" style="font-weight: bold; margin-bottom: 30px; font-size: 19px;">
                                        <%=objData["ShortContent"]  %>
                                    </p>
                                    <div class="content-detail">
                                        <%=objData["Content"]  %>
                                    </div>

                                </div>
                            </div>
                            <asp:Repeater ID="dtlTinMoi" runat="server" EnableViewState="False">
                                <HeaderTemplate>
                                    <br />
                                    <h3>Tin mới hơn</h3>
                                    <div class="row" style="border-top: 1px solid #e1e1e1">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="col-xs-12" style="margin:3px">
                                        <a href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>" title="<%# Eval("Title") %>"><%# Eval("Title") %> (<%# ((DateTime)Eval("DayPost")).ToString("dd/MM/yyy") %>)</a>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>

                            <asp:Repeater ID="dtlTinCu" runat="server" EnableViewState="False">
                                <HeaderTemplate>
                                    <br />
                                    <h3>Tin cũ hơn</h3>
                                    <div class="row" style="border-top: 1px solid #e1e1e1">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="col-xs-12" style="margin:3px">
                                        <a href="/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-v<%#Eval("Id")%>" title="<%# Eval("Title") %>"><%# Eval("Title") %> (<%# ((DateTime)Eval("DayPost")).ToString("dd/MM/yyy") %>)</a>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                            <hr />
                            <br />
                           Bình luận 
                            <br />
                                   <div class="fb-comments" data-href="https://www.http://125.212.130.234:4083/posts/<%=itemId.ToString() %>" data-width="800" data-numposts="5"></div>
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

       <script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_GB/sdk.js#xfbml=1&version=v2.9&appId=1929429900621768";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

 

</asp:Content>

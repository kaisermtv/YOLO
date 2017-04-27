<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="PhotoContest.aspx.cs" Inherits="FrontEnd_Pages_PhotoContest" %>

<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>
<%@ Register Src="~/FrontEnd/Controls/News/DanhMuc.ascx" TagPrefix="uc1" TagName="DanhMuc" %>







<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">

    <div id="fb-root"></div>
    <script>(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_GB/sdk.js#xfbml=1&version=v2.9&appId=1929429900621768";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>


    <div class="container-fluid">
        <div class="row">
            <div class="main">
                <div class="cleft col-xs-12 col-sm-12 col-md-8 col-lg-8">
                    <div id="PhotoContest">
                        <h3>Cuộc thi ảnh Yolo - Dám chia sẻ</h3>
                        <p class="sapo">
                            Cuộc thi dành cho giới trẻ 4 Tỉnh miền trung Nghệ An, Thanh Hóa, Hà Tĩnh và Quảng Bình. Tự tin sống cá tính
                            <br />
                            Tích cực chia sẻ vì cộng đồng. YOLO- dám chia sẻ
                        </p>
                        <div class="img-w" style="margin-bottom: 20px; height: 500px; padding: 0;">
                            <img onerror="this.src='/images/Front-End/no-image-available.png';" src="<%= objData["picture"].ToString() %>" alt="Yolo chia sẻ đam mê" />

                        </div>
                        <div class="likes fb-rm">
                            &nbsp;&nbsp;&nbsp;
                             <a href="<%= objData["link"].ToString() %>">
                                 <i class="fa fa-thumbs-o-up" aria-hidden="true"></i>
                                 <span><%= objData["likes"].ToString() %></span>
                             </a>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <a href="<%= objData["link"].ToString() %>">
                                     <i class="fa fa-comments" aria-hidden="true"></i>
                                     <span><%= objData["comments"].ToString() %></span>
                                 </a>
                        </div>

                        <label><span>Họ tên: </span><%= objData["user_name"].ToString() %></label>
                        <label><span>Ngày sinh:</span> <%= objData["user_birthday"].ToString() %></label>
                        <label><span>Đến từ:</span> <%= objData["user_address"].ToString() %></label>
                        <p><%= objData["name"].ToString() %> </p>
                        <br />

                        <%--Bình luận trên Facebook--%>
                        <div class="comment-w">
                            <%int i = 1; %>
                            <% foreach (comments c in lComment)
                                {
                                    if (i >= 5) break;
                                    i++; %>
                            <div class="fb-comment-embed"
                                data-href="<%= objData["link"].ToString().Trim() %>&comment_id=<%=c.id %>"
                                data-width="800" data-include-parent="false">
                            </div>
                            <%} %>
                            <br />
                            <hr />

                            <!-- comemnt -->
                            Bình luận trên trang
                            <div class="fb-comments" data-href=" <%= objData["link"].ToString() %>" data-width="800" data-numposts="5"></div>
                        </div>
                    </div>

                    <h3 class="" style="font-size: 24px; font-family: CondBold; display: inline-block; width: 100%; margin-top: 40px; margin-bottom: 10px;">Bài thi liên quan</h3>
                    <ul id="PhotoContestList">

                        <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
                            <ItemTemplate>
                                <li>
                                    <div class="row">
                                        <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                                            <div class="img-w">
                                                <a href="/<%# SystemClass.convertToUnSign2(Eval("user_name").ToString()) %>-p<%#Eval("id")%>">
                                                    <img onerror="this.src='/images/Front-End/no-image-available.png';" src="<%#Eval("picture")%>" alt="<%#Eval("user_name")%>" /></a>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-sm-8 col-md-8 col-lg-8">

                                            <div class="PhotoContest-rt">
                                                <div class="PhotoContest-rt-m">
                                                    <a href="javascript:;">
                                                        <img onerror="this.src='/images/Front-End/no-image-available.png';" src="/images/Front-End/logo.png" />
                                                    </a>
                                                    <label>Yolo- Dám chia sẻ</label>
                                                    <div class="social">
                                                        <div class="likes fb-rm">
                                                            <i class="fa fa-thumbs-o-up" aria-hidden="true"></i>
                                                            <span><%#Eval("likes")%></span>
                                                        </div>
                                                        <div class="comments fb-rm">
                                                            <i class="fa fa-comments" aria-hidden="true"></i>
                                                            <span><%#Eval("comments")%></span>
                                                        </div>
                                                        <div class="share fb-rm">
                                                            <i class="fa fa-share" aria-hidden="true"></i>
                                                            <span>0</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <label><span>Họ tên: </span><%#Eval("user_name")%></label>
                                                <label><span>Ngày sinh:</span> <%#Eval("user_birthday")%></label>
                                                <label><span>Đến từ:</span> <%#Eval("user_address")%></label>
                                                <p><%#Utils.GetSubStringNice(Eval("name").ToString(), 200) %></p>
                                                <div><a class="see-more" href="/<%# SystemClass.convertToUnSign2(Eval("user_name").ToString()) %>-p<%#Eval("id")%>">Xem thêm</a></div>
                                            </div>
                                        </div>
                                    </div>

                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="cright hidden-xs   col-sm-12 col-md-4 col-xs-4" style="margin-top: 20px;">
                    <uc1:DanhMuc runat="server" ID="DanhMuc" />
                    <uc1:QuangCao runat="server" ID="QuangCao" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/System.master" AutoEventWireup="true" CodeFile="FacebookSetup.aspx.cs" Inherits="System_FacebookSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../css/System/fbPage.css" rel="stylesheet" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container">
    <div class="row">
        <div class="col-md-3  ">
            <div class="list-group">
                <a href="#" class="list-group-item">        <!---thêm các thuộc tính mouser over cho đẹp-->
                    <h3 class="pull-right">
            <img src="../images/article.png" height="40" />
                    </h3>
                    <h4 class="list-group-item-heading count">
                           <%=count_post %> </h4>
                    <p class="list-group-item-text">
                       Bài viết trên trang</p>
                </a><a href="#modal" class="list-group-item  facebook-like">
                    <h3 class="pull-right">
                        <img src="../images/Facebook.png" height="40" />
                    </h3>
                    <h4 class="list-group-item-heading count">
                        <%=count_like %>    
                        </h4>
                    <p class="list-group-item-text">
                       Likes </p>
                 </a>
                 <a href="#" class="list-group-item " data-toggle="modal" data-target=".smallModalRefresh">
                    <h3 class="pull-right">
                        <img src="../images/refresh-512.png" height="40"  />
                    </h3>
                    <h4 class="list-group-item-heading " >&nbsp;
                        </h4>
                    <p class="list-group-item-text">
                      Cập nhật bài mới</p>
                 </a>
                        <!-- Cập nhật lại các bài mới thêm từ facebook -->
                        <div class="modal fade smallModalRefresh" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
                              <div class="modal-dialog modal-sm" role="document">
                                <div class="modal-content">
                                <div class="alert info">   Các bài viết mới sẻ được thêm vào website </div>
                                    <div class="center" >  
                                  <asp:Button ID="btnRefresh" CssClass="btn btn-success" Width="300" runat="server" Text="Cập nhật" OnClick="btnRefresh_Click" /></div>  
                                    <div style="width:100%;height:10px;"></div>
                                </div>
                              </div>
                            </div>
                         <!-- / -->
                         <a href="#" class="list-group-item " data-toggle="modal" data-target=".smallModalUpdate">
                            <h3 class="pull-right">
                              <img src="../images/ico_sync.png"   height="40"  />
                            </h3>
                            <h4 class="list-group-item-heading ">&nbsp;
                                </h4>
                            <p class="list-group-item-text">
                               Đồng bộ lại tất cả </p>
                        </a>
                        <!-- Xác nhận lại - Thao tác làm cập nhật toàn bộ dử liệu-->
                        <div class="modal fade smallModalUpdate" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
                              <div class="modal-dialog modal-sm" role="document">
                                <div class="modal-content">
                                <div class="alert info">    Thao tác sẻ cập nhật lại toàn bộ dử liệu bài viết từ facebook , những bài viết đã tồn tại có thể bị mất</div>
                                    <div class="center-block" > 
                                  <asp:Button ID="btnUpdate" CssClass="btn btn-danger" Width="300" runat="server" Text="Xác nhận"  OnClick="btnUpdate_Click" /></div>  
                                    <div style="width:100%;height:10px;"></div>
                                </div>
                              </div>
                            </div>
                      <!-- / -->
                            <a href="#" class="list-group-item " data-toggle="modal" data-target=".smallModalHelp">
                            <h3 class="pull-right">
                              <img src="../images/help.png"   height="40"  />
                            </h3>
                            <h4 class="list-group-item-heading ">&nbsp;
                                </h4>
                            <p class="list-group-item-text">
                             HELP </p>
                        </a>
                        <!-- Xác nhận lại - Thao tác làm cập nhật toàn bộ dử liệu-->
                        <div class="modal fade smallModalHelp" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
                              <div class="modal-dialog modal-lg" role="document">
                                <div class="modal-content">
                                <div class="alert info"> MỘT SỐ LƯU Ý   </div>
                                    <div class="center-block" > 
                                  <div style="margin:1%">
                                         <p>   " Facebook là một hệ thống bảo mật , mạnh mẽ  hàng đầu  nên các yêu cầu khai thác,truy cập dử liệu của họ thường rất chặt chẽ .
                                            </p>
                                            <p>  Vì thế chúng ta phải tuân theo các chính sách đó của họ. "</p>
                                           <p > Token là một chuổi mật mã quy định quyền truy cập dử liệu của 1 trang fanpage hoặc 1 tài khoản người dùng từ các ứng dụng bên ngoài không phải Facebook.</p>
                                           <p> Token thường có giá trị sử dụng trong vài ngày , nó thay đổi thường xuyên và là một chuổi mã hóa rất dài tự động tạo ra.</p>
                                           <p > Vì thế quản lý Token rất khó khăn, và thường bị thay đổi theo thời gian thực hoặc khi có các tác động như tài khoản đổi mật khẫu , fanpage đổi id định danh , ...vv</p>
                                           <p > Vì thế nếu có vấn đề khi không thể cập nhật các bài viết mới hay đồng bộ tài khoản hãy thử làm theo các hướng dẫn tại  <a href="docs/fb.pdf" style="color:red">ĐÂY </a> và nhập Token vào ô dưới đây :</p>
                                            <div class="input-group">
                                      <span class="input-group-btn">
                                        <button class="btn btn-default" type="button">Facebook Token</button>
                                      </span>
                                      <input type="text" runat="server" id="txtNewToken" class="form-control" placeholder="'<%=last_token %>'"/>
                                    </div><!-- /input-group -->
                                           <asp:Button ID="btnUpdateToken" CssClass="btn btn-success" runat="server" OnClick="btnUpdateToken_Click" Text="Cập nhật " Height="35" />  
                                 <span class="input-group-btn" id="result" runat="server"></span>
                                          </div>
                                    <div style="width:100%;height:100px;clear:both">
                                        <p style="float:right;margin:1%"> Nhóm phát triễn
                                            </p>
                                    </div>
                                </div>
                              </div>
                            </div>
                            </div>
                      <!-- / -->
                    </div>
                </div>
         <!--đóng menu bên -->
        <!-- Nội dung  các bài viết bên phải -->
         <div class="col-xs-12 col-sm-9 ]">
             <%         int i = 1;  // đếm vị trí
                 foreach(System.Data.DataRow row in objTblFbPost.Rows) {  %>
            <div class="[ panel panel-default ] panel-facebook-plus">
                <div class="dropdown">
                    <span class="dropdown-toggle" type="button" data-toggle="dropdown">
                        <span class="[ glyphicon glyphicon-chevron-down ]"></span>
                    </span>
                    <ul class="dropdown-menu" role="menu">
                        <li role="presentation">
                            
                            <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse<%=row["id"].ToString().Trim()%>" aria-expanded="true" aria-controls="collapseTwo">Ẩn tạm thời</a>
                         </li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Bỏ đăng trên web</a></li>
                        <li role="presentation" class="divider"></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Chỉnh sửa lại</a></li>
                    </ul>
                </div>
                <div class="panel-facebook-plus-tags">
                    <ul>
                        <li><a href="https://www.facebook.com/ngheansunshine/posts/<%=row["id"]+"" %>:0"> #<%=row["id"] %> </a></li>
                    </ul>
                </div>
                <div class="panel-heading">
                    <div class="input-group" style="margin-left:-2% ;">
                    <div id="radioBtn" class="btn-group">
    					<a class="btn btn-primary btn-sm radio_notActive " data-toggle="happy" data-title="Y"> WEB </a>
    					<a class="btn btn-primary btn-sm radio_active" data-toggle="happy" data-title="Y"> FACEBOOK  </a>
    				</div>
                        </div>
                    <h3> [<%=i%> ]</h3>
                    <%i++; %>
                    <h5 ><span style="margin-left:-6% !important">Ngày đăng </span> - 
                        <span><%=row["create_time"].ToString().Substring(0,10) %></span> </h5>
                </div>
                <div id="collapse<%=row["id"].ToString().Trim()%>"  class="panel-body in">
                    <br />
                    <p>
                      <%=row["message"] %>                
                    </p>
                    <br />
                    <a class="panel-facebook-plus-image" href="#">
                       <img src="<%=row["full_picture"] %>" />
                    </a>
                </div>
                <div class="panel-footer">
                   
                    <button type="button" class="[ btn btn-default ]"><%=row["likes"] %>  <span class="alert info">likes</span> </button>
                     <button type="button" class="[ btn btn-default ]"><%=row["comments"] %> <span class="alert info">comment</span> </button>
                </div>
            </div>
             <% } %>

            
        </div>
    </div>
    </div>
   
      
</asp:Content>


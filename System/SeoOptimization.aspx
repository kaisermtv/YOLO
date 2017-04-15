<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/System.master" AutoEventWireup="true" CodeFile="SeoOptimization.aspx.cs" Inherits="System_SeoOptimization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
     <link href="../css/System/fbPage.css" rel="stylesheet" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <div class="row">
        <div class="col-md-3  ">
            <div class="list-group">
                         <a href="#" class="list-group-item " data-toggle="modal" data-target=".smallModalRefresh">
                            <h3 class="pull-right">
                                <img src="../images/googlelogo.png" height="40"  />
                            </h3>
                            <h4 class="list-group-item-heading " >&nbsp;
                                </h4>
                            <p class="list-group-item-text">
                             Google
                            </p>
                        </a>
                        <!-- Cập nhật lại các bài mới thêm từ facebook -->
                        <div class="modal fade smallModalRefresh" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
                              <div class="modal-dialog modal-sm" role="document">
                                <div class="modal-content">
                                <div class="alert info">  Xem trạng thái của trang web với Google Seo Optimization 
                                    <br />
                                     <small> ( Trang web sẻ được kiểm tra bằng tool tự động tới  /sitemap.xml /robots.txt  )    </small> 
                                </div>
                                      <div class="center" >  
                                  <asp:Button ID="btnChecking" CssClass="btn btn-success" Width="300" runat="server" Text="Xem trạng thái" OnClick="btnChecking_Click" /></div>  
                                    <div style="width:100%;height:10px;"></div>
                                </div>
                              </div>
                            </div>
                         <!-- / -->
                         <a href="#" class="list-group-item " data-toggle="modal" data-target=".smallModalUpdate">
                            <h3 class="pull-right">
                              <img src="../images/site-map-icon.jpg"   height="40"  />
                            </h3>
                            <h4 class="list-group-item-heading ">&nbsp;
                                </h4>
                            <p class="list-group-item-text">
                               Chỉnh sửa sitemap.xml
                            </p>
                        </a>
                        <!-- Xác nhận lại - Thao tác làm cập nhật toàn bộ dử liệu-->
                        <div class="modal fade smallModalUpdate" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel">
                              <div class="modal-dialog modal-sm" role="document">
                                <div class="modal-content">
                                <div class="alert info"> Sau khi nhấn nút [ Tải nội dung ] bạn có thể  lưu lại  nội dung vừa tạo và lưu lại với tên sitemap.xml  
                                     <br />  
                                 <small> ( nhấn ctr + s và đặt lại tên )     </small> 
                                       <br />     <br />    <br />  
                                        Sau khi nhấn nút [ Biên dịch ] Tệp tin  sitemap.xml của trang web sẻ được cập nhật mới hoặc tạo ra , các nội dung được làm mới tự động .  
                                </div>
                                    <div class="center-block" > 
                                  <asp:Button ID="btnXmlDownload" CssClass="btn btn-danger" Width="145" runat="server" Text="Biên dịch"  OnClick="btnXmlDownload_Click" />
                                    <asp:Button ID="btnXmlWatch" CssClass="btn btn-info" Width="145" runat="server" Text="Tải nội dung"  OnClick="btnXmlWatch_Click"/></div>   
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
                                        <div style="margin:3%">
                                         <p>  Sitemap.xml được khai báo trong tệp <a href="~/robots.txt">robots.txt</a> 
                                            </p>
                                            <p>Kĩ thuật SEO website là một kỹ thuật không phức tạp nhưng khá đa dạng , có nhiều cách thực hiện</p>
                                           <p >  SEO các web site từ các nền tảng khác nhau cần những kỹ thuật khác nhau</p> 
                                            <p>Các chức năng được tích hợp trong web site chỉ là những cách cơ bản để Google hay các mạng tìm kiếm khác dể dàng nhận ra trang web ,  
                                           nếu muốn các tìm kiếm , từ khóa nằm trong top hiễn thị của google,bring ...vvv còn nhiều việc thủ công khác . </p>  
                                           <p>Chúng ta có thể viết ra một sitemap.xml chuẩn và thường xuyên và đệ trình tới google,bring ... để được xem xét và đánh giá cao hơn trong kết quả tìm kiếm của họ  </p>  
                                            <br />
                                              <a href="tvs_seo.pdf" > <span class="success">Xem thêm</span></a>
                                            <br />
                                            <hr />
                                               <img src="../images/submitting-sitemap.png" width="800" />
<!--PDF FILE-->
                                            <br />
                                            <iframe width="560" height="315" src="https://www.youtube.com/embed/rTuQvs3VJLM" frameborder="0" allowfullscreen></iframe>
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
             </div>
      <!--đóng menu bên -->
         <div class="col-xs-12 col-sm-9 ]">
                 Hướng dẫn hoặc các thông số
                    
        </div>
</asp:Content>


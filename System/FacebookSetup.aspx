<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/System.master" AutoEventWireup="true" CodeFile="FacebookSetup.aspx.cs" Inherits="System_FacebookSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    <style>
       
body { margin-top:20px; }

a { transition: all .3s ease;-webkit-transition: all .3s ease;-moz-transition: all .3s ease;-o-transition: all .3s ease; }
/* Visitor */
a.visitor i,.visitor h4.list-group-item-heading { color:#E48A07; }
a.visitor:hover { background-color:#E48A07; }
a.visitor:hover * { color:#FFF; }
/* Facebook */
.panel-facebook-plus {
    position: relative;
    border-radius: 0px;
    border: 1px solid rgb(216, 216, 216);
    font-family: 'Roboto', sans-serif;
}
.panel-facebook-plus > .dropdown {
    position: absolute;
    top: 5px;
    right: 15px;
}
.panel-facebook-plus > .dropdown > span > span {
    font-size: 10px;   
}
.panel-facebook-plus > .dropdown > .dropdown-menu {
    left: initial;
    right: 0px;
    border-radius: 2px;
}
.panel-facebook-plus > .panel-facebook-plus-tags {
    position: absolute;
    top: 35px;
    right: -3px;
}
.panel-facebook-plus > .panel-facebook-plus-tags > ul {
    list-style: none;
    padding: 0px;
    margin: 0px;
}
.panel-facebook-plus > .panel-facebook-plus-tags > ul:hover {
    box-shadow: 0px 0px 3px rgb(0, 0, 0);   
    box-shadow: 0px 0px 3px rgba(0, 0, 0, 0.25);   
}
.panel-facebook-plus > .panel-facebook-plus-tags > ul > li {
    display: block;
    right: 0px;
    width: 0px;
    padding: 5px 0px 5px 0px;
    background-color: rgb(245, 245, 245);
    font-size: 12px;
    overflow: hidden;
}
.panel-facebook-plus > .panel-facebook-plus-tags > ul > li::after {
    content:"";
    position: absolute;
    top: 0px;
    right: 0px;
    height: 100%;
	border-right: 3px solid rgb(66, 127, 237);
}
.panel-facebook-plus > .panel-facebook-plus-tags > ul:hover > li,
.panel-facebook-plus > .panel-facebook-plus-tags > ul > li:first-child {
    padding: 5px 15px 5px 10px;
    width: auto;
    cursor: pointer;
    margin-left: auto;
}
.panel-facebook-plus > .panel-facebook-plus-tags > ul:hover > li {
    background-color: rgb(255, 255, 255);   
}
.panel-facebook-plus > .panel-facebook-plus-tags > ul > li:hover {
    background-color: rgb(66, 127, 237);
    color: rgb(255, 255, 255);
}
.panel-facebook-plus > .panel-heading,
.panel-facebook-plus > .panel-footer {
    background-color: rgb(255, 255, 255);
    border-width: 0px; 
}
.panel-facebook-plus > .panel-heading {
    margin-top: 20px;    
    padding-bottom: 5px; 
}
.panel-facebook-plus > .panel-heading > img { 
    margin-right: 15px;
}
.panel-facebook-plus > .panel-heading > h3 {
    margin: 0px;
    font-size: 14px;
    font-weight: 700;
}
.panel-facebook-plus > .panel-heading > h5 {
    color: rgb(153, 153, 153);
    font-size: 12px;
    font-weight: 400;
}
.panel-facebook-plus > .panel-body {
    padding-top: 5px;
    font-size: 13px;
}
.panel-facebook-plus > .panel-body > .panel-facebook-plus-image {
    display: block;
    text-align: center;
    background-color: rgb(245, 245, 245);
    border: 1px solid rgb(217, 217, 217);
}
.panel-facebook-plus > .panel-body > .panel-facebook-plus-image > img {
    max-width: 100%;
}

.panel-facebook-plus > .panel-footer {
    font-size: 14px;
    font-weight: 700;
    min-height: 54px;
}
.panel-facebook-plus > .panel-footer > .btn {
    float: left;
    margin-right: 8px;
}
.panel-facebook-plus > .panel-footer > .input-placeholder {
    display: block;
    margin-left: 98px;
    color: rgb(153, 153, 153);
    font-size: 12px;
    font-weight: 400;
    padding: 8px 6px 7px;
    border: 1px solid rgb(217, 217, 217);
    border-radius: 2px;
    box-shadow: rgba(0, 0, 0, 0.0470588) 0px 1px 0px 0px;
}
.panel-facebook-plus.panel-facebook-plus-show-comment > .panel-footer > .input-placeholder {
    display: none;   
}
.panel-facebook-plus > .panel-facebook-plus-comment {
    display: none;
    padding: 10px 20px 15px;
    border-top: 1px solid rgb(229, 229, 229);
    background-color: rgb(245, 245, 245);
}
.panel-facebook-plus.panel-facebook-plus-show-comment > .panel-facebook-plus-comment {
    display: block;
}
/*.panel-facebook-plus > .panel-facebook-plus-comment > img {
    float: left;   
}*/
.panel-facebook-plus > .panel-facebook-plus-comment > .panel-facebook-plus-textarea {
    float: right;
    width: calc(100% - 56px);
}
.panel-facebook-plus > .panel-facebook-plus-comment > .panel-facebook-plus-textarea > textarea {
    display: block;
    /*margin-left: 60px;
    width: calc(100% - 56px);*/
    width: 100%;
    background-color: rgb(255, 255, 255);
    border: 1px solid rgb(217, 217, 217);
    box-shadow: rgba(0, 0, 0, 0.0470588) 0px 1px 0px 0px;
    resize: vertical;
}
.panel-facebook-plus > .panel-facebook-plus-comment > .panel-facebook-plus-textarea > .btn {
    margin-top: 10px;
    margin-right: 8px;
    width: 100%;
}
@media (min-width: 992px) {
    .panel-facebook-plus > .panel-facebook-plus-comment > .panel-facebook-plus-textarea > .btn {
        width: auto;
    }    
}
.panel-facebook-plus .btn {
    border-radius: 3px;   
}
.panel-facebook-plus .btn-default {
    border: 1px solid rgb(217, 217, 217);
    box-shadow: rgba(0, 0, 0, 0.0470588) 0px 1px 0px 0px;
}
.panel-facebook-plus .btn-default:hover, 
.panel-facebook-plus .btn-default:focus, 
.panel-facebook-plus .btn-default:active {
    background-color: rgb(255, 255, 255);
    border-color: rgb(0, 0, 0);    
}

    </style>


    <!-- animation text-->
   <%-- <script>
        $({ someValue: 0 }).animate({
            someValue: Math.floor(Math.random() * 3000)
        }, {
            duration: 3000,
            easing: 'swing', // can be anything
            step: function () { // called on every step
                // Update the element's text with rounded-up value:
                $('.count').text(commaSeparateNumber(Math.round(this.someValue)));
            }
        });

        // chia số hàng nghìn , triệu 
        function commaSeparateNumber(val) {
            while (/(\d+)(\d{3})/.test(val.toString())) {
                val = val.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
            }
            return val;
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container">
    <div class="row">
        <div class="col-md-3  ">
            <div class="list-group">
                <a href="#" class="list-group-item visitor">
                    <h3 class="pull-right">
            <img src="../images/article.png" height="40" />
                    </h3>
                    <h4 class="list-group-item-heading count">
                           <%=objTblFbPost.Rows.Count %> </h4>
                    <p class="list-group-item-text">
                       Bài viết</p>
                </a><a href="#modal" class="list-group-item facebook-like">
                    <h3 class="pull-right">
                        <img src="../images/Facebook.png" height="40" />
                       
                    </h3>
                   
                    <h4 class="list-group-item-heading count">
                         <%=objTblFbPost.Rows.Count %>
                        </h4>
                    <p class="list-group-item-text">
                        Facebook Likes</p>
                    
                </a>
                <a href="#" class="list-group-item ">
                    <h3 class="pull-right">
                        <img src="../images/message.png" height="40"  />
                      
                    </h3>
                    <h4 class="list-group-item-heading count">
                              <%=objTblFbPost.Rows.Count %></h4>
                    <p class="list-group-item-text">
                        Bình luận</p>
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
                    </div>
                </div>
         <!--đóng menu bên -->

        <!-- Nội dung  các bài viết bên phải -->
         <div class="col-xs-12 col-sm-9 ]">

            
             <% foreach(System.Data.DataRow row in objTblFbPost.Rows) { %>

            <div class="[ panel panel-default ] panel-facebook-plus">
                <div class="dropdown">
                    <span class="dropdown-toggle" type="button" data-toggle="dropdown">
                        <span class="[ glyphicon glyphicon-chevron-down ]"></span>
                    </span>
                    <ul class="dropdown-menu" role="menu">
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Ẩn</a></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Hiện</a></li>
                        <li role="presentation" class="divider"></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Chỉnh sửa</a></li>
                    </ul>
                </div>
                <div class="panel-facebook-plus-tags">
                    <ul>
                        <li>#<%=row["id"] %> - id bài viết </li>
                    </ul>
                </div>
                <div class="panel-heading">
                    <img class="[ img-circle pull-left ]"  src="../" alt="Web " />
                    <h3>...?</h3>
                    <h5 ><span style="margin-left:-80px !important">Thời gian đăng </span> - 
                        <span><%=row["create_time"].ToString().Substring(0,10) %></span> </h5>
                </div>
                <div class="panel-body">
                    <p>
                      <%=row["message"] %>                
                    </p>
                    <br />
                    <a class="panel-facebook-plus-image" href="#">
                       <img src="<%=row["full_picture"] %>" />
                           </a>
                </div>
                <div class="panel-footer">
                    <button type="button" class="[ btn btn-default ]"><%=row["likes"] %> Thích</button>
                     <button type="button" class="[ btn btn-default ]"><%=row["comments"] %>  Bình luận</button>
                    <button type="button" class="[ btn btn-default ]">x Chia sẻ
                    </button>
                 
                </div>
              
            </div>


             <% } %>
           


            <div class="[ panel panel-default ] panel-facebook-plus">
                <div class="dropdown">
                    <span class="dropdown-toggle" type="button" data-toggle="dropdown">
                        <span class="[ glyphicon glyphicon-chevron-down ]"></span>
                    </span>
                    <ul class="dropdown-menu" role="menu">
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Ẩn</a></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Hiện</a></li>
                        <li role="presentation" class="divider"></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Chỉnh sửa</a></li>
                    </ul>
                </div>
                <div class="panel-facebook-plus-tags">
                    <ul>
                        <li>#1 - Số thứ tự</li>
                    </ul>
                </div>
                <div class="panel-heading">
                    <img class="[ img-circle pull-left ]" src="../" alt="Trạng thái " />

                    <h3>...?</h3>
                    <h5><span>Ngày viết </span> - <span>Jun 25, 2017</span> </h5>
                </div>
                <div class="panel-body">
                    <p>

                                        [KẾT QUẢ MINIGAME 04] Chúc mừng tất cả các bạn có tên trong danh sách sau đã may mắn nhận được TẤM VÉ CỰC HOT XEM LIVESHOW NOO VÀ CÁC CA SĨ NỔI TIẾNG KHÁC TẠI HÀ TĨNH
                Địa điểm nhận vé:
                👉Cửa hàng MobiFone - 161 đường Trần Phú, thành phố Hà Tĩnh
                👉Các bạn cung cấp thông tin cá nhân cho giao dịch viên tại CH để nhận vé nhé
                -----------------------------------
                Yolo - Dám chia sẻ - MobiFone đồng hành cùng tuổi trẻ miền Trung!


                    </p>
                    <a class="panel-facebook-plus-image" href="#">
                        <img src="https://scontent.fhan4-1.fna.fbcdn.net/v/t1.0-0/c0.18.960.505/s526x296/17634687_280142129100341_3008362609302930607_n.jpg?oh=284097cf79b464bee30106a0018ef126&oe=59975E40" />
                    </a>
                </div>
                <div class="panel-footer">
                    <button type="button" class="[ btn btn-default ]">100 Thích</button>
                     <button type="button" class="[ btn btn-default ]">100 Bình luận</button>
                    <button type="button" class="[ btn btn-default ]">100 Chia sẻ
                    </button>
                 
                </div>
              
            </div>
        </div>
    </div>
    </div>

</asp:Content>


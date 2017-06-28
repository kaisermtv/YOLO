<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/Admin.master" CodeFile="NewsComment.aspx.cs" Inherits="System_NewsComment" %>


<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <script>
        function delmodal(id, name) {
            $("#idDel").val(id);
            $("#ttk").html(name);

            $("#myModal").modal("show");
        }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <form method="get" id="seachform">
        <input name="id" type="hidden" value="<%= itemmId %>" />
    <table class="table" border ="0" style ="margin-top:-20px;">
        <tr>
            <td>
                <input type="text" name="Search" value="<%=txtSearch %>" placeholder="Nhập nội dung cần tìm kiếm" class="form-control" />
            </td>
            <td style="width:25%">
                <select name="trangthai" onchange="SubmitForm('seachform');" class="form-control">
                    <option value="-1">Tất cả</option>
                    <option value="0">Chờ duyệt</option>
                    <option value="2">Đã duyệt</option>
                </select>
            </td>
            <td style="width: 40px !important; text-align: center;">
                <input type="image" src="/images/Search.png" style="margin-bottom: -15px; margin-left: -15px;" />
            </td>
        </tr>
    </table>
    </form>

    <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
        <HeaderTemplate>
            <table class="DataListTable">
                <tr class="DataListTableHeader">
                    <th class="DataListTableHeaderTdItemTT" style="width: 4%;">TT</th>
                    <th class="DataListTableHeaderTdItemJustify">Tiêu đề</th>
                    <th class="DataListTableHeaderTdItemJustify" style="width: 20%;">Tên</th>
                    <th class="DataListTableHeaderTdItemJustify" style="width: 20%;">Email</th>
                    <th class="DataListTableHeaderTdItemJustify" style="width: 20%;">Phone</th>
                    <th class="DataListTableHeaderTdItemJustify" style="width: 10%;">Trạng thái</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Sửa</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Xóa</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="DataListTableTdItemTT"><%# this.index++ %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("Subject") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("Name") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("Email") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("Phone") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("NSTATUS").ToString().Replace("2","Đã duyệt").Replace("0","Chờ duyệt") %></td>
                <td class="DataListTableTdItemCenter">
                    <a href="NewsEdit.aspx?id=<%# Eval("Id") %>">
                        <img src="/Images/Edit.png" alt="Chỉnh sửa thông tin">
                    </a>
                &nbsp;&nbsp;</td>
                <td class="DataListTableTdItemCenter">
                    <a href="#myModal" onclick="delmodal(<%# Eval("Id") %>,'<%# Eval("Subject") %>')">
                        <img src="/Images/delete.png" alt="Xóa nhóm">
                    </a>
                &nbsp;&nbsp;</td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <cc1:CollectionPager ID="cpData" runat="server" BackText="" FirstText="Đầu"
        ControlCssClass="ProductPage" LabelText="" LastText="Cuối" NextText="" UseSlider="true"
        ResultsFormat="" BackNextLinkSeparator="" ResultsLocation="None" BackNextLocation="None"
        PageNumbersSeparator="&nbsp;">
    </cc1:CollectionPager>

    <br />
    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <form method="post">
                <input id="idDel" name="idDel" type="hidden" />
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Xóa bài viết</h4>
                    </div>
                    <div class="modal-body">
                        <p>Bạn xác nhận xóa bài phản hồi của: <b id="ttk"></b></p>
                    </div>
                    <div class="modal-footer">
                        <button type="submit" class="btn btn-primary">Xác nhận xóa</button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>

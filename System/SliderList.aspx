<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" CodeFile="SliderList.aspx.cs" Inherits="System_SliderList" %>

<%@ Register TagPrefix="cc1" Namespace="SiteUtils" Assembly="CollectionPager" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <script>
        function delmodal(id, name) {
            $("#MainContent_idDel").val(id);
            $("#ttk").html(name);

            $("#myModal").modal("show");
        }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
        <HeaderTemplate>
            <table class="DataListTable">
                <tr class="DataListTableHeader">
                    <th class="DataListTableHeaderTdItemTT" style="width: 4%;">TT</th>
                    <th class="DataListTableHeaderTdItemJustify" >Tiêu đề</th>
                    <th class="DataListTableHeaderTdItemJustify" style="width: 40%;">image</th>
                    <th class="DataListTableHeaderTdItemJustify" style="width: 3%;">key</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Up</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Down</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Sửa</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Xóa</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="DataListTableTdItemTT"><%# this.index++ %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("TITLE") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("IMG") %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("NTYPE") %></td>
                <td class="DataListTableTdItemCenter">
                    <center>
                        <a href="SliderMove.aspx?id=<%# Eval("ID") %>&vt=<%# this.index-2 %>">
                            <div class="arrow-up"></div>
                        </a></center>
                </td>
                <td class="DataListTableTdItemCenter">
                    <center><a href="SliderMove.aspx?id=<%# Eval("ID") %>&vt=<%# this.index %>">
                            <div class="arrow-down"></div>
                        </a></center>
                </td>
                <td class="DataListTableTdItemCenter">
                    <a href="SliderEdit.aspx?id=<%# Eval("ID") %>">
                        <img src="/Images/Edit.png" alt="Chỉnh sửa thông tin">
                    </a>
                </td>
                <td class="DataListTableTdItemCenter">
                    <a href="#myModal" onclick="delmodal(<%# Eval("ID") %>,'<%# Eval("TITLE") %>')">
                        <img src="/Images/delete.png" alt="Xóa nhóm">
                    </a>
                </td>
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
    <a href="SliderEdit.aspx" class="btn btn-primary">Thêm Slider</a>

    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
      <div class="modal-dialog">
        <input id="idDel" type="hidden" runat="server" />
        <!-- Modal content-->
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">&times;</button>
            <h4 class="modal-title">Xóa nhóm Slider</h4>
          </div>
          <div class="modal-body">
            <p>Bạn xác nhận xóa Slider <b id="ttk"></b></p>
          </div>
          <div class="modal-footer">
            <asp:Button ID="btnDel" runat ="server" CssClass="btn btn-primary" Text="Xác nhận xóa" OnClick="btnDel_Click" />
            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
          </div>
        </div>

      </div>
    </div>
</asp:Content>

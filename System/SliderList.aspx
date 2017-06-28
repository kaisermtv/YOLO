<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/Admin.master" CodeFile="SliderList.aspx.cs" Inherits="System_SliderList" %>

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
    <form method="get" action="SliderList.aspx" id="seachform">
    <table class="table" border ="0" style ="margin-top:-20px;">
        <tr>
            <td>
                <select name="type" onchange="SubmitForm('seachform');" class="form-control">
                    <option value="1" <%= type==1?"selected=\"selected\"":"" %>>Slider One</option>
                    <option value="2" <%= type==2?"selected=\"selected\"":"" %>>Slider Two</option>
                    <option value="3" <%= type==3?"selected=\"selected\"":"" %>>Slider Three</option>
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
                    <th class="DataListTableHeaderTdItemJustify" >Tiêu đề</th>
                    <th class="DataListTableHeaderTdItemJustify" style="width: 40%;">image</th>
                    <%--<th class="DataListTableHeaderTdItemJustify" style="width: 3%;">key</th>--%>
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
                <%--<td class="DataListTableTdItemJustify"><%# Eval("NTYPE") %></td>--%>
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
    <a href="SliderEdit.aspx?type=<%= type %>" class="btn btn-primary">Thêm Slider</a>

    <form method="post">
        <!-- Modal -->
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <input id="idDel" name="idDel" type="hidden" />
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
                        <button type="submit" class="btn btn-primary">Xác nhận xóa</button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>
    </form>
</asp:Content>

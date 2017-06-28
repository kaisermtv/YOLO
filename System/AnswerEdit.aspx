<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" CodeFile="AnswerEdit.aspx.cs" Inherits="System_AnswerEdit" %>

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
                    <th class="DataListTableHeaderTdItemJustify">Câu trả lời</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Up</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Down</th>
                    <th class="DataListTableHeaderTdItemCenter" style="width: 3%;">Xóa</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="DataListTableTdItemTT"><%# this.index++ %></td>
                <td class="DataListTableTdItemJustify"><%# Eval("Content") %></td>
                <td class="DataListTableTdItemCenter">
                        <center>
                        <a href="AnswerMove.aspx?id=<%# Eval("ID") %>&vt=<%# this.index-2 %>&question=<%# itemId %>">
                            <div class="arrow-up"></div>
                        </a></center>
                    </td>
                    <td class="DataListTableTdItemCenter">
                        <center><a href="AnswerMove.aspx?id=<%# Eval("ID") %>&vt=<%# this.index %>&question=<%# itemId %>">
                            <div class="arrow-down"></div>
                        </a></center>
                    </td>
                <td class="DataListTableTdItemCenter">
                    <a href="#myModal" onclick="delmodal(<%# Eval("Id") %>,'<%# Eval("Content") %>')">
                        <img src="/Images/delete.png" alt="Xóa câu trả lời">
                    </a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <br />
    <div class="row">
        <div class="col-lg-2" style="text-align:right">
            Câu trả lời:
        </div>
        <div class="col-lg-8">
            <asp:TextBox ID="txtAnswer" runat="server" TextMode="MultiLine" class="AdminTextControl"></asp:TextBox>
        </div>
        <div class="col-lg-2">
            <asp:Button ID="btnSave" runat="server" Text="Thêm" CssClass="btn btn-primary"  OnClick="btnSave_Click" />
            <a href="QuestionList.aspx" class="btn btn-default" style="float:right">Trở lại</a>
        </div>
    </div>


    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
      <div class="modal-dialog">
        <input id="idDel" type="hidden" runat="server" />
        <!-- Modal content-->
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">&times;</button>
            <h4 class="modal-title">Xóa câu trả lời</h4>
          </div>
          <div class="modal-body">
            <p>Bạn xác nhận xóa câu trả lời: <b id="ttk"></b></p>
          </div>
          <div class="modal-footer">
            <asp:Button ID="btnDel" runat ="server" CssClass="btn btn-primary" Text="Xác nhận xóa" OnClick="btnDel_Click" />
            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
          </div>
        </div>

      </div>
    </div>
</asp:Content>

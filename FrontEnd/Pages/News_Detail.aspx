<%@ Page Language="C#" MasterPageFile="../../App_Master/Site.master" AutoEventWireup="true" CodeFile="News_Detail.aspx.cs" Inherits="FrontEnd_Pages_News_Detail" %>


<%@ Register Src="~/FrontEnd/Controls/News/DanhMuc.ascx" TagPrefix="uc1" TagName="DanhMuc" %>
<%@ Register Src="~/FrontEnd/Controls/Common/QuangCao.ascx" TagPrefix="uc1" TagName="QuangCao" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MasterPageContent" runat="server">


    <div class="container-fluid">
        <div class="main">
            <div class="row show-grid">
                <div class="news-wraper col-xs-12 col-md-12">
                    <div class="row show-grid">
                        <div class="clearfix visible"></div>
                        <div class="cleft col-xs-12 col-sm-8 col-md-8 " style="padding-top: 20px;">
                            <div class="row">
                                <div class="col-xs-12 col-sm-12 col-md-12">
                                    <h3 class="tieu-de" style="margin-top: 10px; margin-bottom: 10px"><%= objData["Title"] %></h3>
                                    <label class="time">Ngày đăng: <%= ((DateTime)objData["DayPost"]).ToString("dd/MM/yyyy h:mm:ss tt") %></label>
                                    <p class="sapo" style="font-weight: bold; margin-bottom: 10px; font-size: 16px;">
                                        <%=objData["ShortContent"]  %>
                                    </p>
                                    <div class="content-detail">
                                        <%=objData["Content"]  %>
                                    </div>

                                </div>
                            </div>
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
</asp:Content>

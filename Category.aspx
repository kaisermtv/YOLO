<%@ Page Language="C#" Title="Danh mục" AutoEventWireup="true" MasterPageFile="~/App_Master/Site.master" CodeFile="Category.aspx.cs" Inherits="Category" %>

<%@ Register Src="~/Controller/Paging.ascx" TagPrefix="uc1" TagName="Paging" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<link rel="stylesheet" type="text/css" href="/css/style1.css">--%>
    <style>
        .pagination {
            width: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row col-md-12">
            <h2 class ="H2TraiNghiem"><%= title.ToUpper() %></h2>
            <br />
        </div>
        <div class="container_inner default_template_holder clearfix page_container_inner">
            <div class="vc_row wpb_row section vc_row-fluid" style="padding-top: 0px; text-align: left;">
                <div class=" full_section_inner clearfix">
                    <div class="vc_col-sm-12 wpb_column vc_column_container">
                        <div class="wpb_wrapper">
                            <div class="projects_holder_outer v3 portfolio_with_space portfolio_standard ">
                                <%--<div class="filter_outer">
                                    <div class="filter_holder">
                                        <ul>
                                            <li class="filter active current" data-filter="all"><span>All</span></li>
                                            <li class="filter" data-filter="portfolio_category_17"><span>Art</span></li>
                                            <li class="filter" data-filter="portfolio_category_2"><span>Business</span></li>
                                            <li class="filter" data-filter="portfolio_category_5"><span>Photography</span></li>
                                        </ul>
                                    </div>
                                </div>--%>
                                <div class="projects_holder clearfix v3 standard">
                                    <asp:Repeater ID="dtlData" runat="server" EnableViewState="False">
                                        <ItemTemplate>
                                            <article class="mix portfolio_category_17 portfolio_category_5  mix_all" style="display: inline-block; opacity: 1;">
                                                <div class="image_holder">
                                                    <a class="portfolio_link_for_touch" href="#" target="_self">
                                                        <span class="image">
                                                            <img width="1100" height="825" onerror="imgCatchError(this)" src="<%# Eval("ImgUrl") %>" class="attachment-full wp-post-image" alt="qode interactive strata">
                                                        </span>
                                                    </a>
                                                    <span class="text_holder">
                                                        <span class="text_outer">
                                                            <span class="text_inner">
                                                                <span class="feature_holder">
                                                                    <span class="feature_holder_icons">
                                                                        <a class="lightbox qbutton small white" id = "TraiNghiemZoom" title="Stockholm Fashion" href="<%# Eval("ImgUrl") %>" data-rel="prettyPhoto[pretty_photo_gallery]" rel="prettyPhoto[pretty_photo_gallery]">zoom</a>
                                                                        <a class="preview qbutton small white" href="/trai-nghiem/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-ct<%#Eval("Id")%>" target="_self">view</a>
                                                                    </span>
                                                                </span>
                                                            </span>
                                                        </span>
                                                    </span>
                                                </div>
                                                <div class="portfolio_description ">
                                                    <h5 class="portfolio_title"><a href="/trai-nghiem/<%# SystemClass.convertToUnSign2(Eval("Title").ToString()) %>-ct<%#Eval("Id")%>" target="_self"><%# Eval("Title") %></a></h5>
                                                    <span class="project_category"><%# Eval("GroupName") %></span>
                                                </div>
                                            </article>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <div class="filler"></div>
                                    <div class="filler"></div>
                                    <div class="filler"></div>
                                </div>

                                <uc1:Paging ID="pageId" runat="server" />

                                <%--<div class="portfolio_paging"><span rel="2" class="load_more"><a href="#">Show more</a></span></div>
                                <div class="portfolio_paging_loading"><a href="javascript: void(0)" class="qbutton">Loading...</a></div>--%>
                            </div>
                            <div class="separator  transparent center  " style="margin-top: 20px; margin-bottom: 20px;"></div>

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

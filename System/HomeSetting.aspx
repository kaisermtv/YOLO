<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Master/System.master" CodeFile="HomeSetting.aspx.cs" Inherits="System_HomeSetting" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .line {
            margin-top: 6px;
        }

        .headlabel {
            margin-top: 10px;
            font-size: 16px;
            padding: 3px;
            padding-left: 15px;
            background-color: #00ffff;
            margin-right: 6px !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row headlabel">
        <b>I. Slider 1</b>
    </div>
    <div class="row line">
        <div class="col-sm-12">
            <a href="/System/SliderList.aspx" class="btn btn-primary">Cài đặt</a>
        </div>
    </div>
    <div class="row headlabel">
        <b>II. Đoạn 2</b>
    </div>
    <div class="row headlabel">
        <b>III. Slider 3</b>
    </div>
    <div class="row line">
        <div class="col-sm-12">
            <a href="/System/SliderList.aspx?type=2" class="btn btn-primary">Cài đặt</a>
        </div>
    </div>
    <div class="row headlabel">
        <b>IV. Đoạn 4</b>
    </div>
    <div class="row line">
        <div class="col-sm-12">
            <a href="/System/SliderList.aspx?type=3" class="btn btn-primary">Cài đặt</a>
        </div>
    </div>
    <div class="row headlabel">
        <b>V. Đoạn 5</b>
    </div>
</asp:Content>

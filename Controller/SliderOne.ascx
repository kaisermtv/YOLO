<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SliderOne.ascx.cs" Inherits="Controller_SliderOne" %>
<% if (lengSlider > 0){ %>
    <!-- KHOI SO 1 - SLIDE -->
    <div style="height: 550px; position: relative!important;">
        <script type="text/javascript">
            $(document).ready(function () {
                // invoke the carousel
                $('#myCarousel').carousel({
                    interval: 6000
                });

                // scroll slides on mouse scroll 
                //$('#myCarousel').bind('mousewheel DOMMouseScroll', function (e) {

                //    if (e.originalEvent.wheelDelta > 0 || e.originalEvent.detail < 0) {
                //        $(this).carousel('prev');


                //    }
                //    else {
                //        $(this).carousel('next');

                //    }
                //});

                //scroll slides on swipe for touch enabled devices 

                $("#myCarousel").on("touchstart", function (event) {

                    var yClick = event.originalEvent.touches[0].pageY;
                    $(this).one("touchmove", function (event) {

                        var yMove = event.originalEvent.touches[0].pageY;
                        if (Math.floor(yClick - yMove) > 1) {
                            $(".carousel").carousel('next');
                        }
                        else if (Math.floor(yClick - yMove) < -1) {
                            $(".carousel").carousel('prev');
                        }
                    });
                    $(".carousel").on("touchend", function () {
                        $(this).off("touchmove");
                    });
                });

            });
            //animated  carousel start
            $(document).ready(function () {

                //to add  start animation on load for first slide 
                $(function () {
                    $.fn.extend({
                        animateCss: function (animationName) {
                            var animationEnd = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
                            this.addClass('animated ' + animationName).one(animationEnd, function () {
                                $(this).removeClass(animationName);
                            });
                        }
                    });
                    $('.item1.active img').animateCss('slideInDown');
                    $('.item1.active h2').animateCss('zoomIn');
                    $('.item1.active p').animateCss('fadeIn');

                });

                //to start animation on  mousescroll , click and swipe



                $("#myCarousel").on('slide.bs.carousel', function () {
                    $.fn.extend({
                        animateCss: function (animationName) {
                            var animationEnd = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
                            this.addClass('animated ' + animationName).one(animationEnd, function () {
                                $(this).removeClass(animationName);
                            });
                        }
                    });

                    // add animation type  from animate.css on the element which you want to animate
                    <% for(int i = 1;i<=lengSlider;i++){ int x = rnd.Next(1,3); %>
                    <% if(i%3 == 1 ){ %>
                    $('.item<%=i%> img').animateCss('slideInDown');
                    $('.item<%=i%> h2').animateCss('zoomIn');
                    $('.item<%=i%> p').animateCss('fadeIn');
                    <% } else if(i%3 == 2) { %>
                    $('.item<%=i%> img').animateCss('zoomIn');
                    $('.item<%=i%> h2').animateCss('swing');
                    $('.item<%=i%> p').animateCss('fadeIn');
                    <% } else { %>
                    $('.item<%=i%> img').animateCss('fadeInLeft');
                    $('.item<%=i%> h2').animateCss('fadeInDown');
                    $('.item<%=i%> p').animateCss('fadeIn');
                    <% } %>
                    <% } %>

                    

                    
                });
            });

        </script>
        <div style="height: 550px!important; margin-top: -20px;">
            <section class="slide-wrapper">
                <div class="container" style="margin-left: 0px!important;">
                    <div id="myCarousel" class="carousel slide">
                        <!-- Indicators -->
                        <ol class="carousel-indicators">
                            <% for(int i = 0;i<lengSlider;i++){ %>
                            <li data-target="#myCarousel" data-slide-to="<%=i%>"<%= i==0?" class=\"active\"":"" %>></li>
                            <% } %>
                        </ol>

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner">
                            <asp:Repeater ID="dtlSliderOne" runat="server" EnableViewState="False">
                                <ItemTemplate>
                                    <div class="item item<%# index %><%# index++ ==1?" active":"" %>">
                                        <div class="fill" style="background-color: #48c3af; padding-top: 20px;">
                                            <div class="inner-content">
                                                <div class="carousel-img">
                                                    <a href="<%# Eval("LINK") %>" ><img src="<%# Eval("IMG") %>" alt="sofa" class="img img-responsive" /></a>
                                                </div>
                                                <div class="carousel-desc">
                                                    <a href="<%# Eval("LINK") %>" ><h2><%# Eval("TITLE") %></h2></a>
                                                    <p><%# Eval("DESCRIBE").ToString().Replace("\n","<br />") %></p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
    <!-- KET THUC KHOI SO 1 -->
<% } %>
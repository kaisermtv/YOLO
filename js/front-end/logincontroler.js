var auth2;
function initGoogle() {
    console.log('googe loaded');
    LoginController.Google.init();
}
var LoginController = {
    LoginType: {
        YoLo: 'yolo',
        Facebook: 'facebook',
        Google: 'google',
        Twitter: 'twitter'
    },
    ShowLoginForm: function (callback) {
        if ($("#login_overlay").length > 0) {
            $("#login_overlay").show();
            $("#loginpopupform").show();
        } else {
            var boxLogin = '<div class="popupContainer" id="loginpopupform"></div><div id="login_overlay" onclick="LoginController.CloseLoginForm();"></div>';
            $("body").append(boxLogin);
            $.get("/ajax/loginform.aspx", function (rs) {
                $("#loginpopupform").html(rs);
                $("#login_overlay").show();
                Register.InitLogin(callback);
            });
        }
    },
    CloseLoginForm: function () {
        $("#login_overlay").hide();
        $("#loginpopupform").hide();
    },
    Register: function (data, callback) {
        var me = this;
        //var data={name:name,email:email,phone:phone,password:password,type:'facebook'}
        $.fancybox.showLoading();
        $.post("/handler/register.ashx", data, function (rs) {
            $.fancybox.hideLoading();
            var js = $.parseJSON(rs);
            if (js.Success) {
                alert("Chúc mừng bạn đã đăng ký thành viên của YoLo thành công!");
                if (typeof (callback) == "function") callback();
                else window.location.href = "/your-goal.htm";// "/profile.htm";

                //me.LoadMemberInfo();//load lại thông tin thành viên trên top bar
            } else {
                alert(js.Message);
            }
        });

    },
    Login: function (data, callback) {
        $.fancybox.showLoading();
        $.post("/handler/login.ashx", data, function (rs) {
            $.fancybox.hideLoading();
            var js = $.parseJSON(rs);
            if (js.Success) {

                if (typeof callback == "function") callback();
                else {
                    if (js.ErrCode === 100)//đăng ký tk thông qua đăng nhập
                    {
                        window.location.href = "/exam-test.htm";
                    } else {
                        var returnUrl = getParameterByName("returnUrl");
                        //alert(returnUrl);
                        if (typeof (returnUrl) != "undefined" && returnUrl != '' && returnUrl != null) {
                            window.location.href = returnUrl;
                        } else window.location.href = "/history.htm";//window.location.reload();
                    }
                }
            } else {
                alert(js.Message);
            }
        });
    },
    LogOut: function () {
        //document.cookie = "UserInfo=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
        //document.cookie = "PortalUser=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
        //window.location.href = "/";
        $.get("/handler/logout.ashx", function () {
            window.location.href = "/";
        });
    },
    LoadMemberInfo: function (data) {
        var cookieInfo = getCookie("UserInfo");
        console.log(cookieInfo);
        var fullname = getChildCookie("UserInfo", "Fullname");
        console.log(fullname);
    },
    Facebook: {
        Init: function (callBackFunction) {
            callBackFunction();
        },
        fields: ['id', 'name', 'first_name', 'middle_name', 'last_name', 'gender', 'locale', 'languages', 'link',
            'age_range', 'birthday', 'cover', 'education', 'email', 'hometown', 'location', 'picture', 'quotes', 'website', 'work'].join(','),
        checkLoginState: function (callBackFunc) {
            var me = this;
            FB.getLoginStatus(function (response) {
                if (typeof callBackFunc != "undefined") callBackFunc(response);
            });
        },
        getInfo: function (callBackFunc) {
            var me = this;
            FB.login(function (response) {
                //if login was successful, execute the following code
                if (response.authResponse) {
                    FB.api('/me', 'GET', { fields: me.fields }, function (rs) {
                        if (typeof callBackFunc != "undefined") callBackFunc(rs);
                    });
                }
            });
        },
        doLogin: function (callBackFunc) {
            var me = this;
            FB.login(function (response) {
                // handle the response
                if (response.authResponse) {
                    FB.api('/me', 'GET', { fields: me.fields }, function (rs) {
                        var token = GenerateRandomString(15);// generate token
                        setCookie("facebook_token", token, 1);// use to validate in server side
                        if (typeof callBackFunc != "undefined") callBackFunc(rs);
                    });
                }
                ;

            }, { scope: 'public_profile,email' });
        },
        registerToYoLo: function (response) {
            var data = {
                fullname: response.name,
                email: response.email,
                username: response.id,
                mobile: response.phone,
                avatar: response.picture.data.url,
                password: jsEncode.encode(response.id),
                logintype: LoginController.LoginType.Facebook
            };
            if (data.email == null || data.email == '') {
                alert('Tài khoản facebook của bạn không hợp lệ vì chưa cập nhật thông tin email! Vui lòng cập nhật thông tin email trong tài khoản facebook hoặc dùng tài khoản khác để đăng ký! Cảm ơn!');
                return false;
            }
            var token = GenerateRandomString(15);// generate token
            setCookie("facebook_token", token, 1);// use to validate in server side
            LoginController.Register(data); //Register
        },
        loginToYoLo: function (response) {
            console.log(response);
            var data = {
                fullname: response.name,
                email: response.email,
                username: response.id,
                mobile: response.phone,
                avatar: response.picture.data.url,
                password: jsEncode.encode(response.id),
                logintype: LoginController.LoginType.Facebook
            };

            LoginController.Login(data);
        }
    },
    Google: {
        apiKey: 'X6VxFSF3cDHAZx9a10Ufp3rp',
        clientid: '726467508156-uafukf4ke86eg1q17au2lh53e3lsnqsg.apps.googleusercontent.com',
        scopes: 'https://www.googleapis.com/auth/plus.me',
        init: function () {
            console.log('google inited!');
            var me = this;
            gapi.client.setApiKey(me.apiKey);
            gapi.load('auth2', function () {
                auth2 = gapi.auth2.init({
                    client_id: me.clientid,//'726467508156-uafukf4ke86eg1q17au2lh53e3lsnqsg.apps.googleusercontent.com',
                    // Scopes to request in addition to 'profile' and 'email'
                    scope: 'profile'
                }).then(function () {
                    auth2 = gapi.auth2.getAuthInstance();
                });
                ;
            });


        },
        loginGoogle: function (callback) {
            var me = this;
            auth2.signIn().then(function () {
                console.log(auth2.currentUser.get().getId());
                if (auth2.isSignedIn.get()) {
                    var profile = auth2.currentUser.get().getBasicProfile();
                    var token = GenerateRandomString(15);// generate token
                    setCookie("google_token", token, 1);// use to validate in server side
                    var data = {
                        fullname: profile.getName(),
                        email: profile.getEmail(),
                        username: profile.getId(),
                        mobile: '',
                        avatar: profile.getImageUrl(),
                        password: "",
                        logintype: LoginController.LoginType.Google
                    };
                    LoginController.Login(data);
                }
            });
        },
        checkAuth: function () {
            var me = this;
            var data = { client_id: LoginController.Google.clientid, scope: LoginController.Google.scopes, immediate: true };
            console.log(data);
            gapi.auth.authorize(data, me.handleAuthResult);
        },
        handleAuthResult: function (authResult) {
            console.log(authResult);
        },
        makeApiCall: function () {
            gapi.client.load('people', 'v1', function () {
                var request = gapi.client.people.people.get({
                    resourceName: 'people/me'
                });
                request.execute(function (resp) {
                    //var p = document.createElement('p');
                    //var name = resp.names[0].givenName;
                    //p.appendChild(document.createTextNode('Hello, '+name+'!'));
                    //document.getElementById('content').appendChild(p);
                    console.log('make api call', resp);
                });
            });
            // Note: In this example, we use the People API to get the current
            // user's name. In a real app, you would likely get basic profile info
            // from the GoogleUser object to avoid the extra network round trip.
            console.log(auth2.currentUser.get().getBasicProfile().getGivenName());
        }
    },
    Twitter: function () {

    }
};

var Register = {
    Init: function () {
        $("#btnFacebook").click(function () {
            LoginController.Facebook.doLogin(LoginController.Facebook.registerToYoLo);
        });
        $("#btnGoogle").click(function () {
            //YoLo.LoginController.Facebook.doLogin(YoLo.LoginController.Facebook.registerToYoLo);
            LoginController.Google.loginGoogle();
            alert('Chức năng đang xây dựng');
        });
        $("#btnTwitter").click(function () {
            //YoLo.LoginController.Facebook.doLogin(YoLo.LoginController.Facebook.registerToYoLo);
            //alert('Chức năng đang xây dựng');
        });
        $("#btnLinkedIn").click(function () {
            //YoLo.LoginController.Facebook.doLogin(YoLo.LoginController.Facebook.registerToYoLo);
            alert('Chức năng đang xây dựng');
        });
        $("#btnYoLo").click(function () {
            if (ReCaptcha.validateReCaptcha() == false) return;
            //alert('Chức năng đang xây dựng');

            var data = {
                fullname: $("#fullname").val(),
                email: $("#email").val(),
                mobile: $("#mobile").val(),
                avatar: "",
                password: $("#password").val(),
                logintype: "yolo"
            };

            if ($("#password").val() != $("#repassword").val() || !validateEmail(data.email) || !isNumber(data.mobile) || data.password.length == 0) {
                alert("Bạn vui lòng nhập đúng và đầy đủ thông tin");
                return;
            }


            LoginController.Register(data);
        });
    },
    InitLogin: function (callback) {
        $("#btnFacebook").click(function () {
            LoginController.Facebook.doLogin(LoginController.Facebook.loginToYoLo);
        });
        $("#btnGoogle").click(function () {
            LoginController.Google.loginGoogle();
            //alert('Chức năng đang xây dựng');
            //auth2.grantOfflineAccess({ 'redirect_uri': 'postmessage' }).then(signInCallback);
        });
        $("#btnTwitter").click(function () {
            //YoLo.LoginController.Facebook.doLogin(YoLo.LoginController.Facebook.registerToYoLo);
            alert('Chức năng đang xây dựng');
        });
        $("#btnLinkedIn").click(function () {
            //YoLo.LoginController.Facebook.doLogin(YoLo.LoginController.Facebook.registerToYoLo);
            alert('Chức năng đang xây dựng');
        });
        $("#btnLogin").click(function () {
            var data = {
                email: $("#email").val(),
                password: $("#password").val(),
                logintype: "yolo"
            };
            LoginController.Login(data, callback);
            //alert('Chức năng đang xây dựng');
        });

        $("#forgotpass").click(function () {
            $("#login-form").hide();
            $("#resetpassword").fadeIn();
            //$.fancybox({
            //    autoSize: false,
            //    width: 600,
            //    height:'auto',
            //    padding : 0,//remove white and border
            //    href: '/ajax/member/passwordpopup.aspx?c=reset',
            //    type: 'ajax',
            //    beforeShow: function () {
            //        $(".fancybox-skin").addClass("boxchangepass").addClass("boxforgetpass");
            //        $(".fancybox-skin").prepend('<div class="bcp-top"><h3 class="bcpt-titlle">Đặt lại mật khẩu</h3></div>');
            //    }
            //});
        });

        $("#btnResetPassSubmit").click(function () {
            $(this).text("Processing...");
            var email = $("#emailreceivepass").val();
            if (validateEmail(email)) {
                $.getJSON("/handler/member/datahandler.ashx", { c: "resetpassword", email: email }, function (rs) {
                    if (rs.Success) {

                        $("#hdMail").val(email);
                        $("#changepassword .sucssemail").text(email);
                        $("#resetpassword").hide();
                        $("#changepassword").fadeIn();
                    } else {
                        $(this).text("Reset Password");
                        alert(rs.Message);
                    }
                });
            } else alert('Email không hợp lệ');
        });

    }
};

function GenerateRandomString(length) {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    for (var i = 0; i < length; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));
    return text;
}
function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}
function isNumber(number) {
    if (isNaN(number)) {
        return false;
    }
    return true;
}
function GetFlashPlayer(a) { if (window.document[a]) { return window.document[a] } if (navigator.appName.indexOf("Microsoft Internet") == -1) { if (document.embeds && document.embeds[a]) { return document.embeds[a] } } else { return document.getElementById(a) } }

function isiPad() {
    return isSmartPhone();
    //return (navigator.userAgent.match(/iPad/i) != null);
}

function isSmartPhone() {
    return (navigator.userAgent.match(/(iPhone|iPod|iPad|Android|BlackBerry|Windows Phone|webOS)/i) != null);
}
String.prototype.htmlEncode = function () {
    return $('<div/>').text(this).html();
};

String.prototype.htmlDecode = function () {
    return $('<div/>').text(this).text();
};

String.prototype.toSubString = function (length) {
    var p = this;
    if (p == '' || p.Length <= length)
        return p;
    var indexOfSpace = p.lastIndexOf(' ');
    p = p.substring(0, Math.min(p.length, length));
    if (p.length > indexOfSpace)
        p = p.substring(0, indexOfSpace);
    return p;
};
//Array.prototype.unique = function () {
//    var a = this.concat();
//    for (var i = 0; i < a.length; ++i) {
//        for (var j = i + 1; j < a.length; ++j) {
//            if (a[i] === a[j])
//                a.splice(j--, 1);
//        }
//    }

//    return a;
//};
$.fn.trimContent = function (height, target, ele) {
    if (!target)
        target = $(this);
    var c = $(this).text().length;
    var isRemoved = ($(target).outerHeight() > height && c > 0);
    while ($(target).outerHeight() > height && c > 0) {
        c--;
        var html = $(this).html().toSubString(c);
        $(this).html(html);
    }
    if (isRemoved) {
        if (ele) {
            $(this).html($(this).html().toSubString($(this).html().length - 3) + ele);
        } else {
            $(this).html($(this).html().toSubString($(this).html().length - 3) + "...");
        }
    }
};

$.fn.trimLine = function (numberOfLines, fixMinHeight) {
    try {
        var c = $(this).html().length;
        var height = parseFloat($(this).css('line-height')) * numberOfLines;
        if (isNaN(height))
            height = parseFloat($(this).css('font-size').replace('px', '')) * numberOfLines;

        var isRemoved = ($(this).height() > height && c > 0);

        var regex = new RegExp("</?[a-z0-9]+[^>]*/?>$");

        while ($(this).height() > height && c > 0) {
            if (regex.test($(this).html())) {
                //console.log($(this).find('*:last-child').html());
                //console.log('\n lastchild: ' + $(this).find('*:last-child').html(), '\n html: ' + $(this).html());
                $(this).find('*:last-child').remove();
                c = $(this).html().length;
            } else {
                c--;
                var html = $(this).html().toSubString(c);
                $(this).html(html);
            }
        }
        if (isRemoved)
            $(this).html($(this).html().toSubString($(this).html().length - 3) + "...");
        if (true === fixMinHeight)
            $(this).css({ 'min-height': height + 'px' });
    } catch (e) { }
};
String.format = function (text) {
    //check if there are two arguments in the arguments list
    if (arguments.length <= 1) {
        //if there are not 2 or more arguments there's nothing to replace
        //just return the original text
        return text;
    }

    //decrement to move to the second argument in the array
    var tokenCount = arguments.length - 2;
    for (var token = 0; token <= tokenCount; token++) {
        //iterate through the tokens and replace their placeholders from the original text in order
        text = text.replace(new RegExp("\\{" + token + "\\}", "gi"),
                                                arguments[token + 1]);
    }
    return text;
};
function stripHTML(html) {
    var tmp = document.createElement("DIV");
    tmp.innerHTML = html;
    return tmp.textContent || tmp.innerText;
}
function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + "; " + expires;
}
function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
function getChildCookie(parentName, childName) {
    var name = parentName + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            var parentString = c.substring(name.length, c.length);
            var caChild = parentString.split('&');
            for (var j = 0; j < caChild.length; j++) {
                var c2 = caChild[j];
                while (c2.charAt(0) == ' ') {
                    c2 = c2.substring(1);
                }
                if (c2.indexOf(childName) == 0) {
                    return c2.substring(childName.length + 1, c2.length);
                }
            }
        }
    }
    return "";
}

function playAudio(filename) {
    var audio = new Audio(filename);
    audio.play();
}
function checkAll(ele, targetClass) {
    var checkboxes;
    if (typeof targetClass == "undefined") checkboxes = document.getElementsByTagName('input');
    else checkboxes = document.getElementsByClassName(targetClass);
    if (ele.checked) {
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].type == 'checkbox') {
                checkboxes[i].checked = true;
            }
        }
    } else {
        for (var i = 0; i < checkboxes.length; i++) {
            console.log(i)
            if (checkboxes[i].type == 'checkbox') {
                checkboxes[i].checked = false;
            }
        }
    }
}

function sort_unique(arr) {
    if (arr.length === 0) return arr;
    arr = arr.sort(function (a, b) { return a * 1 - b * 1; });
    var ret = [arr[0]];
    for (var i = 1; i < arr.length; i++) { // start loop at 1 as element 0 can never be a duplicate
        if (arr[i - 1] !== arr[i]) {
            ret.push(arr[i]);
        }
    }
    return ret;
}
var jsEncode = {
    encode: function (s, k) {
        var enc = "";
        var str = "";
        k = '123';
        // make sure that input is string
        str = s.toString();
        for (var i = 0; i < s.length; i++) {
            // create block
            var a = s.charCodeAt(i);
            // bitwise XOR
            var b = a ^ k;
            enc = enc + String.fromCharCode(b);
        }
        return enc;
    }
};
function getParameterByName(name, url) {
    if (!url) {
        url = window.location.href;
    }
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}


var ReCaptcha = {
    validateReCaptcha: function () {
        var response = grecaptcha.getResponse();
        console.log(response);
        if (response.length == 0) return false;
        var me = this;
        me.correctCaptcha(response);
        //https://www.google.com/recaptcha/api/siteverify?secret=your_secret&response=response_string
        return true;
    },
    correctCaptcha: function (response) {
        console.log(response);
    }
};
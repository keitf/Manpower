//检测cookie是否存在
function checkCookie(name) {
    var username = getCookie(name);
    if (username != "") {
        return "1";
    }
    else {
        return "0";
    }
}

// 获取指定名称的cookie
function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i].trim();
        if (c.indexOf(name) == 0) return c.substring(name.length, c.length);
    }
    return "";
}

//删除cookies
function delCookie(name) {
    setCookie(name);
}

//设置cookie(目前仅删除用)
function setCookie(cname) {
    var cvalue = getCookie(cname);
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    document.cookie = cname + "=" + cvalue + "; expires=" + exp.toGMTString();
}
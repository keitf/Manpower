//页面加载时添加角色下拉列表内容 检测是否存在cookie   当不存在时连接数据库查询
if (checkCookie("Seloption") == "0") {
    UserSelOption();
}
else {
    $(".optionSex").html(getCookie("Seloption"));
}



//角色列表添加
function UserSelOption() {
    //清空下拉列表内容
    $(".optionSex").html(null);
    $.ajax({
        type: 'post',
        dataType: 'text',
        url: '../../Handlers/UserEdit.ashx',
        data: { ac: 'SelOptin' },
        cache: false,
        async: false,
        success: function (data) {
            //记录下拉列表Cookie不存在时重新访问数据库            
            document.cookie = "Seloption=" + data;
            $(".optionSex").html(data);
        },
    });
}
layui.use('form', function () {
    var form = layui.form;
    var layer = layui.layer;
    var table = layui.table;

    form.on('submit(demo1)', function (data) {
        //输入判断
        var pwd = data.field.pwd;
        var repwd = data.field.repwd;
        if (pwd != repwd) {
            layer.msg("密码不一致,请检查！");
            return false;
        }
        //删除记录角色id的cookie
        delCookie("Roid");
        //表单取值
        console.log(JSON.stringify(data.field));
        delCookie("Edname");
        delCookie("Edpwd");
        delCookie("Edid");
        UserEditInfo(JSON.stringify(data.field));
        //禁止跳转
        return false;
    });

    //表单验证
    form.verify({
        pass: [
            /^[\S]{6,12}$/
            , '密码必须6到12位，且不能出现空格'
        ]
    });

    //下拉列表及输入框赋值
    var s = getCookie("Roid");
    var eid = getCookie("Edid");
    var ename = getCookie("Edname");
    var epwd = getCookie("Edpwd");
    form.val("data1", {
        "id": eid,
        "username": ename,
        "pwd": epwd,
        "repwd": epwd,
        "interest": s
    });
});
//下拉列表赋值【读取cookie】
var x = getCookie("Seloption");
$(".seloptinsex").html(x);

//添加OR修改
function UserEditInfo(userinfo) {
    $.ajax({
        type: 'post',
        dataType: 'text',
        url: '../../Handlers/UserEdit.ashx',
        data: { ac: 'UserEditInfo', userinfo: userinfo },
        cache: false,
        async: false,
        success: function (data) {
            //成功提示并重载表格
            if (data == 1)//修改成功
            {
                layer.alert("修改成功");
            }
            if (data == 2) //添加成功
            {
                layer.alert("添加成功");
            }
            if (data == 0) //操作失败
            {
                layer.alert("操作失败");
            }
        }
    });
}
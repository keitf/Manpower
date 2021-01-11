layui.use(['form'], function () {
    var form = layui.form;
    var $ = layui.$;

    $.ajax({
        type: 'post',
        dataType: 'json',
        url: '../../Handlers/Employee.ashx',
        data: { ac: 'EmpAbout',empid:getQueryVariable("id") },
        cache: false,
        async: false,
        success: function (data) {
            form.val("example", {               
                "Name": data.Name,
                "Department": data.Department,
                "Sex": data.Sex?"男":"女",
                "Birthday": data.Birthday,
                "IdCard": data.IdCard,
                "Position": data.Polity,
                "Phone": data.Phone,
                "Email": data.Email,
                "Nation": data.Nation,
                "Polity": data.Polity,
                "Degree": data.Degree,
                "Salary": data.Salary,
                "Resume": data.Resume,
                "Status": data.Status ? "在职" : "离职",
                "Resume":data.Resume
            })
        }
    });
    $(".layui-btn").click(function () {
        window.location.href = "javascript:history.go(-1)";
    });
    function getQueryVariable(variable) {
        var query = window.location.search.substring(1);
        var vars = query.split("&");
        for (var i = 0; i < vars.length; i++) {
            var pair = vars[i].split("=");
            if (pair[0] == variable) { return pair[1]; }
        }
        return (false);
    }
});
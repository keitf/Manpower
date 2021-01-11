layui.use(['form', 'table'], function () {
    var form = layui.form;
    var table = layui.table;
    var layer = layui.layer;
    var $ = layui.$;

    table.render({
        elem: '#sadata'
        , url: '../../Handlers/RoleEdit.ashx?action=selrole'
        , cols: [[
            { type: 'checkbox', field: 'left' },
            { field: 'ID', title: '角色名', align: 'center', sort: 'true' },
            { field: 'Name', title: '拥有权限', align: 'center' },
            { field: 'Content', title: '具体描述', sort: true },
            { field: 'CreateDate', title: '创建时间', sort: true },
            { fixed: 'right', width: 150, align: 'center', toolbar: '#barDemo', width: 200 }
        ]]
        , height: 'full-50'
        , cellMinWidth: 80
        , text: {
            none: '暂无相关数据'
        }
        , toolbar: '#toolbarDemo'
        , page: true
    });
    //表格左上方添加/删除
    table.on('toolbar(test1)', function (obj) {
        //记录数组用于批量删除
        var arr = [];
        var checkStatus = table.checkStatus(obj.config.id);
        var layEvent = obj.event;

        if (layEvent ==='add') {
            roleformaddedit("添加");
            return false;
        }
        if (layEvent === 'delete') {
            var data = checkStatus.data; 
            //循环添加
            data.forEach(function (data) {
                arr.push(data.ID);
            });
            if (arr.length<0) {
                layer.msg('未选中任何数据', { icon: 4 });
                return;
            }
            RoleDel(arr.join(','));
        }
    });
    //每行数据后面的编辑
    table.on('tool(test1)', function (obj) {
        var data = obj.data;
        var layEvent = obj.event;
        var tr = obj.tr;
        //查看
        if (layEvent === 'edit') {
            //layer.alert("编辑");
            //记录cookie
            document.cookie = "Editid =" + obj.data.ID;
            document.cookie = "Editcontent=" + obj.data.Content;
            document.cookie = "Editname=" + obj.data.Name;
            document.cookie = 'Editroldsid=' + obj.data.Expower;
            roleformaddedit("编辑");
        }
        else if (layEvent === 'del') {
            layer.confirm('真的要删除吗？', function (index) {
                var arrid = obj.data.ID;
                //console.log(arrid);
                RoleDel(arrid);                
                layer.close(index);
            });
        }
    });
    //选择按钮 checkbox
    table.on('checkbox(test1)', function (obj) {
        console.log(obj.checked); //当前是否选中状态
        console.log(obj.data); //选中行的相关数据
        console.log(obj.type); //如果触发的是全选，则为：all，如果触发的是单选，则为：one
    });

    //弹窗编辑添加
    function roleformaddedit(txttitle) {
        layer.open({
            type: 2,
            title:txttitle,
            content: 'roleform.html',
            skin: '',
            area: ['450px', '430px'],
            resize: false,
            anim: 0,
            //右上角关闭按钮触发的回调
            cancel: function () {
                if (confirm('确定要关闭么')) { //只有当点击confirm框的确定时，该层才会关闭
                    delCookie("Editid");
                    delCookie("Editcontent");
                    delCookie("Editname");
                    delCookie("Editroldsid");
                    Tablereload();
                    UserSelOption();
                }
            }
        });  
    };
    //角色删除
    function RoleDel(roleid) {
        $.ajax({
            type: 'post',
            dataType: 'text',
            url: '../../Handlers/RoleEdit.ashx',
            data: { action: "RoleDel", roleid: roleid },
            cache: false,
            async: false,
            success: function (data) {
                if (data == 1) {
                    layer.alert("Delete OK!");
                }
                else {
                    layer.alert("ERROR!");
                }
                Tablereload();
                form.render();
            }
        });
    };
    //表格重载
    function Tablereload() {
        table.reload('sadata', {
            url: '../../Handlers/RoleEdit.ashx?action=selrole',
            where: {}
        });
    };   
});
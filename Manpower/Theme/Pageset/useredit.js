//加载layui模块
layui.use('form', function () {
    var form = layui.form;
    var layer = layui.layer;
    form.render();
    layui.use('table', function () {
        var table = layui.table;

        //Layui自动化表格重载
        function Tablerelod(id, name, rname) {
            //Layui自动化表格重载
            table.reload("test", {
                url: '../../Handlers/UserEdit.ashx?ac=ReadJson'
                , where: { id: id, name: name, rid: rname }   //重载时的参数
            });
        }

        //数据接口路径
        var url = "../../Handlers/UserEdit.ashx?ac=ReadJson";
        table.render({
            elem: '#test'
            , url: url
            , data:{ id: '', name: '', rname: '' }
            , toolbar: '#toolbarDemo' //开启头部工具栏，并为其绑定左侧模板
            , defaultToolbar: ['filter', 'exports', 'print', { //自定义头部工具栏右侧图标。如无需自定义，去除该参数即可
                title: '提示'
                , layEvent: 'LAYTABLE_TIPS'
                , icon: 'layui-icon-tips'
            }]
            , title: '用户数据表'
            , cols: [[
                { type: 'checkbox', fixed: 'left' }
                , { field: 'ID', title: 'ID', width: 80, fixed: 'left', unresize: true, sort: true }
                , { field: 'Account', title: '用户名', width: 120, edit: 'text' }
                , { field: 'Password', title: '密码', width: 120, edit: 'text', sort: true }
                , { field: 'IsActive', title: 'IsActive', width: 100 }
                , { field: 'CreatDate', title: 'CreatDate', width: 180 }
                , { field: 'Name', title: '角色', width: 185, sort: true }
                , { fixed: 'right', title: '操作', toolbar: '#barDemo', width: 150 }
            ]]
            , page: true
        });

        //头工具栏事件
        table.on('toolbar(test)', function (obj) {
            //记录数组用于批量删除
            var arr=[];
            var checkStatus = table.checkStatus(obj.config.id);
            switch (obj.event) {
                //删除所有被选中的行数
                case 'getCheckData':
                    var data = checkStatus.data;
                    
                    //循环添加
                    data.forEach(function (data) {
                        arr.push(data.ID);
                    });
                   
                    //判断是否为空
                    if (arr.length<=0) {
                        layer.msg('未选中任何数据', { icon: 4 });
                        return;
                    }
                    //调用删除方法
                    UserDelSel(arr.join(','));                    
                    //Layui自动化表格重载 
                    Tablerelod('', '', '');
                    break;

                case 'getCheckLength':
                    var data = checkStatus.data;
                    layer.msg('选中了：' + data.length + ' 个');
                    break;

                case 'isAll':
                    layer.msg(checkStatus.isAll ? '全选' : '未全选');
                    break;

                //自定义头工具栏右侧图标 - 提示
                case 'LAYTABLE_TIPS':
                    layer.alert('这是工具栏右侧自定义的一个图标按钮');
                    break;
                //添加
                case 'addUser':
                    UserAddandEdit('添加');
                    break;
            };
        });

        //监听行工具事件
        table.on('tool(test)', function (obj) {
            var data = obj.data;     
            console.log(data);
            if (obj.event === 'del') {
                layer.confirm('真的删除行么', function (index) {
                    obj.del();
                    console.log(obj.data.ID);
                    layer.close(index);           
                    //调用删除方法                
                    UserDelSel(obj.data.ID)
                    //Layui自动化表格重载 
                    Tablerelod('', '', '');

                });
                //用户编辑
            } else if (obj.event === 'edit') {
                //编辑时记录cookie用于新页面的【角色、账号、密码】角色表赋值
                console.log(obj.data.Name);
                document.cookie = "Roid=" + (obj.data.RID);
                document.cookie = "Edname=" + (obj.data.Account);
                document.cookie = "Edpwd=" + (obj.data.Password);
                document.cookie = "Edid=" + (obj.data.ID);
                UserAddandEdit('编辑');
            }
        });

        //点击搜索时
        $(".layuiadmin-btn-useradmin").click(function () {
            TableRelod();
        });

        //条件搜集
        function TableRelod() {
           
            var Selid = $(".selidtext").val();
            console.log(Selid);
            var Selnaem = $(".selnametext").val();
            console.log(Selnaem);
            var Selrolename = $("#down_link_name").val();
            console.log(Selrolename);

            Tablerelod(Selid, Selnaem, Selrolename);
        }        

        //添加&&编辑
        function UserAddandEdit(btntitle) {
            layer.open({
                type: 2,
                title: btntitle,
                content: 'alluseredit.html',
                skin: '',
                area: ['400px', '400px'],
                anim: 0,
                //右上角关闭按钮触发的回调
                cancel: function () {
                    if (confirm('确定要关闭么')) { //只有当点击confirm框的确定时，该层才会关闭
                        Tablerelod('', '','');
                        delCookie("Roid");
                        delCookie("Edname");
                        delCookie("Edpwd");
                        delCookie("Edid");                                                
                    }
                } 
            });            
        }

        
    });   
});
//删除所选的数据
function UserDelSel(arrjson) {    
    $.ajax({
        type: 'post',
        dataType: 'json',
        url: '../../Handlers/UserEdit.ashx',
        data: { ac: 'DelSelo',arridjson:arrjson },
        cache: false,
        async: false,
        success: function (data) {            
            if (data == 1) {
                layer.alert('成功', { icon: 6 });
            }
            else {
                layer.alert('操作失败请检查！', { icon: 5 });
            }
        },
    });
}

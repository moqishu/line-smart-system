/*
* author@lin
* easyUI datagrid封装
*/
$.fn.LineGrid = function (options) {

    var default_options = {
        width: "auto",
        striped:true,
        height: "auto",
        singleSelect: true,
        //fitColumns: true,
        resizable:true,
        resizeHandle: 'right',
        pagePosition: 'bottom',
        pagination: true,
        pageSize: 20,
        pageList: [10, 20, 50],
        onLoadSuccess: function (data) {
            //$(("input")).iCheck({
            //    checkboxClass: 'icheckbox_minimal-blue',
            //    radioClass: 'iradio_square-blue'
            //});
        },
        onLoadError: function (err) {
            layer.open({
                title: '信息提示',
                area: ['900px', '500px'], //宽高
                //skin: 'layui-layer-lan',
                content: err.responseText
            });
        },
        onBeforeLoad: function () {

        },
        onHeaderContextMenu: function (e, field) {
            e.preventDefault();
            //layer.alert(createColumnMenu(), {
            //    skin: 'layui-layer-lan',
            //    title:"显示列设置"
            //   , anim: 0 });
            layer.open({
                title: '显示列设置',
                area: ['350px','250px'], //宽高
                //skin: 'layui-layer-lan',
                content: createColumnMenu()
            });
            //layer.open({
            //    type: 1,
            //    skin: 'layui-layer-lan', //样式类名
            //    closeBtn: 1, //不显示关闭按钮
            //    anim: 0,
            //    shadeClose: true, //开启遮罩关闭
            //    content: createColumnMenu()
            //});
            $(("#showCol input")).iCheck({
                checkboxClass: 'icheckbox_minimal-blue',
                radioClass: 'iradio_square-blue'
            });

            $('#showCol input').on('ifChanged', function (event) {
                if ($(this).is(':checked') == false) {
                    $('#grid').datagrid('hideColumn', event.target.defaultValue);
                } else {
                    $('#grid').datagrid('showColumn', event.target.defaultValue);
                }
            });
        }

    };

    var p = $.extend({}, default_options, options || {});

    //$(this).datagrid(p);

    var pager = $(this).datagrid(p).datagrid('getPager');	// get the pager of datagrid
    $(pager).pagination({
        layout: ['list', 'sep', 'first', 'prev', 'links', 'next', 'last', 'sep', 'manual','sep', 'refresh','info'],
    });

   

    $(window).resize(function () {
        $('#grid').datagrid('resize', {
            height: ($(window).height() - $('.searchbar').height() - 18)
        });
    });

    $('#grid').datagrid('resize', {
        height: ($(window).height() - $('.searchbar').height() - 18)
    });

    var colContent;
    function createColumnMenu() {
        colContent = '<div id="showCol" class="box-body" style="padding-top: 5px;">';
        var fields = $('#grid').datagrid('getColumnFields');
        var num = 0;
        // 全选、反选（用按钮形式）
        //colContent += '<div class="row">';
        //colContent += '<div class="col-md-6"><input type="checkbox" value="' + field + '" />&nbsp;全选</div>';
        //colContent += '<div class="col-md-6"><input type="checkbox" value="' + field + '" />&nbsp;反选</div>';
        //colContent += '</div>';

        for (var i = 0; i < fields.length; i++) {
            var field = fields[i];
            var col = $('#grid').datagrid('getColumnOption', field);

            //col.hidden

            if (field == 'ck' || field == 'op') {
                continue;
            }

            if (num == 0) {
                colContent += '<div class="row">';
                colContent += '<div class="col-md-6"><input type="checkbox" value="' + field + '" />&nbsp;' + col.title + '</div>';
                num = 1;
            } else {
                colContent += '<div class="col-md-6"><input type="checkbox" value="' + field + '" />&nbsp;' + col.title + '</div>';
                num = 0;
            }
            if (num == 0 || fields.length - 1 == i) {
                colContent += '</div>';
            }
        }
        colContent += '</div>';

        return colContent;
    }

   
}



var cmenu;
function createColumnMenu2() {
    cmenu = $('<div/>').appendTo('body');
    cmenu.menu({
        onClick: function (item) {
            if (item.iconCls == 'icon-ok') {
                $('#grid').datagrid('hideColumn', item.name);
                cmenu.menu('setIcon', {
                    target: item.target,
                    iconCls: 'icon-empty'
                });
            } else {
                $('#grid').datagrid('showColumn', item.name);
                cmenu.menu('setIcon', {
                    target: item.target,
                    iconCls: 'icon-ok'
                });
            }
        }
    });
    var fields = $('#grid').datagrid('getColumnFields');
    for (var i = 0; i < fields.length; i++) {
        var field = fields[i];
        var col = $('#grid').datagrid('getColumnOption', field);
        cmenu.menu('appendItem', {
            text: col.title,
            name: field,
            iconCls: 'icon-ok'
        });
    }
}


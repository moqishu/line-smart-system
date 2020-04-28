
var js = {
    index: 0,
    alert:function(msg){
        layer.alert(msg, {
            shade: false,
            success: function (el) {
                var $el = $(el);
                var btn = $el.find('.layui-layer-btn').find('a')[0];
                btn.href = 'javascript:void(0)';
                btn.focus();
                console.log(btn);
            }
        });
    },
    loading: function (message) {
        this.index = layer.msg(
            message,
            {
                icon: 16,
                time: 0, //不自动关闭
                anim: 1,
                shade: [0.1, '#FFF'],
            });
    },
    closeLoading: function () {
        if (this.index == 0) {
            return;
        } else {
            layer.close(this.index)
        }
    },
    getHostUrl: function () {
        var hostUrl = window.location.host;
        return hostUrl;
    },
    // 获取URL地址参数 getQueryString("参数名1")
    getQueryString: function (name, url) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        if (!url || url == "") {
            url = window.location.search;
        } else {
            url = url.substring(url.indexOf("?"));
        }
        r = url.substr(1).match(reg)
        if (r != null) return unescape(r[2]); return null;
    },
    windowOpen: function (title, url, width, height, shadeClose) {

        if (typeof (shadeClose) == 'undefined')
            shadeClose = true;

        layer.open({
            type: 2,
            title: title,
            shadeClose: shadeClose,//点击遮罩是否关闭弹窗
            shade: 0.5,
            area: [width + 'px', height + 'px'], //宽高
            content: url //iframe的url
        });
    },
    closeWin:function(){
        //当你在iframe页面关闭自身时
        var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
        parent.layer.close(index); //再执行关闭   
    },
    contentOpen: function (title, content, width, height, shadeClose) {

        if (typeof (shadeClose) == 'undefined')
            shadeClose = true;

        layer.open({
            type: 1,
            title: title,
            shadeClose: shadeClose,//点击遮罩是否关闭弹窗
            shade: 0.5,
            area: [width + 'px', height + 'px'], //宽高
            content: content //$()
        });
    },
    openPage: function (url, title, closeable) {
        var $tabs = window.parent.$("#tabs");
        if ($tabs.tabPanel("exists", title)) {
            $tabs.tabPanel("show", title)
        } else {
            var c = "edit_" + Math.uuid();
            $tabs.tabPanel("addTab", {
                id: c,
                title: title,
                //html: '<script>js.loading("正在加载，请稍后...");<\/script><iframe id="' + c + '-frame" src="' + url + '" width="100%" height="100%" frameborder="0" onload="js.closeLoading();"></iframe>',
                html: '<iframe id="' + c + '-frame" src="' + url + '" width="100%" height="100%" frameborder="0" onload="js.closeLoading();"></iframe>',
                closable: true,
                onPreClose: function (i) {
                    js.closeLoading(1000, true)
                },
                disabled: false
            })
        }
    },
    resizeTabContent: function () {
        $(".panel").height($('body').innerHeight() - 100);

    },
    resizeTabHeight: function () {
        js.resizeTabContent();
        $(window).resize(function () {
            js.resizeTabContent();
        });
    },

};


var dataExt = {
    /* datagrid数据加载 */
    loadGrid: function (gridId, parameter, url) {
        if (typeof (gridId) == "undefined") {
            gridId = "grid";
        }
        var par = parameter || {}; //后台构造取巧参数可以传入
        if (par != null) {
            $('#' + gridId).datagrid('options').queryParams = par;
        }
        if (url != null) {
            $('#' + gridId).datagrid('options').url = url;
        }
        var global_reload = true;//全局变量，判断是否刷新到第一页
        if (global_reload)
            $("#" + gridId).datagrid('load');
        else
            $("#" + gridId).datagrid('reload');

        //$('#' + gridId).datagrid('selectRow', 0);
    },
    getSelectIds: function (gridId) {
        var idList = [];
        if (typeof (gridId) == "undefined") {
            gridId = "grid";
        }
        var obj = $('#' + gridId).datagrid('getSelections');
        var objLength = obj.length;
        for (var i = 0; i < objLength; i++) {
            idList.push(obj[i].Id);
        }
        alert(idList);
        return idList;
    },
    GetParameter : function (grid) {
        var data = {};
        var data = {};
        if (grid != undefined) {
            data.sort = grid.datagrid('options').sortName;
            data.order = grid.datagrid('options').sortOrder;
        }

        $("#searchbar").find("[col]").each(function (i, value) {
            var field = $(value).attr("col");
            if (value.tagName == "INPUT") {
                if (value.type == "checkbox") {
                    if ($(value).attr("checked") == true) {
                        if (data[field]) {
                            data[field] = data[field] + "," + $(value).val();
                        } else {
                            data[field] = $(value).val();
                        }
                    }
                }
                else if (value.type == "radio") {
                    if ($(value).attr("checked") == true) {
                        data[field] = $(value).val();
                    }
                }
                else if ($(value).attr("type") == "combotree") {
                    var val = $(value).combotree('getValue');
                    if (val == null || val == 0)
                        val = "";
                    data[field] = val;
                }
                else {
                    data[field] = $(value).val();
                }
            }
            else if (value.tagName == "SELECT") {
                if ($(value).attr("type") == "combotree") {
                    var values = $(value).combotree('getValues');
                    if (values == null || values.count == 0)
                        values = "";
                    data[field] = values.join(",");
                } else {
                    data[field] = $(value).val();
                }
            }
            else if (value.tagName == "DIV") {
                data[field] = $(value).html();
            }
            else if (value.tagName == "IMG") {
                data[field] = $(value).attr("src");
            }
            else if (value.tagName == "SPAN") {
                data[field] = $(value).html();
            }
            else if (value.tagName == "TEXTAREA") {
                data[field] = $(value).val();
            }
        });

        return data;
    }

};
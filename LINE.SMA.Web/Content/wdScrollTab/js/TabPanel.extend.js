/*!
 * 首页Tab页签通用方法
 * @author ThinkGem
 * @version 2017-3-26
 */
(function(b) {
    var a = {
        tabPageId: null,
        initTabPage: function(e, c) {
            this.tabPageId = e;
            var d = b.extend(true, {
                autoResizable: true,
                widthResizable: true,
                height: function() {
                    return b(window).height()
                },
                items: [
                 { id: 'toolbarPlugin1', title: '首页', html: '<iframe src="https://www.baidu.com" width="100%" height="100%" frameborder="0"></iframe>', closable: false }
                ]
            },
            c);
            return b("#" + this.tabPageId).tabPanel(d)
        },
        addTabPage: function (g, h, d, f, e) {
            // 'tab' add by lwl
            var c = g ? 'tab' + g.data("id") : null;
            if (c == undefined) {
                c = "tabpanel-" + Math.uuid();
                g ? g.attr("data-id", c) : null
            }
            b("#" + this.tabPageId).tabPanel("addTab", {
                id: c,
                title: h,
                //html: '<script>js.loading("正在加载，请稍后...");<\/script><iframe id="' + c + '-frame" src="' + d + '" width="100%" height="100%" frameborder="0"></iframe>',
                html: '<iframe id="' + c + '-frame" src="' + d + '" width="100%" height="100%" frameborder="0"></iframe>',
                closable: (f == undefined ? true: f),
                onPreClose: function(i) {
                    js.closeLoading(1000, true)
                },
                disabled: false
            })
        },
        getCurrentTabPage: function(d) {
            var c = b("#" + this.tabPageId).tabPanel("getActiveTab");
            var g = b("#" + c.id + "-frame");
            if (g.length > 0 && typeof d == "function") {
                try {
                    d(g[0].contentWindow)
                } catch(f) {
                    js.error(f)
                }
            }
            return g
        },
        getPrevTabPage: function(c, f) {
            var d = b("#" + this.tabPageId).tabPanel("getActiveTab");
            var h = b("#" + d.preTabId + "-frame");
            if (h.length > 0 && typeof c == "function") {
                try {
                    c(h[0].contentWindow)
                } catch(g) {
                    js.error(g)
                }
            }
            if (f == true) {
                b("#" + this.tabPageId).tabPanel("kill", d.id)
            }
            return h
        },
        closeCurrentTabPage: function(c) {
            getPrevTabPage(c, true)
        },
        SetResize: function (x) {
            b("#" + this.tabPageId).tabPanel("resize",x)
        }
    };
    window.tabPage = a
})(window.jQuery);
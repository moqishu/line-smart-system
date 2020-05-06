$(function () {
    
    GetLoadNav();
    //var Default = {
    //    tree_menu_li: '.menuItem'
    //}

    $('.menuItem').on('click', function (event) {
        var tabTitle = $(this).text();
        var url = $(this).attr("href");
        // 阻止a标签href默认跳转事件
        event.preventDefault()

        var menuid = $(this).attr("data-id");

        if ($("#tabs").tabPanel("exists", menuid)) {
            $("#tabs").tabPanel("show", menuid)
        } else {
            tabPage.addTabPage($(this), tabTitle, url);//增加tab
        }

        $('.treeview').removeClass("active");
        $('.treeview-menu li').removeClass("active");

        var parentTree = $(this).parents('.treeview');
        parentTree.addClass("active");
        $(this).parents('li').addClass("active");
    })
    
});

function getMenuData() {
    var menuData;
    $.ajax({
        url: "/Sys/GetMenuList",
        type: "GET",
        dataType: "JSON",
        async: false,
        success: function (data) {
            menuData = data;
        }
    });

    return menuData;
}

function GetLoadNav() {
    var data = getMenuData();
    var _html = "";
    $.each(data, function (i) {
        var row = data[i];
        if (row.ParentId == "0") {
            if (i == 0) {
                _html += '<li class="treeview active">';
            } else {
                _html += '<li class="treeview">';
            }
            //_html += '<li class="treeview">';
            _html += '<a href="#">';
            _html += '<i class="fa fa-th-large"></i> <span>' + row.Name + '</span>';
            _html += '<span class="pull-right-container">';
            _html += '<i class="fa fa-angle-left pull-right"></i>';
            _html += '</span>';
            _html += '</a>';

            var childNodes = row.Child;
            if (childNodes.length > 0) {
                _html += '<ul class="treeview-menu">';
                $.each(childNodes, function (i) {
                    var subrow = childNodes[i];
                    var url = subrow.Url == null ? '#' : subrow.Url;
                    _html += '<li>';
                    _html += '<a class="menuItem" href="' + url + '" data-id="' + subrow.Id + '"><i class=""></i>' + subrow.Name + '</a>';
                    _html += '</li>';
                });
                _html += '</ul>';
            }
            _html += '</li>';
        }
    });
    $(".sidebar-menu").append(_html);
}


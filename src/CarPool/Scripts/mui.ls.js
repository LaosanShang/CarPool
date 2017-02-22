(function ($) {
    $.lsAjax = function (options) {
        var defaults = {
            type: "POST",
            url: "",
            async: true,
            data: {},
            dataType: "json",
            beforsend: function (XMLHttpRequest) {
                this;   //调用本次ajax请求时传递的options参数
            },
            complete: function (XMLHttpRequest, textStatus) {
                this;    //调用本次ajax请求时传递的options参数
            },
            success: function (data) {
                var jsonData = data;//eval('(' + data + ')');
                if (jsonData.ResponseCode == 200) {
                    this.onSuccess(jsonData.Content,jsonData);
                }
                else if (jsonData.ResponseCode == 500) {
                    this.onFailure(jsonData.Description, jsonData);
                }
                else if (jsonData.ResponseCode == 100) {
                    this.onExpired();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //通常情况下textStatus和errorThrown只有其中一个包含信息
                this;   //调用本次ajax请求时传递的options参数
            },
            contentType: "application/x-www-form-urlencoded",
            /*自定义回掉函数*/
            onSuccess: function (content, data) {

            },
            onFailure: function (des,data) {
                $.ls.warning(des);
            },
            onExpired: function (data) {
                window.top.location = "~/Home/Login";
            }
        };
        var settings = $.extend(defaults, options);
        $.ajax(settings);
    }
})($)
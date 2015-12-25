
loading = '<div align="center" style="margin-top: 3%;"><i class="fa fa-spinner fa-3x fa-pulse"></i></div>';

function ld_fm2(url) {
    location.hash = url //url.match(/(^.*)\./)[1]
    return false
}
var originalTitle = document.title;
function hashChange() {
    var page = location.hash.slice(1);
    if (page != "") {
        $('.pageContent').html(loading);
        //console.log(page+".php");
        $('.pageContent').load(page, function (response, status, xhr) {
            if (status == "error") {
                var msg = "Sorry there was an error: ";
                $('.pageContent').html(msg + xhr.status + " " + xhr.statusText);

            }
            //alertMsg('Successfully processed!','success');
            document.title = originalTitle + ' – ' + page;
        })
    }
}
// part 3
if ("onhashchange" in window) { // cool browser
    $(window).on('hashchange', hashChange).trigger('hashchange');
} else { // lame browser
    var lastHash = '';
    setInterval(function () {
        if (lastHash != location.hash)
            hashChange();
        lastHash = location.hash;
    }, 100)
}

function alertMsg(ttl, msg, cls) {
    new PNotify({
        title: ttl,
        text: msg,
        type: cls
    });
};

function ld_fm() {
    alert("I got called");
    //var link = url;
    //var cnt = container;
    //$("." + cnt).html(loading);
    //$("." + cnt).load(link, function (response, status, xhr) {
    //    if (status == "error") {
    //        var msg = "Sorry but there was an error: " + xhr.status + " " + xhr.statusText;
    //        //$("." + cnt).html(msg + xhr.status + " " + xhr.statusText);
    //        alertMsg('Notification', msg, 'error');

    //    }
    //    alertMsg('Notification', 'Successfully processed!', 'success');
    //}
    //);
    return false;
}

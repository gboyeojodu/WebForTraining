
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

function ld_fm(url, container) {
    //alert(url + " " + container);
    var link = url;
    var cnt = container;
    $("." + cnt).html(loading);
    $("." + cnt).load(link, function (response, status, xhr) {
        if (status == "error") {
            var msg = "Sorry but there was an error: " + xhr.status + " " + xhr.statusText;
            //$("." + cnt).html(msg + xhr.status + " " + xhr.statusText);
            alertMsg('Notification', msg, 'error');

        }
        //alertMsg('Notification', 'Successfully processed!', 'success');
    }
    );
    return false;
}

function ld_modal_fm(url, container, id) {
    //alert(url + " " + container);
    var link = url;
    var cnt = container;
    var ids = id;
    $('#modalContent').modal('show');
    $("#" + cnt).html(loading);
    $("#" + cnt).load(link,{id:ids}, function (response, status, xhr) {
        if (status == "error") {
            var msg = "Sorry but there was an error: " + xhr.status + " " + xhr.statusText;
            //$("." + cnt).html(msg + xhr.status + " " + xhr.statusText);
            alertMsg('Notification', msg, 'error');
            $("#" + cnt).html('Notification', msg, 'error');
        }
        //alertMsg('Notification', 'Successfully processed!', 'success');
        
    }
    );
    return false;
}
function validate_form(fm_id, url) {
    //alert(fm_id);

    $.validate({
        form: "#"+fm_id,
        //modules: 'security',
        onError: function () {
            alertMsg('Notification', 'Please check your entries.', 'error');
            return false; // Will stop the submission of the form
        },
        onSuccess: function ($form) {
            //alert('The form is valid!');
            //alertMsg('Notification', 'This form is valid', 'success');
            setForm($form,url);
            return false; // Will stop the submission of the form
        }
    });
    //alert("I got called finally");
}

function setForm($form,url) {

    $.ajax({
        type: "POST",
        url: url,
        dataType: 'json',
        data: $form.serialize()
    }).done(function (dt) {
        //alert(dt);
        //console.log(dt);
        if (dt.isSuccess == 1) {
            alertMsg('Notification', dt.msg, 'success');
            if ($(".btn-primary", $form).text() == 'Save') {
                $form[0].reset();
            }
            $('.refresh').trigger('click');
        }
        else {
            alertMsg('Notification', dt.msg, 'error');
            //alert(dt.msg);
        }
    }).fail(function (jqXHR, textStatus) {
        alertMsg('Notification', textStatus, 'error');
        //alert(textStatus);
    });

    //alert('called finally');
    return false;
}

function delRecord(id, url) {
    if (!confirm('Are you sure you want to delete this record?')) {
        return;
    }
    $.ajax({
        type: "POST",
        url: url,
        dataType: 'json',
        data: {ids:id}
    }).done(function (dt) {
        //alert(dt);
        //console.log(dt);
        if (dt.isSuccess == 1) {
            alertMsg('Notification', dt.msg, 'success');
            $('.refresh').trigger('click');
        }
        else {
            alertMsg('Notification', dt.msg, 'error');
            //alert(dt.msg);
        }
    }).fail(function (jqXHR, textStatus) {
        alertMsg('Notification', textStatus, 'error');
        //alert(textStatus);
    });

    //alert('called finally');
    return false;
}

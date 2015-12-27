

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
                alertMsg('Notification', msg, 'error');

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
function ld_fm_with_id(ids, url, container) {
    //alert(url + " " + container);
    var link = url;
    var cnt = container;
    $("." + cnt).html(loading);
    $("." + cnt).load(link, { id: ids }, function (response, status, xhr) {
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
    //if (!confirm('Are you sure you want to delete this record?')) {
    //    return;
    //}
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

function styleTable(tb_id) {

        $('input.tableflat').iCheck({
            checkboxClass: 'icheckbox_flat-green',
            radioClass: 'iradio_flat-green'
        });

    var asInitVals = new Array();
    var oTable = $('#'+tb_id).dataTable({
        "oLanguage": {
            "sSearch": "Search all columns:"
        },
        "aoColumnDefs": [
            {
                'bSortable': false,
                'aTargets': [0]
            } //disables sorting for column one
        ],
        
        'iDisplayLength': 12,
        "sPaginationType": "full_numbers",
        "dom": 'T<"clear">lfrtip'
        ,
        "tableTools": {
            "sSwfPath": "../js/datatables/tools/swf/copy_csv_xls_pdf.swf"
        }
    });
    $("tfoot input").keyup(function () {
        /* Filter on the column based on the index of this element's parent <th> */
        oTable.fnFilter(this.value, $("tfoot th").index($(this).parent()));
    });
    $("tfoot input").each(function (i) {
        asInitVals[i] = this.value;
    });
    $("tfoot input").focus(function () {
        if (this.className == "search_init") {
            this.className = "";
            this.value = "";
        }
    });
    $("tfoot input").blur(function (i) {
        if (this.value == "") {
            this.className = "search_init";
            this.value = asInitVals[$("tfoot input").index(this)];
        }
    });
}

function checkAll(ele, cls) {
    //var checkboxes = document.getElementsByTagName('input');
    //alert(cls);
    var checkboxes = document.getElementsByClassName(cls);
    if (ele.checked) {
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].type == 'checkbox') {
                checkboxes[i].checked = true;
            }
        }
    } else {
        for (var i = 0; i < checkboxes.length; i++) {
            console.log(i)
            if (checkboxes[i].type == 'checkbox') {
                checkboxes[i].checked = false;
            }
        }
    }
}

function countCheckBox(tbody_id, btn_id) {
    if ($('#' + tbody_id + ' input:checkbox:checked').length > 0) {
        $('#'+ btn_id).fadeIn();
    }
    else {
        //$('#chkAllTaxFormula').checked = false;
        $('#' + btn_id).fadeOut();
    }
}


function splitCheckboxIdDelete(tb_cls,body_id, url) {
    if ($('#' + body_id + ' input:checkbox:checked').length < 1) {
        alertMsg('Notification', 'please check the item to delete...', 'error');
        return;
    }
    if (!confirm('Do you want to delete ' + $('#' + body_id + ' input:checkbox:checked').length + ' record(s)')) {
        return
    }
      
    var sel_IDs = "";
    $('.' + tb_cls).each(function () {
        if (this.checked) {
            sel_IDs += $(this).val() + ",";
        }
    });

    delRecord(sel_IDs, url);

}

function checkAllTableBox(elem, tbl_id) {
    //alert("I got called");
    if (elem.checked) {
        //alert("I got called");
        $('#'+tbl_id).find('tr').each(function () {
           // alert("I got called");
            var row = $(this);
            row.find('input[type="checkbox"]').each(function () {
                //this is the current checkbox
                //alert("I got called");
                this.checked = true;
                this.value = 'true';
            });
        });
    } else {
        $('#'+tbl_id).find('tr').each(function () {
            var row = $(this);
            row.find('input[type="checkbox"]').each(function () {
                //this is the current checkbox
                this.checked = false;
                this.value = 'false';
            });
        });
    }
}

function checkAllRow(elem,elem_id) {
    //alert("I got called");
//$(this).parents('tr').find(':checkbox').prop('checked', this.checked);
    if (elem.checked) {
        $('#' + elem_id).parents('tr').find('input[type="checkbox"]').each(function () {
            //this is the current checkbox
            //alert("I got called");
            this.checked = true;
            this.value = 'true';
        });
    } else {
        $('#' + elem_id).parents('tr').find('input[type="checkbox"]').each(function () {
            //this is the current checkbox
            //alert("I got called");
            this.checked = false;
            this.value = 'false';
        });
    }
    
}

function tog(elem) {
    if (elem.checked) {
        elem.value = 'true';
    } else {
        elem.value = 'false';
    }
}

function setAccessLevel() {
    var accessLevelID = '';
    var userGroupID = $('#userGroupID').val();
    var formID = '';
    var canAdd = '';
    var canView = '';
    var canEdit = '';
    var canDelete = '';
    var canApprove = '';

    $('#tblAccessLevel').find("tr").find("td").each(function () {

        $(this).children('#accessLevelID').each(function () {

            accessLevelID += $(this).val().toString() + ',';
        });
        $(this).children('#formID').each(function () {

            formID += $(this).val().toString() + ',';
        });
        $(this).children('.canAddCls').each(function () {
            canAdd += $(this).val().toString() + ',';
        });
        $(this).children('.canViewCls').each(function () {
            canView += $(this).val().toString() + ',';
        });
        $(this).children('.canEditCls').each(function () {
            canEdit += $(this).val().toString() + ',';
        });
        $(this).children('.canDeleteCls').each(function () {
            canDelete += $(this).val().toString() + ',';
        });
        $(this).children('.canApproveCls').each(function () {
            canApprove += $(this).val().toString() + ',';
        });
    });

    $.ajax({
        type: "POST",
        url: "/Administration/setAccessLevel",
        dataType: 'json',
        data: { accessLevelID: accessLevelID, userGroupID: userGroupID, formID: formID, canAdd: canAdd, canView: canView, canEdit: canEdit, canDelete: canDelete, canApprove: canApprove }
    }).done(function (dt) {
        //alert(dt);
        //console.log(dt);
        if (dt.isSuccess == 1) {
            alertMsg('Notification', 'Record saved successfully.', 'success');
        }
        else {
            alertMsg('Notification', 'Oops! Record could not be saved.', 'error');
            //alert(dt.msg);
        }
    }).fail(function (jqXHR, textStatus) {
        alertMsg('Notification', textStatus, 'error');
        //alert(textStatus);
    });

    //alert('called finally');
    return false;
    
}
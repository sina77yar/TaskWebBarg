'use strict';

// Show Modal
function showModal(body, title, description, size = 'md') {

    let modalSize = $('#modal_custom_size');
    let modalTitle = $('#modal_custom_title');
    let modalDescription = $('#modal_custom_description');
    let modalBody = $('#modal_custom_body');
    let modal = $('#modal_custom_target');

    modalSize.addClass(`modal-${size}`);
    modalTitle.html(title);
    modalDescription.html(description);
    modalBody.html(body);
    modal.modal('show');
}


// SweetAlert - Errore
function showErrMessage(title = 'متاسفـم !', text = 'یک خطا با به وجود اومد') {
    Swal.fire({
        icon: 'error',
        title: title,
        text: text,
        showConfirmButton: true,
    })

}


// SweetAlert - Success 
function showSucMessage(text = 'با موفقیت انجام شد') {
    Swal.fire({
        position: 'center',
        icon: 'success',
        title: text,
        showConfirmButton: false,
        timer: 1500
    })
}


// Reload Page
function reloadPage(time = 1500) {
    setTimeout(
        function () {
            window.location.reload();
        }, time);
}


// SweetAlert - Warning
function showWarMessage(isConfirmedMethod, title = 'حـذف بشـه؟', text = "مطمئنی میخوای حـذفش کنی؟", confirmButtonText = 'بلـه حـذف بشه') {

    Swal.fire({
        title: title,
        text: text,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#fd397a',
        cancelButtonColor: '#293846',
        confirmButtonText: confirmButtonText,
        cancelButtonText: 'انصـراف'
    }).then((result) => {
        if (result.isConfirmed) {

            isConfirmedMethod();

        }
    });

}


// Remove Row in Kendo Grid
function removeRow(item) {
    $(item).closest('tr').remove();
}


// Ajax with Progressbar ( this is a Promise )
function ajax_Progressbar(url, data, type = 'POST') {
    return new Promise((resolve, reject) => {

        $.ajax({
            url: url,
            type: type,
            contentType: false,
            cache: false,
            processData: false,
            data: data,
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            //dataType: "json",
            xhr: function () {

                var jqXHR = null;
                try {
                    if (window.ActiveXObject) {
                        jqXHR = new window.ActiveXObject("Microsoft.XMLHTTP");
                    }
                    else {
                        jqXHR = new window.XMLHttpRequest();
                    }
                } catch (e) {
                    console.log("error : " + e);
                    jqXHR = new window.XMLHttpRequest();
                }

                //Upload progress
                jqXHR.upload.addEventListener("progress", function (evt) {
                    if (evt.lengthComputable) {
                        var percentComplete = Math.round((evt.loaded * 100) / evt.total);
                        //Do something with upload progress
                        console.log(percentComplete);
                        $('#Progressbox').css("display", "block");
                        $('#Progress').css("width", percentComplete + "%");
                        $('#Progress').html(percentComplete + "%");
                    }
                }, false);
                return jqXHR;
            },
            success: function (data) {
                resolve(data);
            },
            error: function (req, status, error) {
                console.log(req);
                var jsonResult = req.responseJSON;
                if (jsonResult.length != undefined) {

                    jsonResult.forEach(function (item) {
                        var message = item.Message;
                        let fieldName = item.FieldName;
                        if (fieldName != undefined) {
                            $('#msg-for-' + fieldName).html(message)
                        }
                    });
                    showErrMessage(jsonResult[0].Title, jsonResult[0].Message);
                } else {
                    var message = req.responseJSON.Message;
                    showErrMessage(req.responseJSON.Title, message);
                }

                reject(req);
            }
        });

    });
}
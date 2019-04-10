
$(function () {
    //----- OPEN Modal and stranfer data
    $('[data-popup-openComment]').on('click', function (e) {
        $('#traloi').modal('show');


        var id = $(this).attr('data-id');
        var username = $(this).attr('data-username')
        var tourID = $(this).attr('data-tourID')
        $('#btn-send').attr('data-id', id);
        $('#btn-send').attr('data-username', username);
        $('#btn-send').attr('data-tourID', tourID);
    });
});
$(function () {

    //Call controller in server and return
    $('#btn-send').on('click', function (e) {
        //$('#traloi').modal('show');
        var content = $('#Content-FeedBack').val();
        if (content.length < 30) {
            $('#Comment-message').show().text('Mời nhập nội dung nhiều hơn 30 ký tự');
            return;
        }

        var id = $(this).attr('data-id');  
        var username = $(this).attr('data-username')
        var tourID = $(this).attr('data-tourID')
        var now = new Date();

        var tbl_FeedBack = {
            FeedBackContent: content,
            ReplyTo: id,
            Username: username,
            TourID: tourID,
            DateCreate: now,
        };
        $.ajax({
            url: '/FeedBack/Comment',
            type: 'POST',
            data: JSON.stringify(tbl_FeedBack),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                if (response.status == true) {
                    alert(response.message);

                    window.location.reload();
                } else {
                    alert(response.message);
                }
            },
            error: function (response) {
                alert(response.message);
            }
        });
    });
});


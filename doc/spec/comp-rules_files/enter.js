$(function() {
    $("#sbmtfrm").submit(function(){

        $("#sbmtfrm .feedback").html("<p>Sending entry....</p>");
        var surl = $(this).attr("action");
        var formData = new FormData($(this)[0]);

        $.ajax({
            url: surl,
            type: 'POST',
            data: formData,
            async: true,
            success: function (data) {
                if (data == true)
                    $("#sbmtfrm .feedback").html("<h4>Thank You!</h4><p>Your entry has been received. Good luck!</p>");
                else
                    $("#sbmtfrm .feedback").html("<h4>Sorry</h4><p>Something went wrong when submitting. Please email ibm2016comp@theregister.com</p><pre>E1-" + data + '</pre>');
            },
            error: function (x, status, err) {
                $("#sbmtfrm .feedback").html("<h4>Sorry</h4><p>Something went wrong when submitting. Please email ibm2016comp@theregister.com</p><pre><u>E2-" + status + ' ' + err + "</u>\n" + x.responseText + "</pre>");
            },
            cache: false,
            contentType: false,
            processData: false
        });

        return false;

        });

});

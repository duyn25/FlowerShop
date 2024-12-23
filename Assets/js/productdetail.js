
(function ($) {
    "use strict";

    function updateQuantity(button) {
        var oldValue = button.parent().parent().find('input').val();
        var newVal;

        if (button.hasClass('btn-plus')) {
            newVal = parseFloat(oldValue) + 1;
        } else {
            newVal = (oldValue > 0) ? parseFloat(oldValue) - 1 : 0;
        }

        button.parent().parent().find('input').val(newVal);
    }

    $('.quantity button').on('click', function (e) {
        e.preventDefault();
        var button = $(this);
        updateQuantity(button);  
    });

})(jQuery);

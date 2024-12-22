// quantity.js

(function ($) {
    "use strict";

    // Hàm xử lý thay đổi số lượng sản phẩm
    function updateQuantity(button) {
        var oldValue = button.parent().parent().find('input').val();
        var newVal;

        // Nếu là nút "+" (tăng số lượng)
        if (button.hasClass('btn-plus')) {
            newVal = parseFloat(oldValue) + 1;
        } else {
            // Nếu là nút "-" (giảm số lượng) và số lượng > 0
            newVal = (oldValue > 0) ? parseFloat(oldValue) - 1 : 0;
        }

        // Cập nhật lại giá trị vào ô input
        button.parent().parent().find('input').val(newVal);
    }

    // Sự kiện click cho các nút tăng giảm số lượng
    $('.quantity button').on('click', function () {
        var button = $(this);
        updateQuantity(button);  // Gọi hàm xử lý
    });

})(jQuery);

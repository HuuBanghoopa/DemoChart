// wwwroot/js/site.js
// Hàm này sẽ chạy khi trang được tải
document.addEventListener('DOMContentLoaded', function () {
    // Alert messages sẽ tự động biến mất sau 3 giây
    setTimeout(function () {
        const alerts = document.querySelectorAll('.alert');
        alerts.forEach(function (alert) {
            const bsAlert = new bootstrap.Alert(alert);
            bsAlert.close();
        });
    }, 3000);

    // Thêm tooltip cho tất cả các elements có data-bs-toggle="tooltip"
    const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
});
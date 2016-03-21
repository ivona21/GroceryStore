(function () {

    var module = angular.module('productReportControllers', []);

    module.controller('productReportController', ['productService', function (productService) {

        var ctrl = this;
        ctrl.service = productService;

        ctrl.service.getActiveProducts();
        ctrl.service.getFirstProduct();      


        if (ctrl.service.product.Id) {
            ctrl.service.getReport(ctrl.service.product.Id);
        }

    }]);

})();
(function () {

    var module = angular.module('productReportControllers', []);

    module.controller('productReportController', ['productService', function (productService) {

        var ctrl = this;
        ctrl.service = productService;
    }]);

})();
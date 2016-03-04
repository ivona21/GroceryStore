(function () {

    var module = angular.module('priceSetControllers', []);

    module.controller('priceSetController', ['priceSetService', 'productService', function (priceSetService, productService) {

        var ctrl = this;
        ctrl.service = priceSetService;
        ctrl.productService = productService;

        ctrl.productService.getProducts();     
    }]);
})();
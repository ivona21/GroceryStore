(function () {

    var module = angular.module('priceSetControllers', []);

    module.controller('priceSetController', ['priceSetService', 'productService', function (priceSetService, productService) {

        var ctrl = this;
        ctrl.service = priceSetService;
        ctrl.productService = productService;

        ctrl.productService.getActiveProducts();
        ctrl.first = ctrl.productService.getFirstProduct();

        if (ctrl.productService.product.Id) {
            ctrl.service.getPriceSetsByProductId(ctrl.productService.product.Id);
        }
      
    }]);
})();
(function () {

    var module = angular.module('productControllers', []);

    module.controller('productsController', ['productService', function (productService) {

        var ctrl = this;
        
        ctrl.service = productService;
        ctrl.service.getProducts();
        
        
       
    }]);



})();
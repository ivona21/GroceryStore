(function () {

    var module = angular.module('relationshipControllers', []);

    module.controller('relationshipController', ['$http', 'relationshipService', 'productService', 'categoryService', function ($http, relationshipService, productService, categoryService) {

        var ctrl = this;
        ctrl.service = relationshipService;

        ctrl.productService = productService;
        ctrl.productService.getFirstProduct();
        ctrl.product = ctrl.productService.product;
        ctrl.categoryService = categoryService;       
        ctrl.category = ctrl.categoryService.category;


        ctrl.productService.getActiveProducts();
        ctrl.categoryService.getActiveCategories();     

        if (ctrl.product.Id) {          
            ctrl.service.getAssignedCategories(ctrl.productService.product.Id);
        }

        ctrl.connectOrDisconnect = function (connected, categoryId) {
            if (!connected) {
                relationshipService.disconnect(ctrl.productService.product.Id, categoryId);
            }
            else {
                ctrl.connect(categoryId);
            }

        };

        ctrl.connect = function (categoryId) {
            $http({
                method: 'POST',
                url: '/api/relationships',
                headers: {
                    'Content-Type': 'application / json'
                },
                data: {
                    productId: ctrl.productService.product.Id,
                    categoryId: categoryId,
                    connected: true
                }
            }).then(function (response) {
                console.log(response.data)
            }, function (response) {
                console.log(response.statusText);
            });
        }
       
    }]);
})();
(function () {

    var module = angular.module('relationshipControllers', []);

    module.controller('relationshipController', ['$http', 'relationshipService', 'productService', 'categoryService', function ($http, relationshipService, productService, categoryService) {

        var ctrl = this;
        ctrl.service = relationshipService;

        ctrl.productService = productService;
        ctrl.productService.getActiveProducts();
        ctrl.product = ctrl.productService.product;

        ctrl.categoryService = categoryService;
        ctrl.categoryService.getActiveCategories();
        ctrl.category = ctrl.categoryService.category;

        ctrl.connect = function () {
            $http({
                method: 'POST',
                url: '/api/relationships',
                headers: {
                    'Content-Type': 'application / json'
                },
                data: {
                    productId: ctrl.productService.product.Id,
                    categoryId: ctrl.categoryService.category.Id,
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
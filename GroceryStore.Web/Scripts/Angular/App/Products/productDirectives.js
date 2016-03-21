(function () {

    var module = angular.module('productDirectives', []);

    module.directive('productAddUpdate', [function () {

        return {
            url: '/products',
            templateUrl: '/Scripts/Angular/App/Products/productAddUpdate.html',
            controller: 'productsController',
            controllerAs: 'productsCtrl'
        }

    }]);




})();
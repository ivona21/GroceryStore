(function () {

    var app = angular.module("GroceryStore", ["ngResource", "ui.router",
                                               "commonDirectives", "commonControllers",
                                               "productDirectives", "productControllers", "productServices",
                                               "categoryDirectives", "categoryControllers", "categoryServices",
                                               "relationshipControllers", "relationshipServices",
                                               "priceSetControllers", "priceSetServices",
                                               "productReportControllers"]);


    app.config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise('/products');

        $stateProvider
        .state('products', {
            url: '/products',
            templateUrl: '/Scripts/Angular/App/Products/productList.html',
            controller: 'productsController',
            controllerAs: 'productsCtrl'
        }).state('categories', {
            url: '/categories',
            templateUrl: '/Scripts/Angular/App/Categories/categoryList.html',
            controller: 'categoriesControllers',
            controllerAs: 'catCtrl'
        }).state('priceSets', {
            url: '/priceSets',
            templateUrl: '/Scripts/Angular/App/PriceSets/priceSetList.html',
            controller: 'priceSetController',
            controllerAs: 'psCtrl'
        }).state('relationships', {
            url: '/relationships',
            templateUrl: '/Scripts/Angular/App/Relationships/relationshipList.html',
            controller: 'relationshipController',
            controllerAs: 'relCtrl'
        }).state('productReports', {
            url: '/productReports',
            templateUrl: '/Scripts/Angular/App/ProductReports/productReportList.html',
            controller: 'productReportController',
            controllerAs: 'prCtrl'
        })
    }]);
})();
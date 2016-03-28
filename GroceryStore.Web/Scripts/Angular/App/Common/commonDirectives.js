(function () {

    var module = angular.module('commonDirectives', []);

    module.directive('productListShort', [function () {

        return {
            templateUrl: '/Scripts/Angular/App/Common/productListShort.html',
            controller: 'navbarController',
            controllerAs: 'navCtrl'
        }

    }]);



})();
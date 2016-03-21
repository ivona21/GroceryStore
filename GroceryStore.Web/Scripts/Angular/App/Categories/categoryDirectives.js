(function () {

    var module = angular.module('categoryDirectives', []);

    module.directive('categoryAddUpdate', [function () {
        return {
            url: '/categories',
            templateUrl: '/Scripts/Angular/App/Categories/categoryAddUpdate.html',
            controller: 'categoriesControllers',
            controllerAs: 'catCtrl'
        }

    }]);




})();
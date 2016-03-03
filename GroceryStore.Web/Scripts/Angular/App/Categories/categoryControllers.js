(function () {

    var module = angular.module('categoryControllers', []);

    module.controller('categoriesControllers', ['categoryService', function (categoryService) {

        var ctrl = this;
        ctrl.service = categoryService;
        ctrl.service.getCategories();



    }]);

})();
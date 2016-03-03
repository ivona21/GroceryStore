(function () {

    var module = angular.module('relationshipServices', []);

    module.factory('relationship', ['$resource', function ($resource) {
        return $resource('/api/relationships/:id', null, {
            update: { method: 'put' }
        });
    }]);

    module.service('relationshipService', ['relationship', 'productService', 'categoryService', function (relationship, productService, categoryService) {

        var service = this;
        service.relationship = new relationship();
               
    }]);


})();
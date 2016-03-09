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
        service.assignedCategories = [];


        service.getAssignedCategories = function (id) {
            relationship.query({ productId: id }, function (response) {
                service.assignedCategories = response;
                console.log(response);
            });
        }        

        service.disconnect = function (productId, categoryId) {
            console.log('service.disconnect');
            service.relationship.$delete({ productId: productId, categoryId: categoryId }, function (response) {
                console.log(response);
            });
        }

    }]);
})();
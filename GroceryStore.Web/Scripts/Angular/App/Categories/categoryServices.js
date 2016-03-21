(function () {

    var module = angular.module('categoryServices', []);

    module.factory('category', ["$resource", function ($resource) {
        return $resource('/api/categories/:id', null, {
            update: { method: 'PUT' }
        });
    }]);

    module.service('categoryService', ['category', function (category) {

        var service = this;
        service.category = new category();
        service.categoryIndex;
        service.categories = [];

        service.getCategories = function () {
            category.query(function (response) {
                service.categories = response;
            });
        };

        service.getActiveCategories = function () {
            category.query({ onlyActive: true }, function (response) {
                service.categories = response;
            });
        }

        service.getCategory = function (id, $index) {
            console.log('get category');
            service.category = new category();
            service.category.$get({ id: id }, function (response) {
                service.category = response;
                service.categoryIndex = $index;
                service.categories[$index] = service.category;             
            })
        };

        service.addCategory = function () {
            service.category.$save(function (response) {
                service.categories.push(response);
                service.emptyForm();
            });
        }

        service.updateCategory = function () {
            service.category.$update({ id: service.category.Id, category: service.category }, function (response) {
                service.emptyForm();
            })
        }

        service.addOrUpdate = function () {
            if (!service.category.Id)
                service.addCategory();
            else           
                service.updateCategory();
        }

        service.deleteCategory = function (id, $index) {
            service.category.$delete({ id: id }, function (response) {
                service.categories.splice($index, 1);
                service.emptyForm();
            });
        }

        service.emptyForm = function () {
            if (service.category.Id)
                service.getCategories();

            service.category = new category();
            service.categoryIndex = -1
        }
    }]);
})();
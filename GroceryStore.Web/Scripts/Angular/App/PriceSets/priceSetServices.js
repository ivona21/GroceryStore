(function () {

    var module = angular.module('priceSetServices', []);

    module.factory('priceSet', ['$resource', function ($resource) {
        return $resource('/api/pricesets/:id')
    }]);

    module.service('priceSetService', ['priceSet', function (priceSet) {

        var service = this;
        service.priceSet = new priceSet();
        service.priceSetIndex;
        service.product = {};
        service.priceSets = [];

        service.addPriceSet = function () {
            service.priceSet.$save({ productId: service.product.Id }, function (response) {               
                response.Date = new Date(response.Date);
                service.priceSets.push(response);
                service.emptyForm();
            });
        }

        service.getPriceSetsByProductId = function (id) {          
            priceSet.query({ productId: id || service.product.Id }, function (response) {
                service.priceSets = response;
            });
        }

        service.deletePriceSet = function (priceSetId, $index) {
            service.priceSet.$delete({ id: priceSetId }, function (response) {
                service.priceSets.splice($index, 1);
                service.emptyForm();
            });
        }

        service.emptyForm = function () {
            service.priceSet = new priceSet();
            service.priceSetIndex = -1;
        }
    }]);
})();
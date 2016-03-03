(function () {

    var module = angular.module('priceSetServices', []);

    module.factory('priceSet', ['$resource', function ($resource) {
        return $resource('/api/pricesets/:id')
    }]);

    module.service('priceSetService', ['priceSet', function (priceSet) {

        var service = this;


    }]);
})();
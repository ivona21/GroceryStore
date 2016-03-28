(function () {

    var module = angular.module('productServices', [])


    module.factory('product', ["$resource", function ($resource) {

        return $resource('/api/products/:id', null, {
            update: { method: "put" }
        });
    }]);

    module.service('productService', ['product', 'priceSetService', function (product, priceSetService) {

        var service = this;
        service.priceSetService = priceSetService;

        service.products = [];
        service.activeProducts = [];
        service.product = new product();
        service.productIndex;
        service.activeTab = 1;

        service.productReport = {};

        service.getProducts = function () {
            product.query(function (response) {
                service.products = response;
            });
        };

        service.getActiveProducts = function () {          
            product.query({ onlyActive: true }, function (response) {
                service.activeProducts = response;
            });
        }

        service.getProduct = function (id, $index) {
            service.product = new product();           
            service.product.$get({ id: id }, function (response) {
                service.product = response;
                service.productIndex = $index;
                service.products[$index] = service.product;

                //if this action is called from priceset tab, get prices of certain product
                //service.activeTab is set in navbarController (commonControllers.js)
                if (service.activeTab == 4) {
                    service.priceSetService.product = service.product;
                    service.priceSetService.getPriceSetsByProductId();
                }               
            });
        };

        service.setProductIndexTo0 = function () {
            service.productIndex = 0;
        }
       

        service.getFirstProduct = function () {
            service.product.$get({ first: 'first' }, function (response) {
                service.firstProduct = response;               
            });
        };

        service.getReport = function (id, $index) {           
            service.product.$get({ productId: id, littleCheat: 'hi' }, function (response) {
                service.productReport = response;
                service.product = service.getProduct(id, $index);
            });
        }

        service.addProduct = function () {
            service.product.$save(function (response) {
                service.product = response;
                service.products.push(service.product);
                service.emptyForm();
            }, function (error) {
                bootbox.alert(error.data.Message);
            });
        }

        service.updateProduct = function () {
            service.product.$update({ id: service.product.Id, product: service.product }, function (response) {
                service.emptyForm();
            }, function (error) {
                bootbox.alert(error.data.Message);
            });
        }

        service.addOrUpdate = function () {
            if (!service.product.Id)
                service.addProduct();
            else
                service.updateProduct();
        }

         service.deleteConfirm = function (id, $index) {
             bootbox.confirm("Are you sure?", function (result) {
                 if (result) {
                     service.deleteProduct(id, $index);
                 }               
            });
         }

        service.deleteProduct = function (id, $index) {
            service.product.$delete({ id: id }, function (response) {
                service.products.splice($index, 1);
                service.emptyForm();
            }, function (error) {
                bootbox.alert(error.data.Message);               
            });
        }

        service.emptyForm = function () {
            if (service.product.Id) {
                service.getProducts();
            }
            service.product = new product();
            service.productIndex = -1;
        }

       
    }]);
})();
(function () {

    'use strict';
    angular.module('app').controller('ListRestaurantCtrl', ListRestaurantCtrl);

    ListRestaurantCtrl.$inject = ['$scope', '$rootScope', 'RestaurantFactory', '$location', 'SETTINGS'];

    function ListRestaurantCtrl($scope, $rootScope, RestaurantFactory, $location, SETTINGS) {

        var vm = this;

        //VM's
        vm.listRestaurant = [];

        //FUNCTIONS
        vm.removeRestaurant = removeRestaurant;

        constructor();

        function constructor() {
            getAll();
        }

        function getAll() {

            RestaurantFactory.getAll()
               .success(success)
               .catch(fail);

            function success(response) {
                vm.listRestaurant = response;
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao recuperar os restaurantes da Api');
            }
        }

        function removeRestaurant(restaurantId) {

            RestaurantFactory.remove(restaurantId)
               .success(success)
               .catch(fail);

            function success(response) {

                if (response == null) {
                    toastr.error(error.data.error_description, 'Falha ao remover o restaurante em específico');
                }
                else {
                    toastr.success('Restaurante removido com sucesso', 'Sucesso');
                    getAll();
                }
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao remover o restaurante em específico');
            }
        }
    }

})();
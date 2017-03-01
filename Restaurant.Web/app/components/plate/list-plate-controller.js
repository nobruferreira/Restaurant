(function () {

    'use strict';
    angular.module('app').controller('ListPlateCtrl', ListPlateCtrl);

    ListPlateCtrl.$inject = ['$scope', '$rootScope', 'PlateFactory', '$location', 'SETTINGS'];

    function ListPlateCtrl($scope, $rootScope, PlateFactory, $location, SETTINGS) {

        var vm = this;

        //VM's
        vm.listPlate = [];

        //FUNCTIONS
        vm.removePlate = removePlate;

        constructor();

        function constructor() {
            getAll();
        }

        function getAll() {

            PlateFactory.getAll()
               .success(success)
               .catch(fail);

            function success(response) {
                vm.listPlate = response;
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao recuperar os pratos dos restaurantes da Api');
            }
        }

        function removePlate(plateId, restaurantId) {

            PlateFactory.remove(plateId, restaurantId)
               .success(success)
               .catch(fail);

            function success(response) {

                if (response == null) {
                    toastr.error(error.data.error_description, 'Falha ao remover o prato do restaurante em específico');
                }
                else {
                    toastr.success('Prato do restaurante removido com sucesso', 'Sucesso');
                    getAll();
                }
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao remover o prato do restaurante em específico');
            }
        }
    }

})();
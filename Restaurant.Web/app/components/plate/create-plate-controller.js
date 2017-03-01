(function () {

    'use strict';
    angular.module('app').controller('CreatePlateCtrl', CreatePlateCtrl);

    CreatePlateCtrl.$inject = ['$scope', '$rootScope', 'PlateFactory', 'RestaurantFactory', '$location', '$routeParams', 'SETTINGS'];

    function CreatePlateCtrl($scope, $rootScope, PlateFactory, RestaurantFactory, $location, $routeParams, SETTINGS) {

        var vm = this;

        //$routeParams
        vm.plateId = $routeParams.plateId;
        vm.restaurantId = $routeParams.restaurantId;

        //VM's
        vm.listRestaurantSelect = [];

        vm.plate = {
            plateId: 0,
            plateName: '',
            price: 0,
            restaurantId: 0,
            restaurantName: ''
        };

        //PUT
        vm.update = {
            plateId: 0,
            plateName: '',
            price: 0,
            restaurantId: 0
        };

        //POST
        vm.create = {
            plateName: '',
            price: 0,
            restaurantId: 0
        };

        //FUNCTIONS
        vm.createOrEditPlate = createOrEditPlate;
        vm.cancel = cancel;

        constructor();

        function constructor() {

            if (vm.plateId > 0 && vm.restaurantId > 0) {
                getAllRestaurant();
                getByIdRestaurant();
                getByIdPlate();
                sessionStorage.setItem('requestPlate', 'update');
            }
            else {
                getAllRestaurant();
                sessionStorage.setItem('requestPlate', 'create');
            }
        }

        function getAllRestaurant() {

            RestaurantFactory.getAll()
                   .success(success)
                   .catch(fail);

            function success(response) {
                vm.listRestaurantSelect = response;
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao recuperar os restaurantes da Api');
            }
        }

        function getByIdRestaurant() {

            RestaurantFactory.getById(vm.restaurantId)
              .success(success)
              .catch(fail);

            function success(response) {

                if (response == null) {
                    toastr.error(error.data.error_description, 'Falha ao recuperar o restaurante em específico da Api');
                }

                vm.plate.restaurantName = response.restaurantName;
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao recuperar o restaurante em específico da Api');
            }
        }

        function getByIdPlate() {

            PlateFactory.getById(vm.plateId, vm.restaurantId)
               .success(success)
               .catch(fail);

            function success(response) {

                if (response == null) {
                    toastr.error(error.data.error_description, 'Falha ao recuperar o prato do restaurante em específico da Api');
                }

                vm.plate.plateName = response.plateName;
                vm.plate.price = response.price;
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao recuperar os pratos dos restaurantes da Api');
            }
        }

        function createOrEditPlate() {

            if (sessionStorage.getItem('requestPlate') == 'update') {
                updatePlate();
            }
            else if (sessionStorage.getItem('requestPlate') == 'create') {
                createPlate();
            }
        }

        function updatePlate() {

            //var price = vm.plate.price.replace(/,/g, ".");

            //PUT
            vm.update = {
                plateId: vm.plateId,
                plateName: vm.plate.plateName,
                price: vm.plate.price,
                restaurantId: vm.restaurantId
            };

            PlateFactory.update(vm.update)
               .success(success)
               .catch(fail);

            function success(response) {

                if (response == null) {
                    toastr.error(error.data.error_description, 'Falha ao editar o prato do restaurante em específico');
                }
                else {
                    toastr.success('Prato do restaurante editado com sucesso', 'Sucesso');
                    $location.path('/prato/consulta-prato');
                }
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao editar o prato do restaurante em específico');
            }
        }

        function createPlate() {

            var price = vm.plate.price.replace(/,/g, ".");

            vm.create = {
                plateName: vm.plate.plateName,
                price: price,
                restaurantId: vm.plate.restaurantId
            };

            PlateFactory.create(vm.create)
               .success(success)
               .catch(fail);

            function success(response) {

                toastr.success('Novo prato do restaurante cadastrado com sucesso', 'Sucesso');
                $location.path('/prato/consulta-prato');
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao criar o novo prato do restaurante');
            }
        }

        function cancel() {
            
            vm.plate = {
                plateId: 0,
                plateName: '',
                price: 0,
                restaurantId: 0
            };

            vm.update = {
                plateId: 0,
                plateName: '',
                price: 0,
                restaurantId: 0
            };

            vm.create = {
                plateName: '',
                price: 0,
                restaurantId: 0
            };

            $location.path('/prato/consulta-prato');
        }
    }

})();
(function () {

    'use strict';
    angular.module('app').controller('CreateRestaurantCtrl', CreateRestaurantCtrl);

    CreateRestaurantCtrl.$inject = ['$scope', '$rootScope', 'RestaurantFactory', '$location', '$routeParams', 'SETTINGS'];

    function CreateRestaurantCtrl($scope, $rootScope, RestaurantFactory, $location, $routeParams, SETTINGS) {

        var vm = this;

        //$routeParams
        vm.restaurantId = $routeParams.restaurantId;

        //VM's
        vm.restaurant = {
            restaurantId: 0,
            restaurantName: ''
        };

        //PUT
        vm.update = {
            restaurantId: 0,
            restaurantName: ''
        };

        //POST
        vm.create = {
            restaurantName: ''
        };

        //FUNCTIONS
        vm.createOrEditRestaurant = createOrEditRestaurant;
        vm.cancel = cancel;

        constructor();

        function constructor() {
            
            if (vm.restaurantId > 0) {
                getById();
                sessionStorage.setItem('requestRestaurant', 'update');
            }
            else {
                sessionStorage.setItem('requestRestaurant', 'create');
            }
        }

        function getById() {

            RestaurantFactory.getById(vm.restaurantId)
               .success(success)
               .catch(fail);

            function success(response) {

                if (response == null) {
                    toastr.warning('Favor cadastrar novos restaurantes', 'Alerta');
                }

                vm.restaurant.restaurantName = response.restaurantName;
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao recuperar o restaurante em específico da Api');
            }
        }

        function createOrEditRestaurant() {

            if (sessionStorage.getItem('requestRestaurant') == 'update') {
                updateRestaurant();
            }
            else if (sessionStorage.getItem('requestRestaurant') == 'create') {
                createRestaurant();
            }
        }

        function updateRestaurant() {

            vm.update = {
                restaurantId: vm.restaurantId,
                restaurantName: vm.restaurant.restaurantName
            };

            RestaurantFactory.update(vm.update)
               .success(success)
               .catch(fail);

            function success(response) {

                if (response == null) {
                    toastr.error(error.data.error_description, 'Falha ao editar o restaurante em específico');
                }
                else {
                    toastr.success('Restaurante editado com sucesso', 'Sucesso');
                    $location.path('/restaurante/consulta-restaurante');
                }
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao editar o restaurante em específico');
            }
        }

        function createRestaurant() {

            vm.create = {
                restaurantName: vm.restaurant.restaurantName
            };

            RestaurantFactory.create(vm.create)
               .success(success)
               .catch(fail);

            function success(response) {

                toastr.success('Novo restaurante cadastrado com sucesso', 'Sucesso');
                $location.path('/restaurante/consulta-restaurante');
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao criar o novo restaurante');
            }
        }

        function cancel() {
           
            vm.restaurant = {
                restaurantId: 0,
                restaurantName: '',
            };

            vm.update = {
                restaurantId: 0,
                restaurantName: ''
            };

            vm.create = {
                restaurantName: ''
            };

            $location.path('/restaurante/consulta-restaurante');
        }
    }

})();
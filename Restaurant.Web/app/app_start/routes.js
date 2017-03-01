(function () {

    'use strict';

    angular.module('app').config(function ($routeProvider) {

        $routeProvider

            // Home
            .when('/home', {
                controller: 'HomeCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/components/home/home-view.html'
            })

            // Restaurant
            .when('/restaurante/consulta-restaurante', {
                controller: 'ListRestaurantCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/components/restaurant/list-restaurant-view.html'
            })

            .when('/restaurante/cadastro-restaurante/:restaurantId', {
                controller: 'CreateRestaurantCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/components/restaurant/create-restaurant-view.html'
            })

            // Plate
            .when('/prato/consulta-prato', {
                controller: 'ListPlateCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/components/plate/list-plate-view.html'
            })

            .when('/prato/cadastro-prato/:plateId/:restaurantId', {
                controller: 'CreatePlateCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/components/plate/create-plate-view.html'
            })

            .otherwise({
                redirectTo: '/home'
            });
    });

})();
(function () {

    'use strict';

    angular.module('app').factory('RestaurantFactory', RestaurantFactory);

    RestaurantFactory.$inject = ['$rootScope', '$http', 'SETTINGS'];

    function RestaurantFactory($rootScope, $http, SETTINGS) {

        return {
            getAll: getAll,
            getById, getById,
            create: create,
            update, update,
            remove: remove
        };

        function getAll() {
            return $http.get(SETTINGS.ACCESS_URL + 'api/restaurant/getAll');
        }

        function getById(restaurantId) {
            return $http.get(SETTINGS.ACCESS_URL + 'api/restaurant/getById/' + restaurantId);
        }

        function create(data) {
            return $http.post(SETTINGS.ACCESS_URL + 'api/restaurant/create', data);
        }

        function update(data) {
            return $http.put(SETTINGS.ACCESS_URL + 'api/restaurant/update', data);
        }

        function remove(id) {
            return $http.delete(SETTINGS.ACCESS_URL + 'api/restaurant/remove/' + id);
        }
    }

})();
(function () {

    'use strict';

    angular.module('app').factory('PlateFactory', PlateFactory);

    PlateFactory.$inject = ['$rootScope', '$http', 'SETTINGS'];

    function PlateFactory($rootScope, $http, SETTINGS) {

        return {
            getAll: getAll,
            getById, getById,
            create: create,
            update, update,
            remove: remove
        };

        function getAll() {
            return $http.get(SETTINGS.ACCESS_URL + 'api/plate/getAll');
        }

        function getById(plateId, restaurantId) {
            return $http.get(SETTINGS.ACCESS_URL + 'api/plate/getById/' + plateId + '/' + restaurantId);
        }

        function create(data) {
            return $http.post(SETTINGS.ACCESS_URL + 'api/plate/create', data);
        }

        function update(data) {
            return $http.put(SETTINGS.ACCESS_URL + 'api/plate/update', data);
        }

        function remove(plateId, restaurantId) {
            return $http.delete(SETTINGS.ACCESS_URL + 'api/plate/remove/' + plateId + '/' + restaurantId);
        }
    }

})();
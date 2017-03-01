(function () {

    'use strict';

    angular.module('app').constant('SETTINGS', {
        'VERSION': '0.0.1',
        'CURR_ENV': 'dev',
        'AUTH_PRIVATE_KEY': 'res-private-key',
        'AUTH_PUBLIC_KEY': 'res-public-key',
        'AUTH_TOKEN': 'res-token',
        'ACCESS_URL': 'http://localhost:2652/'
    });

    angular.module('app').filter('parseToHtml', function ($sce) {
        return function (val) {
            return $sce.trustAsHtml(val);
        };
    });

})();
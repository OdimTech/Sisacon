(function () {

    'use strict';

    angular
        .module('app')
        .config(function (localStorageServiceProvider) {

            localStorageServiceProvider.setPrefix('Sisacon');
        });

})();
(function () {

    'use strict';

    angular
        .module('app')
        .controller('ConfigurationController', ConfigurationController)

    ConfigurationController.$inject = [];

    function ConfigurationController() {

        angular.element('.menu .item').tab();

    };

})();
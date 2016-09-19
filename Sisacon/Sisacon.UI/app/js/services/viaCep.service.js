angular.module('app').factory('viaCepService', function ($http) {

    'use strict';

    var _getAddress = function (cep) {

        return $http.get('http://viacep.com.br/ws/' + cep + '/json/ ');
    };

    return {

        getAddress: _getAddress
    }
});
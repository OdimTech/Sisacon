angular.module('sisacon').controller('SingUpController', ['$scope', 'ViaCepService', function ($scope, ViaCepService) {

    'use strict';

    //INIT CONTROLS
    angular.element('.ui.dropdown').dropdown();

    //METHODS
    $scope.getAddress = function (cep) {

        if (cep != null) {
            
            ViaCepService.getAddress(cep).success(function (response) {

                if (response.erro != true)
                    $scope.address = response;
            })
            .error(function (response) {

                alert('CEP não encontrado, favor preencher o endereço manualmente');
            });
        }
    };

}]);
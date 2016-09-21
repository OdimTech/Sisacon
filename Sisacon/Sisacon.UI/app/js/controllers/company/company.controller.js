angular.module('app.index').controller('CompanyController', ['$scope', 'viaCepService', 'blockUI', 'valuesService', function ($scope, viaCepService, blockUI, valuesService) {

    //INIT CONTROLS
    angular.element('.ui.dropdown').dropdown();

    angular.element('button').popup({
        on: 'hover',
        position: 'right center'
    });

    $scope.company = {};
    $scope.defaultLogo = valuesService.getDefaultLogo;

    $scope.company.logo = {

        format: null,
        options: [

          { id: 0, text: 'Quadrado' },
          { id: 1, text: 'Circular' }
        ]
    }

    $scope.submit = function () {


    }

    $scope.getAddress = function () {

        blockUI.start('Obtendo Endereço...');

        viaCepService.getAddress($scope.company.address.cep).success(function (response) {

            blockUI.stop();
            debugger;

            $scope.company.address.cep = response.cep;
            $scope.company.address.logradouro = response.logradouro;
            $scope.company.address.complemento = response.complemento;
            $scope.company.address.bairro = response.bairro;
            $scope.company.address.cidade = response.localidade;
            $scope.company.address.estado = response.uf;

        }).error(function (response) {

            blockUI.stop();
            console.log(response);
        });
    };

}]);
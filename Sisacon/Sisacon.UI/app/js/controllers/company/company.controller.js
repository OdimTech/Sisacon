angular.module('app.index').controller('CompanyController', ['$scope', 'viaCepService', function ($scope, viaCepService) {

    //INIT CONTROLS
    angular.element('.ui.dropdown').dropdown();
    
    $scope.company = {};

    $scope.submit = function () {

        
    }

    $scope.getAddress = function () {

        viaCepService.getAddress($scope.company.address.cep).success(function (response) {

            $scope.company.address = response;

        }).error(function (response) {

            console.log(response);
        });
    };

}]);
angular.module('app.index').controller('InitialDashboardController', ['$scope', '$routeParams', 'accountService', 'loggedUserService', function ($scope, $routeParams, accountService, loggedUserService) {

    $scope.loggedUser = {};

    var idUser = $routeParams.id;

    if(idUser > 0)
    {
        accountService.getUserById(idUser).success(function (response) {

            //Carrega os dados do usuário logado, e envia para o service LoggedUser
            $scope.loggedUser = response.value;
            loggedUserService.setUser(response.value);

            if($scope.loggedUser.showWellcomeMessage)
            {
                showWellcomeMessage();
            }

        }).error(function (response) {

            console.log(response);
        })
    }

    function showWellcomeMessage() {


    }

}]);
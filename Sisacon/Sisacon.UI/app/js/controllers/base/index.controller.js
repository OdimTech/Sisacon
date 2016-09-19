angular.module('app.index').controller('IndexController', ['$scope', 'accountService', 'loggedUserService', function ($scope, accountService, loggedUserService) {

    $scope.account = {};

    $scope.openMenu = function () {

        angular.element('#sidebar').sidebar({

            closable: true,
            transition: 'overlay',
            dimPage: true

        }).sidebar('toggle');
    };

    //INIT CONTROLS
    angular.element('#account').popup({

        inline: true,
        hoverable: true,
        popup: '#accountPopUp',
        on: 'click',
        position: 'bottom right'

    });

    angular.element('#sidebar').accordion({

        on: 'click',
        collapsible: true,
        exclusive: true

    }).accordion();

}]);

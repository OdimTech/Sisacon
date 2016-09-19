angular.module('app').controller('AdminController', ['$scope', function ($scope) {

    'use strict';

    //INIT CONTROLS
    angular.element('#sidebar').accordion({

        on: 'click',
        collapsible: true,
        exclusive: true

    }).accordion();

    $scope.openMenu = function () {

        angular.element('#sidebar').sidebar({

            closable: true,
            transition: 'overlay',
            dimPage: true

        }).sidebar('toggle');
    };
}]);


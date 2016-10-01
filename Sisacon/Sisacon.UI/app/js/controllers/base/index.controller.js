﻿(function () {

    'use strict';

    angular
        .module('app')
        .controller('IndexController', IndexController);

    IndexController.$inject = ['$scope', 'accountService', 'localStorageService'];

    function IndexController($scope, accountService, localStorageService) {

        $scope.loggedUser = {};
        getUserFromServer();

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

        //FUNCTIONS
        $scope.openMenu = function () {

            angular.element('#sidebar').sidebar({

                closable: true,
                transition: 'overlay',
                dimPage: true

            }).sidebar('toggle');
        };

        function getUserFromServer() {

            accountService.getUserById(localStorageService.get('id')).success(function (response) {

                $scope.loggedUser = response.value;

            }).error(function (response) {

                console.log(response);
            });
        }
    }

})();


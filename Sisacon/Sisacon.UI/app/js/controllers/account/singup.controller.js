angular.module('app.landingPage.account')

    .controller('SingUpController', ['$scope', 'viaCepService', 'accountService', 'loggedUserService', '$window', '$timeout', 'toastr',

        function ($scope, viaCepService, accountService, loggedUserService, $window, $timeout, toastr ) {

            'use strict';

            //INIT VALUES
            $scope.account = {};
            $scope.address = {};
            $scope.termsAccepted = false;

            //INIT CONTROLS
            angular.element('.ui.dropdown').dropdown();

            angular.element('button').popup({
                on: 'click',
                position: 'top left'
            });

            //METHODS
            $scope.createUser = function () {

                var password = $scope.singupForm.password.$viewValue;
                var confirmPassword = $scope.singupForm.confirmPassword.$viewValue;

                if ($scope.singupForm.$valid) {

                    if (password !== confirmPassword) {

                        $scope.singupForm.confirmPassword.$validators.notEquals = function () {

                            return true;
                        };

                        $scope.singupForm.confirmPassword.$valid = false;
                        $scope.singupForm.$valid = false;
                        return;
                    }
                    else {

                        $scope.singupForm.confirmPassword.$validators.notEquals = function () {

                            return false;
                        };

                        $scope.singupForm.confirmPassword.$valid = true;
                        $scope.singupForm.$valid = true;
                    }

                    accountService.createUser($scope.account).success(function (response) {

                        if (response.quantity > 0) {

                            toastr.success(response.message);

                            $timeout(function () {

                                $window.location.href = '#/login';

                            }, 3000);
                        }
                    })
                    .error(function (response) {

                        toastr.error(response.message);
                    });
                }
            };

            $scope.AcceptedTerms = function () {

                if ($scope.termsAccepted) {

                    $scope.termsAccepted = false;
                }
                else {

                    $scope.termsAccepted = true;
                }
            };
        }
    ]);



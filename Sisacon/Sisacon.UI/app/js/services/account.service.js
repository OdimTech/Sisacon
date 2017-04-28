(function () {

    'use strict';

    angular
        .module('app')
        .factory('accountService', accountService);

    function accountService($http, valuesService) {

        var apiUrl = valuesService.getApiUrl;

        var service = {

            getUsedEmail: getUsedEmail,
            getUserById: getUserById,
            createUser: createUser,
            loginUser: loginUser,
            getCountEntities: getCountEntities
        };

        return service;

        function getUsedEmail(email) {

            return $http.get(apiUrl + 'api/user', {

                params: { email: email }
            });
        }

        function getUserById(id) {

            return $http.get(apiUrl + 'api/user', {

                params: { id: id }
            });
        }

        function createUser(user) {

            var userCredentials = {

                pass: user.password,
                email: user.email
            };

            return $http({

                url: apiUrl + "api/user",
                method: 'POST',
                async: true,
                data: userCredentials
            });
        }

        function loginUser(user) {

            return $http.get(apiUrl + "api/user", {

                params: {

                    pass: user.password,
                    email: user.email
                }
            });
        }

        function getCountEntities(userId) {
            
            return $http.get(apiUrl + "api/user/count", {

                params: {

                    userId: userId
                }
            })
        }
    }

})();


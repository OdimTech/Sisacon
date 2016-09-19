angular.module('app.landingPage.account').factory('accountService', function ($http, valuesService, blockUI) {

    'use strict';

    var apiUrl = valuesService.getApiUrl;

    var _getUsedEmail = function (email) {

        return $http.get(apiUrl + 'api/user', {

            params: { email: email }
        });
    };

    var _getUserById = function (id) {

        return $http.get(apiUrl + 'api/user', {

            params: { id: id }
        });
    }

    var _createUser = function (user) {

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
    };

    var _loginUser = function (user) {

        return $http.get(apiUrl + "api/user", {

            params: {

                pass: user.password,
                email: user.email
            }
        });
    }

    return {

        getUsedEmail: _getUsedEmail,
        getUserById: _getUserById,
        createUser: _createUser,
        loginUser: _loginUser
    }

});
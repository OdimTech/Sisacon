angular.module('app').service('loggedUserService', function () {

    var _loggedUser;

    return {

        getUser: function () {

            return _loggedUser;
        },
        setUser: function (user) {

            _loggedUser = user;
            debugger;
        }
    }

})
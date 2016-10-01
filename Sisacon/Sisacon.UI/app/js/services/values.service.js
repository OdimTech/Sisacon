(function () {

    angular.module('app').value('valuesService', {

        getApiUrl: 'http://localhost:20794/',
        getEmailPatern: /^[_a-z0-9]+(\.[_a-z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/,
        getDefaultLogo: '../../../Content/UserImages/Default/CompanyLogo/default_logo.gif'

    });

})();



    


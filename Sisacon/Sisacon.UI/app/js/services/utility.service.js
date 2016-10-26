(function () {
    
    'use strict';

    angular
        .module('app')
        .factory('utilityService', utilityService);

    function utilityService() {
        
        var service = {

            validateDate: validateDate,
            convertStringToDate:convertStringToDate,
            createNewDate: createNewDate,
            convertDateToString: convertDateToString
        };

        return service;

        function validateDate(date) {

            var date = moment(date, 'YYYY/MM/DD').isValid();

            return date;

        }

        function convertDateToString(date) {

            var date = moment(date, moment.ISO_8601).format("DD-MM-YYYY");

            return date;
        }

        function convertStringToDate(strDate) {

            moment.locale('pt-BR');
            
            var date = moment(strDate, "DD-MM-YYYY");

            return date;
        }

        function createNewDate() {
            
            var date = moment().format();

            return date;
        }
    }

})();
(function () {

    angular
        .module('app')
        .factory('priceResearchService', priceResearchService);

    function priceResearchService($http, valuesService) {

        var apiUrl = valuesService.getApiUrl;
        var route = 'api/provider';

        var service = {

            save: save,
            update: update,
            getPriceById: getPriceById,
            getPriceByUserId: getPriceByUserId
        }

        return service;

        function save(price) {

            return $http.post(apiUrl + route, price);
        }

        function update(params) {
            
        }

        function getPriceById() {

            
        }
    }

})();
(function () {

    'use stricts';

    angular.module('app').controller('MaterialController', MaterialController);

    MaterialController.$inject = ['providerService', 'localStorageService'];

    function MaterialController(providerService, localStorageService) {

        var vm = this;

        vm.userId = localStorageService.get('id');
        vm.providers = [];
        vm.loadProviders = loadProviders;

        vm.loadProviders();

        //vm.series = ['Series A'];
        vm.labels = ['2006', '2007', '2008', '2009', '2010', '2011', '2012'];
        vm.data = [[65, 59, 80, 81, 56, 55, 40]];

        function loadProviders() {

            providerService.getProviderByUserId(vm.userId).success(function (response) {

                vm.providers = response.value;

            }).error(function (response) {



            })
        }
    }

})();
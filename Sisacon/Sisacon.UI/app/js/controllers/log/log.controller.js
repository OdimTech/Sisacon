(function () {

    'use strict';

    angular.module('app').controller('LogController', LogController);

    LogController.$inject = ['$scope', '$window', '$routeParams', 'localStorageService', 'logService', 'blockUI', 'toastr', 'DTOptionsBuilder', 'DTColumnBuilder', 'valuesService'];

    function LogController($scope, $window, $routeParams, localStorageService, logService, blockUI, toastr, DTOptionsBuilder, DTColumnBuilder, valuesService) {

        var vm = this;

        //VARIABLES
        vm.log = {};
        vm.logList = [];

        //METHODS
        vm.showLogDetail = showLogDetail;
        vm.loadLogs = loadLogs;

        initialize();

        function initialize() {

            //CASO EXISTA ALGUM VALOR NA URL, TRATA-SE DE EDIÇÃO, CASO NÃO TENHA É LISTAGEM 
            if ($routeParams.id) {

                loadLog();
            }
            else {

                loadLogs();
                loadDataTables();
            }
        }

        function loadDataTables() {

            vm.dtOptions = DTOptionsBuilder
                .newOptions()
                .withPaginationType('full_numbers')
                .withLanguage(valuesService.dataTableLanguage);

        }

        function loadLog() {

            logService.getLogById($routeParams.id).success(function (response) {

                vm.log = response.value;

            }).error(function (response) {

                toastr.error(response.message);
            })
        }

        function loadLogs() {

            logService.getLogs().success(function (response) {

                vm.logList = response.valueList;

            }).error(function (response) {

                toastr.error(response.message);

            })
        }

        function showLogDetail(idLog) {

            if (idLog) {

                $window.location.href = "#/logDetail?id=" + idLog;
            }
        }
    }

})();
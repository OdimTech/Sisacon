(function () {

    'use strict';

    angular
        .module('app')
        .controller('InitialDashboardController', InitialDashBoardController);

    InitialDashBoardController.$inject = ['$scope', 'accountService', 'companyService', 'localStorageService', 'blockUI'];

    function InitialDashBoardController($scope, accountService, companyService, localStorageService, blockUI) {

        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();

        //INIT OBJECTS
        $scope.company = {};
        $scope.idUser = 0;
        var idUser = localStorageService.get('id');  

        if(idUser){

            $scope.idUser = idUser; 
        }

        $scope.companyName = '';

        //debugger;
        getCompany();

        //INIT CALENDAR CONFIG
        $scope.uiConfig = {
            calendar: {
                height: 600,
                editable: true,
                header: {
                    left: 'month basicWeek basicDay agendaWeek agendaDay',
                    center: 'title',
                    right: 'today prev,next'
                },
                eventClick: $scope.alertEventOnClick,
                eventDrop: $scope.alertOnDrop,
                eventResize: $scope.alertOnResize
            }
        };

        $scope.eventSources = [[{ id: 1, title: 'Teste de evento', start: new Date(y, m, d), end: new Date(y, m, d) }]];

        function getCompany() {

            blockUI.start('Carregando Informações...');

            companyService.getCompanyByUser($scope.idUser).success(function (response) {

                $scope.company = response.value;
                blockUI.stop();

                if ($scope.company) {

                    if ($scope.company.ePersonType == 1) {

                        $scope.companyName = $scope.company.companyName;
                    }
                    else {

                        $scope.companyName = $scope.company.fantasyName;
                    }
                }

            }).error(function (response) {

                blockUI.stop();
            });
        }

        $scope.alertEventOnClick = function (date, jsEvent, view) {
            
            console.log('editar evento' + date.title);
        };
    }

})();


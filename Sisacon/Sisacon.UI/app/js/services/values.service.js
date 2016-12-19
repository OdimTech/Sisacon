(function () {

    angular.module('app').value('valuesService', {

        getApiUrl: 'http://localhost:15810/',
        getDefaultLogo: '../../../Content/UserImages/Default/CompanyLogo/default_logo.gif',
        abbrAutomaticCodes: {

            client: 'CLT',
            provider: 'FRN',
            material: 'MAT',
            product: 'PRD',
            estimate: 'ORC',
            request: 'PDD'
        },
        dataTableLanguage: {
                        "lengthMenu": "Exibindo _MENU_ Itens por página",
                        "zeroRecords": "Nenhum resultado encontrado",
                        "info": "Exibindo a página _PAGE_ de _PAGES_",
                        "loadingRecords": "Carregando...",
                        "infoEmpty": "Nenhum Cliente encontrado",
                        "search": "Procurar:",
                        "infoFiltered": "(filtrado de _MAX_ itens)",
                        "paginate": {
                            "first": "Primeira",
                            "last": "Última",
                            "next": "Próxima",
                            "previous": "Anterior"
                        }
                    }

    });

})();



    


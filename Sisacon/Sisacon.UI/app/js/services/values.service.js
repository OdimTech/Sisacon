(function () {

    angular.module('app').value('valuesService', {

        getApiUrl: 'http://localhost:20794/',
        getEmailPatern: /^[_a-z0-9]+(\.[_a-z0-9]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/,
        getDefaultLogo: '../../../Content/UserImages/Default/CompanyLogo/default_logo.gif',
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



    


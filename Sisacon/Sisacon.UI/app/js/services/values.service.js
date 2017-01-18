﻿(function () {

    angular.module('app').value('valuesService', {

        getApiUrl: 'http://localhost:15910/',
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
        },

        banks: [

            { id: 1, desc: '001 – Banco do Brasil S.A.' },
            { id : 2, desc: '341 – Banco Itaú S.A.'},
            { id : 3, desc: '033 – Banco Santander (Brasil) S.A.'},
            { id : 4, desc: '237 – Banco Bradesco S.A.'},
            { id : 5, desc: '745 – Banco Citibank S.A.'},
            { id : 6, desc: '399 – HSBC Bank Brasil S.A. – Banco Múltiplo'},
            { id : 7, desc: '104 – Caixa Econômica Federal'},
            { id : 8, desc: '389 – Banco Mercantil do Brasil S.A.'},
            { id: 12, desc: '748 – Banco Cooperativo Sicredi S.A.' }
        ]

    });

})();



    


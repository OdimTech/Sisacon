(function () {
    
    'use strict';

    angular
        .module('app')
        .config(function (blockUIConfig) {

            blockUIConfig.delay = 0;
            blockUIConfig.autoBlock = false;

        });

})();
﻿angular.module('app', ['app.admin', 'app.index', 'app.landingPage', 'toastr', 'blockUI'])

    .config(function (toastrConfig) {

        angular.extend(toastrConfig, {
            autoDismiss: true,
            containerId: 'toast-container',
            maxOpened: 0,    
            newestOnTop: true,
            positionClass: 'toast-top-center',
            preventDuplicates: false,
            preventOpenDuplicates: false,
            target: 'html'
        });

    }).config(function (toastrConfig) {

        angular.extend(toastrConfig, {
            allowHtml: false,
            closeButton: true,
            closeHtml: '<button>&times;</button>',
            extendedTimeOut: 1000,
            iconClasses: {
                error: 'toast-error',
                info: 'toast-info',
                success: 'toast-success',
                warning: 'toast-warning'
            },
            messageClass: 'toast-message',
            onHidden: null,
            onShown: null,
            onTap: null,
            progressBar: false,
            tapToDismiss: true,
            templates: {
                toast: 'directives/toast/toast.html',
                progressbar: 'directives/progressbar/progressbar.html'
            },
            timeOut: 7000,
            titleClass: 'toast-title',
            toastClass: 'toast'
        });

    }).config(function (blockUIConfig) {

        blockUIConfig.delay = 0;
        blockUIConfig.autoBlock = false;
        blockUIConfig.blockBrowserNavigation = true;

    });






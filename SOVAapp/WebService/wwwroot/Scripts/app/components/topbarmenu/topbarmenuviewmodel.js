define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        $("#functionalSearchBar").hide();
        var applicationName = config.applicationName;

        var currentComponent = ko.observable();

        var isMenuSelected = function(content) {
            return content && currentComponent() === content.toLowerCase();
        };
        
        var changeContent = function (content) {
            if (content !== undefined) {
                    currentComponent(content.toLowerCase());
                    ns.postbox.notify({ component: content.toLowerCase() }, "currentComponent");
            }
        };

        changeContent(config.defaultMenu);

        var searchBarContents = ko.observable("");

        ns.postbox.subscribe(function (value) {
            searchBarContents(value);
        }, "searchBarContent","topBarContext");
        var searchContentLength = ko.computed(function () {
            if (searchBarContents().length === 1) {
                $("#functionalSearchBar").slideDown("fast", function () {

                    // If the window is wider than 768px, set the functional search bar to be half the length
                    // of the primary search bar. If it's not, our bootstrap handles the fluid transistion, 
                    // so override css width styling.
                    if ($(window).width() > 768) {
                        $("#functionalSearchBar").css('width',($("#primarySearchBar").width() / 2) + 'px');
                    } else $("#functionalSearchBar").css('width', '');

                    $("#functionalSearchBar").show();
                    $("#functionalSearchBar").focus();
                });
            } else if (searchBarContents().length > 0) {
                $("#functionalSearchBar").show();
                $("#functionalSearchBar").focus();
            } else {
                $("#functionalSearchBar").slideUp("fast", function () {
                    $("#functionalSearchBar").hide();
                }); 
            }

            ns.postbox.notify(searchBarContents(), "searchBarContent");

            return searchBarContents().length;
        });

        return {
            menuElements: config.menuElements,
            currentComponent: currentComponent,
            changeContent: changeContent,
            isMenuSelected: isMenuSelected,
            searchBarContents: searchBarContents,
            searchContentLength: searchContentLength,
            applicationName: applicationName,
            defaultComponent: config.defaultMenuItem
        }
    };
});
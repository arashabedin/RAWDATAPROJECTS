define(['knockout', 'app/dataservice', 'app/config', 'jquery'], function (ko, dataservice, config, $) {
    return function (params) {
        var searchBarContents = ko.observable("");

        ns.postbox.subscribe(function (value) {
            searchBarContents(value);
        }, "searchBarContent", "searchBarContext");

        var windowHeight = ko.observable($(window).height());

        var windowWidth = ko.observable($(window).width());

        var searchContentLength = ko.computed(function () {
            if (searchBarContents().length > 0) {
                $("#primarySearchBar").slideUp("fast", function () {
                    $("#primarySearchBar").hide();
                });
            } else {
                $("#primarySearchBar").slideDown("fast", function () {
                    $("#primarySearchBar").show();
                    $("#primarySearchBar").focus();
                });
            }

            ns.postbox.notify(searchBarContents(), "searchBarContent");

            return searchBarContents().length;
        });

        // When the window is resized...
        $(window).resize(function() {
            windowWidth($(window).width());
            windowHeight($(window).height());
            searchBarPositionHandler();
        });

        // Add CSS
        $("#div").css('position', 'fixed');
        searchBarPositionHandler();
        
        function searchBarPositionHandler() {

            // Set search bar to vertical middle
            $("#div").css('top', (windowHeight() / 2) + 'px');

            // Small "hack" that handles apparent overlapping interactions in CSS-bootstrap in narrow screen resolutions.
            // 768 is the pixel cutoff where col-sm is meant to be triggered, but it doesn't when position is fixed, so...
            if (windowWidth() < 768) {
                $("#div").css('width', (windowWidth() - ((windowWidth()/12)*4)) + 'px');
            } else $("#div").css('width', '');
        };

        return {
            searchBarContents: searchBarContents,
            windowWidth: windowWidth,
            windowHeight: windowHeight,
            searchContentLength: searchContentLength
        }
    };
});
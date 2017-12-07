define(['knockout', 'app/dataservice', 'app/config'], function(ko, dataservice, config) {
    return function () {

        // Set this variable to true if you want to see window size and input length/value
        var showDebugStats = false;

        var searchdata = ko.observableArray();
        var favquestionsdata = ko.observableArray();
        var searchpage = ko.observable();
        var searchprev = ko.observable();
        var searchnext = ko.observable();
        var searchtotal = ko.observable();
        var searchString = ko.observable();

        var windowHeight = ko.observable($(window).height());

        var windowWidth = ko.observable($(window).width());

        var searchContentLength = ko.observable();

        ns.postbox.subscribe(function(data) {
          //  searchString(data);
          //  searchContentLength(data.length);
        }, "searchBarContent", "startPageContext");

        var callback = function (data) {
            searchdata(data.data);
            searchpage(data.page);
            searchprev(data.prev);
            searchnext(data.next);
            searchtotal(data.total);
          

        };
      

        ko.computed(function() {
            dataservice.search(config.searchUrl + searchString(), callback);
        });
        
        var prevClick = function () {
            dataservice.search(searchprev(), callback);
        };
        var nextClick = function() {
            dataservice.search(searchnext(), callback);
        };

        var gotoquestion = function (questionUrl, root) {
            console.log("startpage:" +searchString());
            ns.postbox.notify({ component: config.questionComponent, url: questionUrl, prevComponent: root.currentComponent(), searchBarContent: searchString() }, "currentComponent");
            ns.postbox.notify("", "searchBarContent");
        };

        $(window).resize(function() {
            windowWidth($(window).width());
            windowHeight($(window).height());
        });

        return {
            searchBarComponent: config.searchBarComponent,
            data: searchdata,
            total: searchtotal,
            pageNumber: searchpage,
            gotoquestion: gotoquestion,
            prev: searchprev,
            next: searchnext,
            prevClick: prevClick,
            nextClick: nextClick,
            searchString: searchString,
            windowWidth: windowWidth,
            windowHeight: windowHeight,
            searchContentLength: searchContentLength,
            showDebugStats: showDebugStats,
       

        }
    }
});
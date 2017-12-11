﻿define(['knockout', 'app/dataservice', 'app/config','helpers'], function (ko, dataservice, config) {
    return function () {
        var searchData = ko.observableArray();
        var searchText = ko.observable();
        var searchprev = ko.observable();
        var searchnext = ko.observable();
        var searchtotal = ko.observable();
        var searchpage = ko.observable();
        var loadingStatus = ko.observable("Please wait until the content is loaded. It might take time for the results to emerged, but we promise you intresting results...");

        var searchhistory = ko.observableArray();
        var jcloudComponent = ko.observable(config.jcloudComponent);  
        var isSearching = ko.observable(false);
        var noElements = ko.computed(function () {
            if (isSearching()){
                return searchData().length === 0;
            } 
            return false;
        });
        var callback = function (data) {
            searchData(data.data);
            searchpage(data.page);
            searchprev(data.prev);
            searchnext(data.next);
            searchtotal(data.total);
        }
        dataservice.getSearchHistory(function (data) {
            searchhistory(data.data);
        });
     

        var startSearching = function () {
            //loadingHint();//function is available in helpers
            isSearching(true);
                console.log(searchText());
            var url = config.searchUrl + searchText();
            dataservice.getSearchResult(url, callback);
            dataservice.getSearchHistory(function (data) {
            searchhistory(data.data);
            });
        }

        var searchItAgain = function (search) {
            //loadingHint();//function is available in helpers
            isSearching(true);
            console.log(search);
            var url = config.searchUrl + search;
            searchText(search);
            dataservice.getSearchResult(url, callback);
            dataservice.getSearchHistory(function (data) {
                searchhistory(data.data);
            });
             
        }
        var prevClick = function () {
            dataservice.getSearchResult(searchprev(), callback);
            console.log(searchprev());
        };
        var nextClick = function () {
            dataservice.getSearchResult(searchnext(), callback);
            console.log(searchnext());
        };
         
        var gotoquestion = function (questionUrl, root) {
            ns.postbox.notify({ component: config.questionComponent, url: questionUrl, prevComponent: root.currentComponent() }, "currentComponent");
        };
      
  
        return {
            prevClick: prevClick,
            nextClick: nextClick,
            searchData:searchData,
            searchText: searchText,
            startSearching: startSearching,
            pageNumber: searchpage ,
            prev: searchprev,
            next: searchnext,
            total: searchtotal,
            gotoquestion: gotoquestion,
            searchhistory: searchhistory,
            searchItAgain: searchItAgain,
            jcloudComponent: jcloudComponent,
            loadingStatus,
            noElements
            
        }
    }
});
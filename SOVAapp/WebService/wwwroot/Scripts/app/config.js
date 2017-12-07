define([], function () {
    var server = 'http://localhost:5001/';

    var api = "/api/";

    var applicationName = "SOVA";

    var menuElements = [
        "Search",                          // 0
        "Question",                        // 1
        "Markings"                         // 2
    ];

    var nonMenuComponentElements = [
        "Questions",                        // 0 
        "Comments",                         // 1
        "Answers",                          // 2
        "SearchBar",                        // 3
        "StartPage"                         // 4

    ];

    var searchuserid = 1;

    ns.postbox.subscribe(function(value) {
        searchuserid(value);
    }, "SearchUserId");

    return {
        // back-end routes
        HomeUrl: server + api,
        questionsUrl: server + api + menuElements[1].toLowerCase(),
        markingsUrl: server + api + "marking/",
        searchusersurl: server + api + "searchusers/",
        searchUrl: server + api + "search?searchstring=",

        
        // menu
        menuElements: menuElements,
        defaultMenuItem: nonMenuComponentElements[4].toLowerCase(),        

        // components
        menuComponent: "topbarmenu",
        searchpagesComponent: menuElements[0].toLowerCase(),
        questionsComponent: menuElements[1].toLowerCase(),
        markingsComponent: menuElements[2].toLowerCase(),
        questionComponent: nonMenuComponentElements[0].toLowerCase(),
        commentsComponent: nonMenuComponentElements[1].toLowerCase(),
        answersComponent: nonMenuComponentElements[2].toLowerCase(),
        searchBarComponent: nonMenuComponentElements[3].toLowerCase(),
        startPageComponent: nonMenuComponentElements[4].toLowerCase(),
        applicationName: applicationName
    }
});
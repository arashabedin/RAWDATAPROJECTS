define([], function () {
    var server = 'http://localhost:5001/';

    var api = "/api/";

    var applicationName = "SOVA";

    var menuElements = [
        "Search",                          // 0
        "Questions",                        // 1
        "Users",                           // 2
        "Markings",                        // 3
        "Customization"                    // 4
    ];

    var nonMenuComponentElements = [
        "Question",                        // 0 
        "Comments",                         // 1
        "Answers",                          // 2
        "SearchBar",                        // 3
        "StartPage"                         // 4

    ];


    return {
        // back-end routes
        HomeUrl: server + api,
        questionsUrl: server + api + "question",
        markingsUrl: server + api + "marking/",
        searchUrl: server + api + "search/",
        usersUrl: server + api + "user",
        customizationUrl: server + api + menuElements[4].toLowerCase(),
        searchHistoryUrl: server + api + "searchhistory",
        
        // menu
        menuElements: menuElements,
        defaultMenuItem: nonMenuComponentElements[4].toLowerCase(),        

        // components
        menuComponent: "topbarmenu",
        searchpagesComponent: menuElements[0].toLowerCase(),
        questionsComponent: menuElements[1].toLowerCase(),
        usersComponent: menuElements[2].toLowerCase(),
        markingsComponent: menuElements[3].toLowerCase(),
        customizationComponent: menuElements[4].toLowerCase(),

        questionComponent: nonMenuComponentElements[0].toLowerCase(),
        commentsComponent: nonMenuComponentElements[1].toLowerCase(),
        answersComponent: nonMenuComponentElements[2].toLowerCase(),
        searchBarComponent: nonMenuComponentElements[3].toLowerCase(),
        startPageComponent: nonMenuComponentElements[4].toLowerCase(),
        applicationName: applicationName,
      
    }
});
define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
       
        var words = ko.observableArray();
        var jCloudUrl = params.jCloudUrl;
        var callback = function (data) {
            words(data);
        }
        dataservice.getTermsByPost(jCloudUrl, callback);
        /*
    
        var words = ko.observableArray([
            { text: "Lorem", weight: 0.02 },
            { text: "Ipsum", weight: 0.05 },
            { text: "Dolor", weight: 0.04 },
            { text: "Sit", weight: 0.08 },
            { text: "Amet", weight: 0.02 },
            { text: "Consectetur", weight: 0.005 },
            { text: "Adipiscing", weight: 0.05 },
        ]);
        
        */
        return {
        
            words
            
        };
    }
});
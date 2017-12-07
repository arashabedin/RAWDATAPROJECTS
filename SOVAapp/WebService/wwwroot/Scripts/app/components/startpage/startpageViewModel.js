define(['knockout', 'app/dataservice', 'app/config'], function(ko, dataservice, config) {
    return function () {

     
        var favquestionsdata = ko.observableArray();
        var callback = function (data) {
            favquestionsdata(data.recommendedQuestions);
        };

        dataservice.getFavoriteQuestions(callback);
        var gotoquestion = function (questionUrl, root) {
            ns.postbox.notify({ component: config.questionComponent, url: questionUrl, prevComponent: root.currentComponent() }, "currentComponent");
        };

        return {
           
            gotoquestion: gotoquestion,
            favquestionsdata: favquestionsdata

        }
    }
});
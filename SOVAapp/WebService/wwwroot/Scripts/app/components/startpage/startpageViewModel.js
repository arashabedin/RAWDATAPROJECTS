define(['knockout', 'app/dataservice', 'app/config'], function(ko, dataservice, config) {
    return function () {

     
        var recommendedQuestions = ko.observableArray();
        var callback = function (data) {
            recommendedQuestions(data.recommendedQuestions);
        };

        dataservice.getFavoriteQuestions(callback);
        var gotoquestion = function (questionUrl, root) {
            ns.postbox.notify({ component: config.questionComponent, url: questionUrl, prevComponent: root.currentComponent() }, "currentComponent");
        };

        return {
           
            gotoquestion: gotoquestion,
            recommendedQuestions: recommendedQuestions

        }
    }
});
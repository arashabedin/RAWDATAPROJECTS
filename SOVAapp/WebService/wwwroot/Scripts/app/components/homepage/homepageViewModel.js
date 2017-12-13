define(['knockout', 'app/dataservice', 'app/config'], function(ko, dataservice, config) {
    return function () {

      
        var recommendedQuestions = ko.observableArray();
        var noElements = ko.computed(function () {
            return recommendedQuestions().length === 0;
        });
        var callback = function (data) {
            recommendedQuestions(data.recommendedQuestions);
        };

        dataservice.getFavoriteQuestions(callback);
        var gotoquestion = function (PostId, root) {
            ns.postbox.notify({ component: config.questionComponent, url: PostId, prevComponent: root.currentComponent() }, "currentComponent");
        };

        return {
           
            gotoquestion: gotoquestion,
            recommendedQuestions: recommendedQuestions,
            noElements

        }
    }
});
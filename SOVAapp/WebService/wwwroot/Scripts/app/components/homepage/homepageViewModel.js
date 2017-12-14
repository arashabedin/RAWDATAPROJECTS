define(['knockout', 'app/dataservice', 'app/config'], function(ko, dataservice, config) {
    return function () {
       
        var postlimit = ko.observable();
        var favortietags = ko.observableArray();
        var recommendedQuestions = ko.observableArray();
        var noElements = ko.computed(function () {
            return recommendedQuestions().length === 0;
        });


        var callback = function (data) {
            recommendedQuestions(data.recommendedQuestions);
        };


        var callback2 = function (data) {
            postlimit(data.postLimit);
            favortietags(data.favortieTags);
        }
        dataservice.getCustomefield(callback2);


        dataservice.getFavoriteQuestions(callback);
        var gotoquestion = function (PostId, root) {
            ns.postbox.notify({ component: config.questionComponent, url: PostId, prevComponent: root.currentComponent() }, "currentComponent");
        };

        return {
           
            gotoquestion: gotoquestion,
            recommendedQuestions: recommendedQuestions,
            noElements,
            postlimit: postlimit,
            favortietags: favortietags,

        }
    }
});
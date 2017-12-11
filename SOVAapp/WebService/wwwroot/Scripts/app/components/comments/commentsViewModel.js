define(['knockout', 'app/dataservice', 'app/config','helpers'], function (ko, dataservice, config) {
    return function (params) {
        var comments = ko.observableArray();
        var commentsUrl = params.commentsUrl;
        var total = ko.observable();
    
        collapseComments();//function is available in helpers

        var callback = function (data) {
            comments(data.data);
            total(data.total);
        }

        dataservice.getComments(commentsUrl, callback);

       
        return {
            comments: comments,
            total: total
        }
    };
});
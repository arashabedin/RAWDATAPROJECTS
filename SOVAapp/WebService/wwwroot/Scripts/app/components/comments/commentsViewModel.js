define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        var comments = ko.observableArray();
        var commentsUrl = params.commentsUrl;
        var total = ko.observable();
        $('.accordion-group').on('click.collapse-next.data-api', '[data-toggle=collapse-next]', function () {
            var $target = $(this).parent().next()
            $target.data('collapse') ? $target.collapse('toggle') : $target.collapse()
        });

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
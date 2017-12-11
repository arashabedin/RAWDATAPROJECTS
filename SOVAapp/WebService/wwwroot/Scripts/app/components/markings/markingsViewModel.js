define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function () {
        var questionsdata = ko.observableArray();
        var questionsprev = ko.observable();
        var questionsnext = ko.observable();
        var questionstotal = ko.observable();
        var questionspage = ko.observable();
        var markingComponent = ko.observable(config.markingComponent);
        
        var callback = function (data) {

            questionspage(data.page);
            questionsprev(data.prev);
            questionsnext(data.next);
            questionstotal(data.total);
            questionsdata(data.data);
        };

        dataservice.getMarkings(callback);

        var prevClick = function () {
            dataservice.getQuestions(questionsprev(), callback);
        };
        var nextClick = function() {
            dataservice.getQuestions(questionsnext(), callback);
        };

        var gotoMarking = function (markingUrl, root) {
            ns.postbox.notify({ component: config.markingComponent, url: markingUrl, prevComponent: root.currentComponent() }, "currentComponent");
        };
    
        return {
      
         prevClick: prevClick,
            nextClick: nextClick,
            prev: questionsprev,
            next: questionsnext,
            total: questionstotal,
            pageNumber: questionspage,
            gotoMarking: gotoMarking,
            markingComponent: markingComponent,
            data: questionsdata 
        
        }
    };
});
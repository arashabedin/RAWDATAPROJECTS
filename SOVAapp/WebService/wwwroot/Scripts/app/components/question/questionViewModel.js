define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        var question = ko.observable();
        var url = ko.observable(params.url);
        var userComponent = ko.observable(config.userComponent);
        var commentsComponent = ko.observable(config.commentsComponent);
        var answersComponent = ko.observable(config.answersComponent);
        var searchUserId = ko.observable(params.searchUserId);
        var body = ko.observable();
        var prevComponent = ko.observable(params.prevComponent);
        var annotationBody = ko.observable();
        var isNewAnnotation = ko.observable(false);

       

        document.onmouseup = function () {
            isNewAnnotation(true);
        };

        dataservice.getQuestion(url(), function (data) {
            question(data);
            body(data.body);
            url(data.url);
          
        });
   

        var goback = function () {
            ns.postbox.notify({ component: prevComponent() }, "currentComponent");
            var searchBarContent = params.searchBarContent;
            ns.postbox.notify(searchBarContent, "searchBarContent");
        }


  
        var createAnnotation = function () {
            var NewAnotationUrl = config.markingsUrl.concat(question().postId, "/annotation/text_0_0");
            console.log("Body: " + annotationBody() + " questionId: " + question().postId);
            var newAnnotation = ko.toJS({
              
                Pid: question().id,
                Text: annotationBody(),
                From: 0, //data.markingStart,
                To: 10 //data.markingEnd,
             
            });
            dataservice.postData(NewAnotationUrl, newAnnotation);
            isNewAnnotation(false);
        }
        
        ns.postbox.subscribe(function (data) {
            annotationUrl(data);
        }, "annotationUrl");

        return {
            question: question,
            body: body,
            commentsComponent: commentsComponent,
            answersComponent: answersComponent,
            url: url,
            goback: goback,
            annotationBody: annotationBody,
            isNewAnnotation: isNewAnnotation,
            createAnnotation: createAnnotation
        }
    };
});
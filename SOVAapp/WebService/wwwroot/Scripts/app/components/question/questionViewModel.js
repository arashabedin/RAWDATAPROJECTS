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

        //from and to 
       
        $('#questionContainer').click(function () {
            getSelectionPosition();
        });

        var pos1 = null;
        var pos2 = null;
        var readyToAnnotate = false;
        function getSelectionPosition() {
            var selection = window.getSelection();
            if ((pos1 == null) || (pos1 != null && pos2 != null)) {
                pos1 = selection.focusOffset;
                readyToAnnotate = false;
                isNewAnnotation(false);
                pos2 = null;
            } else {
                pos2 = selection.focusOffset;
                readyToAnnotate = true;
                isNewAnnotation(true);
            }
            console.log("from: " + pos1);
            console.log("to: " + pos2);
        }





        document.onmouseup = function () {
            if (!readyToAnnotate) {
                isNewAnnotation(false);
            }
        };

        dataservice.getQuestion(url(), function (data) {
            question(data);
            body(data.body);
            url(data.url);
          
        });
   

        var goback = function () {
            ns.postbox.notify({ component: prevComponent() }, "currentComponent");
        }


  
        var createAnnotation = function () {
            var NewAnotationUrl = config.markingsUrl.concat(question().postId, "/annotation/text_0_0");
            console.log("Body: " + annotationBody() + " questionId: " + question().postId);
            var newAnnotation = ko.toJS({
              
                Pid: question().id,
                Text: annotationBody(),
                From: pos1, //data.markingStart,
                To: pos2 //data.markingEnd,
             
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
define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        var question = ko.observable();
        var url = ko.observable();
        var userComponent = ko.observable(config.userComponent);
        var commentsComponent = ko.observable(config.commentsComponent);
        var answersComponent = ko.observable(config.answersComponent);
        var searchUserId = ko.observable(params.searchUserId);
        var body = ko.observable();
        var prevComponent = ko.observable(params.prevComponent);
        var annotationBody = ko.observable();
        var isNewAnnotation = ko.observable(false);
        var linkedPosts = ko.observableArray();
        var annotations = ko.observableArray();
        var markingStatus = ko.observable();
        var myPostId = ko.observable(params.url);
        
        
        var isMarked = ko.computed(function () {
            return markingStatus() === "Already marked";
        });
        var containsElements = ko.computed(function () {

            return linkedPosts().length !== 0;

        });
    
     
        var QuestionUrl = config.questionsUrl + "/" + params.url;

        console.log(QuestionUrl);


        var callback = function (data) {
            question(data);
            body(data.body);
            url(data.url);
            linkedPosts(data.linkedPosts);
            markingStatus(data.markThisPost);
          

           
        }
        dataservice.getQuestion(QuestionUrl, callback);
      

        var callback_annot = function (data) {
            annotations(data.markingAnnotation);
        }

        console.log(myPostId());
        var myAnnotationUrl = config.markingsUrl + myPostId(); 
       dataservice.getAnnotations(myAnnotationUrl, callback_annot);
           
        
        
        var markThis = function () {

            var AddMarkingUrl = config.markingsUrl.concat(question().postId);
            var markingObject = ko.toJS({
            });
            dataservice.postData(AddMarkingUrl, markingObject);
            markingStatus("Already marked");
            
        }
        var unMarkThis = function () {

            var deleteMarkingUrl = config.markingsUrl.concat(question().postId);
            var markingObject = ko.toJS({
            });
            dataservice.deleteData(deleteMarkingUrl, markingObject); 
            markingStatus("Deleted marking");
        }

        addAnottation = function () {
            isNewAnnotation(true);
         
        }
       
        
        var goToLinkedPost = function(url) {
            console.log("ok");
            dataservice.getQuestion(url, callback);
        }
        
        var goback = function () {
            ns.postbox.notify({ component: prevComponent() }, "currentComponent");
        }

       

        var createAnnotation = function () {
            var NewAnotationUrl = config.markingsUrl.concat(question().postId, "/annotation/text_0_0");
            console.log("Body: " + annotationBody() + " questionId: " + question().postId);
            var newAnnotation = ko.toJS({
              
                Pid: question().id,
                Text: annotationBody(),
                From: 0, //data.markingStart,
                To: 0 //data.markingEnd,
             
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
            createAnnotation: createAnnotation,
            myLinkedPosts: linkedPosts,
            goToLinkedPost: goToLinkedPost,
            markThis,
            markingStatus,
            unMarkThis,
            isMarked,
            containsElements,
            addAnottation,
            annotations,
            myPostId
       
       
       
        
        }
    };
});
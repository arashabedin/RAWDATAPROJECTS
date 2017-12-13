define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function (params) {
        var annotations = ko.observableArray();
        var url = ko.observable(params.myAnnotationUrl);
        var isThereAnnotation = ko.computed(function () {
            return annotations().length > 0;
        });
        var isNewAnnotation = ko.observable(false);
        var annotationBody = ko.observable();
        var postId = ko.observable();
        var isElements = ko.computed(function () {
          return  annotations().length > 0;
        }); 
        var callback = function (data) {
            annotations(data.markingAnnotation);
            postId(data.postId);

        }

        dataservice.getAnnotations(url(), callback);


        addAnottation = function () {
            annotationBody('');
            isNewAnnotation(true);
        }


        var createAnnotation = function () {
            var NewAnotationUrl = url().concat( "/annotation/text_0_0");
            var newAnnotation = ko.toJS({

                Pid: postId(),
                Text: annotationBody(),
                From: 0, //data.markingStart,
                To: 0 //data.markingEnd,

            });

            dataservice.postDataAndGet(NewAnotationUrl, newAnnotation, dataservice.getAnnotations(url(), callback))
      
            isNewAnnotation(false);

        }
        


        return {
            annotations,
            addAnottation,
            isNewAnnotation: isNewAnnotation,
            createAnnotation: createAnnotation,
            annotationBody: annotationBody,
            isElements

           
        }
    };
});
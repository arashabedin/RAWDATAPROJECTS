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
        var annotationsLength = ko.computed(function () {
            if (annotations().length > 0) {
                return annotations().length;
            }
            return "No";
        });
      

        var currentEdit = ko.observable('null');

        var startEditing = function (editAnnotation) {

            currentEdit(editAnnotation);
            console.log(currentEdit());
        }
   

        var callback = function (data) {
            annotations(data.markingAnnotation);
            postId(data.postId);

        }
        

        dataservice.getAnnotations(url(), callback);


        var addAnottation = function () {
            annotationBody('');
            isNewAnnotation(true);
        }
        var abortAnnotation = function () {
            annotationBody('');
            isNewAnnotation(false);
        }

        var createAnnotation = function () {
            var NewAnotationUrl = url().concat( "/annotation/text_0_0");
            var newAnnotation = ko.toJS({

                Pid: postId(),
                Text: annotationBody(),
                From: 0, //data.markingStart,
                To: 0 //data.markingEnd,

            });

            dataservice.postData(NewAnotationUrl, newAnnotation)
            setTimeout(function () { dataservice.getAnnotations(url(), callback); }, 200);
            isNewAnnotation(false);

        }

        var editAnnotation = function (myEditedText, editUrl) {
           
            var editedAnnotation = ko.toJS({

                Pid: postId(),
                Text: myEditedText,
                From: 0, //data.markingStart,
                To: 0 //data.markingEnd,

            });

            dataservice.updateData(editUrl, editedAnnotation)
            setTimeout(function () { dataservice.getAnnotations(url(), callback); }, 200);
            isNewAnnotation(false);

        }

        var deleteAnnotation = function (removeAnnotation) {
            var deleteAnotationUrl = removeAnnotation;
            var newAnnotation = ko.toJS({
            });

            dataservice.deleteData(deleteAnotationUrl, newAnnotation);
            setTimeout(function () { dataservice.getAnnotations(url(), callback); }, 200);
          //  isEdit(false);
        }

     
   

        return {
            annotations,
            addAnottation,
            isNewAnnotation: isNewAnnotation,
            createAnnotation: createAnnotation,
            annotationBody: annotationBody,
            isElements,
            annotationsLength,
            deleteAnnotation,
            currentEdit,
            startEditing,
            editAnnotation,
            abortAnnotation

           
        }
    };
});
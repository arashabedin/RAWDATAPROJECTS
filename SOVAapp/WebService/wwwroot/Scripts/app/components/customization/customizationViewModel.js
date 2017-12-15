define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function () {
       
        var postlimit = ko.observable();
        var creationdate = ko.observable();
        var favortietags = ko.observableArray();
        var newCustomeTags = ko.observable();
        var newPostlimit = ko.observable();
        var isPosting = ko.observable(false);
        var startLoading = ko.computed(function () {
            return isPosting();
        });
        var callback = function (data) {
            postlimit(data.postLimit);
            creationdate(data.creationDate);
            favortietags(data.favortieTags);
        }
      
          
        dataservice.getCustomefield(callback);
      

        var saveCustomeField = function () {
            var NewCustomeUrl = config.customizationUrl +"/"+ newPostlimit() +"_"+ encodeURIComponent(newCustomeTags());
    
            isPosting(true);
            dataservice.postData(NewCustomeUrl, {}, function (data) {
                dataservice.getCustomefield(callback);
                isPosting(false);
            });
        }

        var currentTagsToedit = function () {
            newCustomeTags(favortietags().join(','));
        }

        var currentpostLimitToedit = function () {
            newPostlimit(postlimit());
        }

      
        return {
            postlimit: postlimit,
            creationdate: creationdate,
            favortietags: favortietags,
            saveCustomeField: saveCustomeField,
            newCustomeTags: newCustomeTags,
            newPostlimit: newPostlimit,
            startLoading,
            currentTagsToedit,
            currentpostLimitToedit
        }
    };
});
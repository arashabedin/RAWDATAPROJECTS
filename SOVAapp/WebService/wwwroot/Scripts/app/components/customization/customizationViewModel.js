define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function () {
        var postlimit = ko.observable();
        var creationdate = ko.observable();
        var favortietags = ko.observableArray();
        var newCustomeTags = ko.observable();
        var newPostlimit = ko.observable();

        var callback = function (data) {
            postlimit(data.postLimit);
            creationdate(data.creationDate);
            favortietags(data.favortieTags);
        }

        dataservice.getCustomefield(callback);

      

        var saveCustomeField = function () {
            
            var NewCustomeUrl = config.customizationUrl +"/"+ newPostlimit() +"_"+newCustomeTags();
            console.log(NewCustomeUrl);
            var newCustome = ko.toJS({

                postLimit: newPostlimit(),
                
           
           
            });
            dataservice.postData(NewCustomeUrl, newCustome);
          
        }
        

        return {
            postlimit: postlimit,
            creationdate: creationdate,
            favortietags: favortietags,
            saveCustomeField: saveCustomeField,
            newCustomeTags: newCustomeTags,
            newPostlimit: newPostlimit
        }
    };
});
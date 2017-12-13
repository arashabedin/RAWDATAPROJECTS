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
            var newCustome = ko.toJS({
               // postLimit: newPostlimit(),
            });
            isPosting(true);
            dataservice.postData(NewCustomeUrl, newCustome);
          

            //postlimit(newPostlimit());
            //favortietags(newCustomeTags().split(','));
            //creationdate(new Date());

            /* The upon commented solution to show the updated results according to our new update was not ideal since the data
            may not  corrrespond to our updated Api (since http might ignore some special charachters). So we should display the
            updates from our Api. In order to do that, we need to consider the fact that the json post request's execution might
            take some time (along with the other operations in the backend). So we need to calculate a number that refers to an
            apporoximate waiting time for doing the callback (considering the amount of updating items). The number '100 ms' is
            an appropriate time for each tags to be posted, which has been calculated by observation.*/

           
            var newTagsArray = newCustomeTags().split(",");
            console.log(newTagsArray.length);
            setTimeout(function () {
                dataservice.getCustomefield(callback);
                isPosting(false);
            }, newTagsArray.length * 100);
           

         
        }

      
        return {
            postlimit: postlimit,
            creationdate: creationdate,
            favortietags: favortietags,
            saveCustomeField: saveCustomeField,
            newCustomeTags: newCustomeTags,
            newPostlimit: newPostlimit,
            startLoading
        }
    };
});
define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function () {
        
        var usersdata = ko.observableArray();
        var usersprev = ko.observable();
        var usersnext = ko.observable();
        var userstotal = ko.observable();
        var userspage = ko.observable();
        var userComponent = ko.observable(config.userComponent);

        var callback = function (data) {

            userspage(data.page);
            usersprev(data.prev);
            usersnext(data.next);
            userstotal(data.total);
            usersdata(data.data);
        };

        dataservice.getusers(callback);

        var prevClick = function () {
            dataservice.getusers(usersprev(), callback);
        };
        var nextClick = function () {
            dataservice.getusers(usersnext(), callback);
        };

        var gotouser = function (userUrl, root) {
            ns.postbox.notify({ component: config.userComponent, url: userUrl, prevComponent: root.currentComponent() }, "currentComponent");
        };



        return {
            prevClick: prevClick,
            nextClick: nextClick,
            prev: usersprev,
            next: usersnext,
            total: userstotal,
            pageNumber: userspage,
            gotouser: gotouser,
            userComponent: userComponent,
            data: usersdata


        }
    };
});

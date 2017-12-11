define(['knockout', 'app/dataservice', 'app/config'], function (ko, dataservice, config) {
    return function () {
        
        var usersdata = ko.observableArray();
        var usersprev = ko.observable();
        var usersnext = ko.observable();
        var userstotal = ko.observable();
        var userspage = ko.observable();
        var noElements = ko.computed(function () {
            return usersdata().length === 0;
        });
        var callback = function (data) {

            userspage(data.page);
            usersprev(data.prev);
            usersnext(data.next);
            userstotal(data.total);
            usersdata(data.data);
        };

        dataservice.getUsers(callback);

        var prevClick = function () {
            dataservice.getUsers(usersprev(), callback);
        };
        var nextClick = function () {
            dataservice.getUsers(usersnext(), callback);
        };



        return {
            prevClick: prevClick,
            nextClick: nextClick,
            prev: usersprev,
            next: usersnext,
            total: userstotal,
            pageNumber: userspage,
            data: usersdata,
            noElements


        }
    };
});

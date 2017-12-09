define(['knockout'], function (ko) {
    return function (params) {
        var title = ko.observable();

        var words = ko.observableArray([
            { text: "Lorem", weight: 0.02 },
            { text: "Ipsum", weight: 0.05 },
            { text: "Dolor", weight: 0.04 },
            { text: "Sit", weight: 0.08 },
            { text: "Amet", weight: 0.02 },
            { text: "Consectetur", weight: 0.005 },
            { text: "Adipiscing", weight: 0.05 },
        ]);


        return {
            title,
            words
            
        };
    }
});
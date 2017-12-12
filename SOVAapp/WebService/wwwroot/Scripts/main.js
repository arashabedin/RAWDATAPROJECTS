(function () {
    requirejs.config({
        baseUrl: 'Scripts',
        paths: {
            knockout: 'lib/knockout-3.4.0.debug',
            jquery: 'lib/jquery-2.2.3.min',
            text: 'lib/text',
            bootstrap: 'lib/bootstrap.min',
            modernizer: 'lib/modernizr-2.8.3',
            jqcloud: 'lib/jqcloud2/dist/jqcloud.min',
            d3: 'lib/d3js',
            helpers: 'lib/helpers'

        },

        // Explicitly specify that bootstrap is dependant on jquery to avoid dependency errors
        shim: {
            "bootstrap": { "deps": ['jquery'] },
            jqcloud: { deps: ['jquery'] },
            helpers: { deps: ['jquery'] }


        }
    });
})();

require(['knockout', 'jquery', 'jqcloud'], function (ko, $) {
    ko.bindingHandlers.cloud = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            // This will be called when the binding is first applied to an element
            // Set up any initial state, event handlers, etc. here
            var words = allBindings.get('cloud').words;
            if (words && ko.isObservable(words)) {
                words.subscribe(function () {
                    $(element).jQCloud('update', ko.unwrap(words));
                });
            }
        },
        update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            // This will be called once when the binding is first applied to an element,
            // and again whenever any observables/computeds that are accessed change
            // Update the DOM element based on the supplied values here.
            var words = ko.unwrap(allBindings.get('cloud').words) || [];
            $(element).jQCloud(words);
        }
    };
}); 

var ns = {

postbox: {
    subscribers: [],
    subscribe: function (callback, topic, source) {
        var found = false;
        for (var i = 0; i < this.subscribers.length; i++) {
            if (this.subscribers[i].source === source && this.subscribers[i].topic === topic) {
                found = true;
                this.subscribers[i].callback = callback;
            }
        }
        if (!found) {
            this.subscribers.push({ topic: topic, callback: callback, source: source });
        }
    },
    notify: function (value, topic) {
        for (var i = 0; i < this.subscribers.length; i++) {
            if (this.subscribers[i].topic === topic) {
                this.subscribers[i].callback(value);
            }
        }
    }
    }};

require(['knockout', 'app/viewmodel', 'app/config', 'jquery', 'bootstrap'],
    function (ko, viewmodel, config, $) {

        // Top bar menu
        ko.components.register(config.menuComponent, {
            viewModel: { require: 'app/components/topbarmenu/topbarmenuViewModel' },
            template: { require: 'text!app/components/topbarmenu/topbarmenu.html' }
        });

        // Markings
        ko.components.register(config.markingsComponent, {
            viewModel: { require: 'app/components/markings/markingsViewModel' },
            template: { require: 'text!app/components/markings/markings.html' }
        });

        // Questions
        ko.components.register(config.questionsComponent, {
            viewModel: { require: 'app/components/questions/questionsViewModel' },
            template: { require: 'text!app/components/questions/questions.html' }
        });

        // Question
        ko.components.register(config.questionComponent, {
            viewModel: { require: 'app/components/question/questionViewModel' },
            template: { require: 'text!app/components/question/question.html' }
        });



        // Comments
        ko.components.register(config.commentsComponent, {
            viewModel: { require: 'app/components/comments/commentsViewModel' },
            template: { require: 'text!app/components/comments/comments.html' }
        });

        // Answers
        ko.components.register(config.answersComponent, {
            viewModel: { require: 'app/components/answers/answersViewModel' },
            template: { require: 'text!app/components/answers/answers.html' }
        });

        // homepage page
        ko.components.register(config.homeComponent, {
            viewModel: { require: 'app/components/homepage/homepageViewModel' },
            template: { require: 'text!app/components/homepage/homepage.html' }
        });
        // Search page
        ko.components.register(config.searchpagesComponent, {
            viewModel: { require: 'app/components/searchpage/searchpageViewModel' },
            template: { require: 'text!app/components/searchpage/searchpage.html' }
        });
       // Customization page
        ko.components.register(config.customizationComponent, {
            viewModel: { require: 'app/components/customization/customizationViewModel' },
            template: { require: 'text!app/components/customization/customization.html' }
        });
        // Users page
        ko.components.register(config.usersComponent, {
            viewModel: { require: 'app/components/users/usersViewModel' },
            template: { require: 'text!app/components/users/users.html' }
        });

        // JCloud page
        ko.components.register(config.jcloudComponent, {
            viewModel: { require: 'app/components/jcloud/jcloudViewModel' },
            template: { require: 'text!app/components/jcloud/jcloud.html' }
        });
        // termnetwork page
        ko.components.register(config.concurrentsComponent, {
            viewModel: { require: 'app/components/concurrents/concurrentsViewModel' },
            template: { require: 'text!app/components/concurrents/concurrents.html' }
        });

        
        ko.applyBindings(viewmodel);
    });
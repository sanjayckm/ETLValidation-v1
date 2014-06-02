//var ETLValidateApp =

angular.module('ETLValidationApp', [
    'ngRoute',
    'ETLValidationApp.Services',
    'ETLValidationApp.controllers'
]).

config(function ($routeProvider, $locationProvider) {
    $routeProvider.

        // route for the home page
        when('/', {
            templateUrl: 'partials/testprojects.html',
            controller: 'testProjectCtrl'
        }).
        when('/Projects', {
            templateUrl: 'partials/testprojects.html',
            controller: 'testProjectCtrl'
        }).
        when('/users', {
            templateUrl: 'partials/users.html',
            controller: 'userCtrl'
        }).
        when('/ProjectConnections/:id', {
            templateUrl: 'partials/Connections.html',
            controller: 'testProjectCtrl'
        //}).
        //otherwise({
        //    redirectTo: '/'
        });

    // use the HTML5 History API
    $locationProvider.html5Mode(true);
}).

factory('testProjectData', function () {
    var user = {};
    var testProject = {};
    var testProjectConnection = {};

    return {
        setUser: function (argUser) {
            user = argUser;
        },
        getUser: function () {
            return user;
        },
        setTestProject: function (argTestProject) {
            testProject = argTestProject;
        },
        getTestProject: function () {
            return testProject;
        },
        setTestProjectConnection: function (argTestProjectConnection) {
            testProjectConnection = argTestProjectConnection;
        },
        getTestProjectConnection: function () {
            return testProjectConnection;
        }
    }
});
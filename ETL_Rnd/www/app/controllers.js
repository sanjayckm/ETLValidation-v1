var ETLAppControllers = angular.module('ETLValidationApp.controllers',
    ['ETLValidationApp.Services']
    );

ETLAppControllers.controller('userCtrl', function ($scope, userService, testProjectData) {
    $scope.activeUser = {};
    $scope.users = [];
    $scope.isAuthenticated = false
    $scope.message = "";

    $scope.loginUser = {};

    userService.query(function (response) {
        $scope.users = response;
        if ($scope.users.length > 0)
            $scope.activeUser = $scope.users[0];
    });

    $scope.verifyUser = function () {
        if (!$scope.isAuthenticated) {
            for (var i = 0; i < $scope.users.length; i++) {
                if ($scope.loginUser.UserName == $scope.users[i].UserName)
                    if ($scope.loginUser.Password == $scope.users[i].Password) {
                        $scope.isAuthenticated = true;
                        $scope.activeUser = $scope.users[i];
                        testProjectData.setUser($scope.activeUser);
                        document.location.href = "/www/";
                        //$locationProvider.href = "/www/";
                    }
                    else
                        $scope.message = "Invalid username or password !!"
                else
                    $scope.message = "Invalid username or password !!"
            }
        }
    }

});

ETLAppControllers.directive('user', function (userService) {
    return {
        restrict: "E",
        transclude: true,
        scope: {
            title: "@"
        },
        template: "<label class='user_wc'>Welcome {{ username }} | <a href='Login.aspx'>Logout</a></label>",
        link: function (scope) {
            userService.query(function (response) {
                scope.users = response;
                if (scope.users.length > 0)
                    scope.username = scope.users[0].UserName;
            });
        }
    }
});

ETLAppControllers.controller('testProjectCtrl', function ($scope, TestProject, testProjectData) {    // testProjectService) {

    $scope.testProject = new TestProject();
    $scope.testProjects = TestProject.query();

    $scope.showProjectsForm = false;
    $scope.sortProjectPredicate;

    //TestProject.query(function (response) {
    //    $scope.testProjects = response;
    //});

    $scope.CancelProjectForm = function () {
        $scope.showProjectsForm = false;
        $scope.testProject = new TestProject();
    }

    $scope.addNewProject = function () {
        $scope.showProjectsForm = true;
        $scope.testProject = new TestProject();
        $scope.projectEditing = false;
    }

    $scope.activeTestProject = function (testProject) {
        $scope.showProjectsForm = true;
        $scope.testProject = testProject;
        $scope.projectEditing = true;
    }

    $scope.saveProject = function () {
        if ($scope.testProject.TestProjectID) {
            TestProject.update({ id: $scope.testProject.TestProjectID }, $scope.testProject);
        }
        else {
            var activeUser = testProjectData.getUser();
            $scope.testProject.Status = true;
            $scope.testProject.CreatedTimestamp = Date.now();
            $scope.testProject.CreatedBy = activeUser.UserID;
            $scope.testProject.$save().then(function (response) {
                $scope.testProjects.push(response);
            });
        }
        $scope.showProjectsForm = false;
        $scope.projectEditing = false;
        $scope.testProject = new TestProject();
    }

    $scope.deleteProject = function (testProject) {
        if (!confirm('Confirm delete')) {
            return;
        }
        TestProject.delete({ id: testProject.TestProjectID }, testProject);
        $scope.testProjects = _.without($scope.testProjects, _.findWhere($scope.testProjects, { TestProjectID: testProject.TestProjectID }));
        //_.remove($scope.testProjects, testProject);
    }

    $scope.populateConnections = function (testProject) {
        testProjectData.setTestProject(testProject);
    }
});

ETLAppControllers.controller('testProjectConnectionsCtrl', function ($scope, TestProjectConnection, testProjectData) {
    //----- Connections --
    $scope.testProject = testProjectData.getTestProject();
    $scope.testProjectConnections = [];
    $scope.testProjectConnection = new TestProjectConnection();

    $scope.showConnectionForm = false;
    $scope.sortConnectionPredicate;

    testProjectConnections = TestProjectConnection.query(function (response) {
        $scope.testProjectConnections = _.where(response, { TestProjectID: $scope.testProject.TestProjectID })
    });

    $scope.activeTestProjectConnection = function (testProjectConnection) {
        $scope.showConnectionForm = true;
        $scope.testProjectConnection = testProjectConnection;
        $scope.editing = true;
    }

    $scope.Cancel = function () {
        $scope.showConnectionForm = false;
        $scope.testProjectConnection = new TestProjectConnection();
    }

    $scope.add = function () {
        $scope.showConnectionForm = true;
        $scope.testProjectConnection = new TestProjectConnection();
        $scope.testProjectConnection.TestProjectID = $scope.testProject.TestProjectID
        $scope.editing = false;
    }

    $scope.save = function () {
        if ($scope.testProjectConnection.ID) {
            TestProjectConnection.update({ id: $scope.testProjectConnection.ID }, $scope.testProjectConnection);
        }
        else {
            var activeUser = testProjectData.getUser();
            $scope.testProjectConnection.CreatedBy = activeUser.UserID;
            $scope.testProjectConnection.CreatedTimestamp = Date.now();
            $scope.testProjectConnection.$save().then(function (response) {
                $scope.testProjectConnections.push(response);
            });
        }
        $scope.showConnectionForm = false;
        $scope.editing = false;
        $scope.testProjectConnection = new TestProjectConnection();
    }

    $scope.delete = function (testProjectConnection) {
        if (!confirm('Confirm delete')) {
            return;
        }
        TestProjectConnection.delete({ id: testProjectConnection.ID }, testProjectConnection);
        $scope.testProjectConnections = _.without($scope.testProjectConnections, _.findWhere($scope.testProjectConnections, { ID: testProjectConnection.ID }));
    }

});
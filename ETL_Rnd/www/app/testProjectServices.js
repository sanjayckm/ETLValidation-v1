ETLValidationServices.provider('TestProject', function () {
    this.$get = ['$resource', function ($resource) {
        var TestProject = $resource('/api/testProjects/:id', {}, {
            update: {
                method: 'PUT',
                params: { TestProjectID: '@id' }
            },
            delete: {
                method: 'DELETE',
                params: { TestProjectID: '@id' }
            }
        })
        return TestProject;
    }];
});

//ETLValidationServices.factory('testProjectService', function ($resource) {
//    return $resource('/api/testProjects', {}, {
//        query: { method: 'GET', isArray: true },
//        create: { method: 'POST' }
//    })
//});
//ETLValidationServices.factory('testProjectService', function ($resource) {
//    return $resource('/api/testProjects/:id', {}, {
//        show: { method: 'GET' },
//        update: { method: 'PUT', params: { TestProjectID: '@id' } },
//        delete: { method: 'DELETE', params: { TestProjectID: '@id' } }
//    })
//});
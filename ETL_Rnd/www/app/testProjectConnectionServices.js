ETLValidationServices.provider('TestProjectConnection', function () {
    this.$get = ['$resource', function ($resource) {
        var TestProject = $resource('/api/testProjectConnections/:id', {}, {
            get: {
                method: 'GET',
                data: { isPrimary: false }
            },
            update: {
                method: 'PUT',
                params: { ID: '@id' }
            },
            delete: {
                method: 'DELETE',
                params: { ID: '@id' }
            }
        })
        return TestProject;
    }];
});
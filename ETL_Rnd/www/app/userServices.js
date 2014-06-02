ETLValidationServices.factory('userService', function ($resource) {
    return $resource('/api/users', {}, {
        query: { method: 'GET', isArray: true },
        create: { method: 'POST' }
    })
});

ETLValidationServices.factory('userService', function ($resource) {
    return $resource('/api/users/:id', {}, {
        show: { method: 'GET' },
        update: { method: 'PUT', params: { userId: '@id' } },
        delete: { method: 'DELETE', params: { userId: '@id' } }
    })
});


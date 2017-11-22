UserManagerApp
    .factory('statusFactory', function ($http) {
        var GetStatuses = function () {
            return $http.get('/Api/Status/')
        }
        return { getStatuses: GetStatuses }
    })
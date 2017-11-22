UserManagerApp
    .factory('roleFactory', function ($http) {
        var GetRoles = function () {
            return $http.get('/Api/Role/')
        }
        return { getRoles: GetRoles }
    })
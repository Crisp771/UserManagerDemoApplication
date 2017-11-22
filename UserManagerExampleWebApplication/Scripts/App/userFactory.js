UserManagerApp
    .factory('userFactory', function ($http) {
        var GetUsers = function () {
            return $http.get('/Api/User/')
        }

        var GetUser = function (id) {
            return $http.get('/Api/User/' + id);
        }

        var AddUser = function (user) {
            return $http.post('/Api/User/', user);
        }

        var UpdateUser = function (user) {
            return $http.put('/Api/User/', user);
        }

        var DeleteUser = function (id) {
            return $http.delete('/Api/User/' + id);
        }

        return { getUsers: GetUsers ,getUser: GetUser ,addUser: AddUser, updateUser: UpdateUser, deleteUser: DeleteUser }
    })
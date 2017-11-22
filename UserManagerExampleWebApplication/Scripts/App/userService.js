UserManagerApp.service('userService', ['$http', '$rootScope', '$uibModal', function ($http, $rootScope, $uibModal) {

    this.editRow = function (grid, row) {
        $uibModal.open({
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: 'Scripts/App/Partials/user.html',
            controller: ['$http', '$uibModalInstance', 'roleFactory', 'statusFactory', 'userFactory', 'grid', 'row', RowEditCtrl],
            controllerAs: 'vm',
            resolve: {
                grid: function () {
                    return grid;
                },
                row: function () {
                    return row;
                }
            }
        });
    };
}]);

function RowEditCtrl($http, $uibModalInstance, roleFactory, statusFactory, userFactory, grid, row) {
    var vm = this;
    vm.entity = angular.copy(row.entity);
    vm.dialogTitle = row.entity.UserId > 0 ? "Edit User" : "Add New User";

    var rolesPromise = roleFactory.getRoles();
    rolesPromise.then(function(result) {
        vm.roles = result.data;
    });

    var statusPromise = statusFactory.getStatuses();
    statusPromise.then(function(result) {
        vm.statuses = result.data;
    });

    vm.ok = function () {
        if (row.entity.UserId == '0') {
            userFactory.addUser(vm.entity).then(
                function (response) {
                    grid.data.push(response.data);
                });
        } else {
            //vm.entity.RoleDisplay = vm.roles[vm.entity.RoleId - 1].Name;
            //vm.entity.StatusDisplay = vm.statuses[vm.entity.RoleId - 1].Name;
            row.entity = angular.extend(row.entity, vm.entity);
            var index = grid.appScope.userGrid.data.indexOf(row.entity);
            grid.appScope.userGrid.data.splice(index, 1);
            userFactory.updateUser(row.entity)
                .then(function (response) {
                    grid.appScope.userGrid.data.push(response.data);
                },
                      function(response) { alert('Cannot edit row (error in console)'); console.dir(response);});
        }
        $uibModalInstance.close(row.entity);
    };

    vm.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    vm.remove = function () {
        console.dir(row)
        if (row.entity.id != '0') {
            row.entity = angular.extend(row.entity, vm.entity);
            var index = grid.appScope.vm.userGrid.data.indexOf(row.entity);
            grid.appScope.vm.userGrid.data.splice(index, 1);
            userFactory.deleteUser(row.entity.UserId);
        }
        $uibModalInstance.close(row.entity);
    }

}
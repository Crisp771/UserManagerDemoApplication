UserManagerApp.controller('modalController', ['$uibModalInstance', 'roleFactory', 'statusFactory', function ($uibModalInstance, roleFactory, statusFactory, user) {
    var $ctrl = this;

    $ctrl.user = {};

    $ctrl.dialogTitle = 'User Editor';
    $ctrl.selectedRole = 1;
    $ctrl.selectedStatus = 1;

    

    var rolesPromise = roleFactory.getRoles();
    rolesPromise.then(function(result) {
        $ctrl.roles = result.data;
    });

    var statusPromise = statusFactory.getStatuses();
    statusPromise.then(function(result) {
        $ctrl.statuses = result.data;
    });

    $ctrl.ok = function () {
        $uibModalInstance.close($ctrl.user);
    };

    $ctrl.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);
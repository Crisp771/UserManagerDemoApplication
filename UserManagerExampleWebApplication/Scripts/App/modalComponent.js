UserManagerApp.component('modalComponent', {
    templateUrl: 'user.html',
    bindings: {
        resolve: '<',
        close: '&',
        dismiss: '&'
    },
    controller: function () {
        var vm = this;

        vm.$onInit = function () {
            vm.user = vm.resolve.user;
        };

        vm.ok = function () {
            vm.close({$value: vm.user});
        };

        vm.cancel = function () {
            vm.dismiss({$value: 'cancel'});
        };
    }
});
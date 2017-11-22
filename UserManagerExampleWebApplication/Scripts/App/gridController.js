UserManagerApp.controller('gridController', ['$scope', '$http', '$uibModal', 'uiGridConstants', 'userFactory', 'userService', function ($scope, $http, $uibModal, uiGridConstants, userFactory, userService) {
    var vm = this;

    $scope.userGrid = {
        enableRowSelection: true,
        enableRowHeaderSelection: false,
        multiSelect: false,
        enableSorting: true,
        enableFiltering: true,
        enableGridMenu: true,
        paginationPageSize: 20,
        enablePaginationControls: false,
        paginationCurrentPage: 1,
        onRegisterApi: registerGridApi,
        totalItems: 0,
        rowTemplate: '<div ng-class="{\'redRow\':row.entity.StatusId===3}" <div ng-repeat="col in colContainer.renderedColumns track by col.colDef.name"  class="ui-grid-cell" ui-grid-cell></div></div>',
        columnDefs: [
          {
              name: 'UserId',
              enableSorting: true,
              type: 'number',
              enableCellEdit: false,
              width: 60,
              sort: {
                  direction: uiGridConstants.ASC,
                  priority: 1,
              }
          },
          {
              name: 'Name',
              enableSorting: true,
              enableCellEdit: false
          },
          {
              name: 'RoleDisplay',
              enableSorting: true,
              enableCellEdit: false
          },
          {
              name: 'UpdatedAt',
              enableSorting: true,
              enableCellEdit: false,
              type: 'date',
              cellFilter: 'date:\'d/M/yyyy HH:mm\''
          },
          {
              name: 'StatusDisplay',
              enableSorting: true,
              enableCellEdit: false
          },
          {
              name: 'actions',
              displayName: 'Actions',
              enableCellEdit: false,
              enableSorting: false,
              enableFiltering:false,
              width: 150,
              cellTemplate: '../Scripts/App/Partials/actions.html'
          }
        ]
    }
    $scope.userGrid.data = [];

    function registerGridApi(gridApi) {
        $scope.gridApi = gridApi;
    }

    var getUserData = function () {
        var userPromise = userFactory.getUsers();

        userPromise.then(function (result) {
            $scope.userGrid.data = result.data;
            $scope.userGrid.totalItems = result.data.length;
        });
    };

    getUserData();

    $scope.editRow = userService.editRow;

    $scope.addRow = function () {
        var newUser = {
            "UserId": 0,
            "Name": "",
            "RoleId": 1,
            "RoleDisplay": "",
            "StatusId": 1,
            "StatusDisplay": "",
            "UpdatedAt":""
        };
        var rowTmp = {};
        rowTmp.entity = newUser;
        this.editRow($scope.userGrid, rowTmp);
    };

    $scope.deleteRow = function (grid, row) {
        var index = grid.appScope.userGrid.data.indexOf(row.entity);
        grid.appScope.userGrid.data.splice(index, 1);
        userFactory.deleteUser(row.entity.UserId);
    };
}]);

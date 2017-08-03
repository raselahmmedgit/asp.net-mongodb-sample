var angularModule = angular.module("App", []);

angularModule.service('ProductService', ['$http', function ($http) {

    var productService = this;

    var urlBase = '/Product/';

    productService.GetList = function () {
        return $http.get(urlBase + 'GetListAjax');
    };

    productService.GetById = function (id) {
        return $http.get(urlBase + 'GetByIdAjax/?id=' + id);
    };

    productService.Save = function (product) {
        return $http.post(urlBase + 'SaveAjax', { product: product });
    };

    productService.Delete = function (id) {
        return $http.post(urlBase + 'DeleteAjax/?id=' + id);
    };

}]);

angularModule.controller('ProductController', ['ProductService', '$scope', function (ProductService, $scope) {

    var productController = this;
    productController.Current = false;
    productController.Add = false;
    productController.Edit = false;

    $scope.ProductForm = false;
    $scope.Products = [];
    $scope.Product = {};

    getList();

    function getList() {
        ProductService.GetList().then(function (dataList) {
            $scope.Products = dataList;
        }, function (error) {
            App.toastrNotifier(error, false);
        });
    };

    $scope.Add = function () {
        initialAdd();
    };

    function initialAdd() {
        resetProductForm();
        productController.Add = true;
        $scope.Action = "Add";
        $scope.ProductForm = true;
    }

    $scope.Edit = function (index) {
        initialEdit();
        productController.Current = index;
        //angular.copy($scope.Products[index], Current);
        angular.copy($scope.Products[index], $scope.Product);
    };

    function initialEdit() {
        productController.Edit = true;
        $scope.Action = "Edit";
        $scope.ProductForm = true;
    }

    $scope.Delete = function (index) {
        var id = $scope.Products[index].Id;

        bootbox.confirm("Do you want to delete this ?", function (isConfirm) {
            if (isConfirm) {
                ProductService.Delete(id).success(function (data) {

                    //$scope.Products.splice(index);

                    if (data.IsSuccess) {
                        App.toastrNotifier(data.SuccessMessage, true);
                    } else {
                        App.toastrNotifier(data.ErrorMessage, false);
                    }

                }).error(function (error) {
                    App.toastrNotifier(error, false);
                });

                $scope.Refresh();
            }
        });


    };

    $scope.Save = function () {

        ProductService.Save($scope.Product).then(function (data) {

            if (data.IsSuccess) {

                $scope.Reset();

                App.toastrNotifier(data.SuccessMessage, true);

                //if (productController.Edit) {
                //    $scope.Products[productController.Current] = $scope.Product;
                //} else {
                //    $scope.Products.push($scope.Product);
                //}

            } else {
                App.toastrNotifier(data.ErrorMessage, false);
            }

        }, function (error) {
            App.toastrNotifier(error, false);
        });

        $scope.Refresh();
    };

    $scope.Cancel = function () {
        $scope.Reset();
    };

    $scope.Reset = function () {
        resetProductForm();
        $scope.ProductForm = false;
    };

    $scope.Refresh = function () {
        getList();
    };

    function resetProductForm() {
        $scope.Product = {};
    }

}]);
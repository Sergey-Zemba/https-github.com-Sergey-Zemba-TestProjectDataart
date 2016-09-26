angular.module("newsApp").controller("newsController",
    function ($scope, $http, $cookies) {
        $scope.news = {};
        $scope.currentPage = 1;
        //if ($cookies.get("currentPage")) {
        //    $scope.currentPage = parseInt($cookies.get("currentPage"));
        //    $cookies.remove("currentPage");
        //}
        $scope.totalItems = {};
        $scope.maxSize = 5;
        $scope.setLane = function (data) {
            $scope.totalItems = data.articlesNum;
            $scope.news = {
                articles: data.articles
            };
            $scope.isAuthenticated = data.isAuthenticated;
            $(document).scrollTop(0);
        };
        $scope.serverPath = document.location.pathname;
        if (!$scope.serverPath.endsWith("/")) {
            $scope.serverPath += "/";
        }
        $scope.getArticles = function (page, callback) {
            $http.get(page).success(function (data) {
                callback(data);
            });
        }
        $scope.delete = function(id) {
            $http.get($scope.serverPath + 'news/delete/' + id).success(function (data) {
                $scope.getArticles($scope.currentPage, $scope.setLane);
            });
        }
        $scope.getArticles($scope.currentPage, $scope.setLane);
    });

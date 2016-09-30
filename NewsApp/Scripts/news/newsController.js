angular.module("newsApp").controller("newsController",
    function ($scope, $http, $cookies, $window) {
        $scope.news = {};
        $scope.currentPage = 1;
        $scope.totalItems = {};
        $scope.maxSize = 5;
        $scope.getArticlesUrl = {};
        $scope.setLane = function (data, page) {
            $scope.totalItems = data.articlesNum;
            $scope.news = {
                articles: data.articles
            };
            $scope.isAuthenticated = data.isAuthenticated;
            $(document).scrollTop(0);
            $scope.currentPage = page;
        };
        $scope.getArticles = function (page, callback) {
            var goToPage = parseInt($cookies.get("currentPage"));
            if (goToPage) {
                page = goToPage;
                $cookies.remove("currentPage");
            }
            $http.get(getArticlesUrl + "/" + page).success(function (data) {
                callback(data, page);
            });
        }
        $scope.delete = function (id) {
            $http.get(deleteUrl + '/' + id).success(function (data) {
                $scope.getArticles($scope.currentPage, $scope.setLane);
            });
        }
        $scope.savePage = function () {
            $cookies.put("currentPage", $scope.currentPage);
        }
        $scope.getArticles($scope.currentPage, $scope.setLane);
    });

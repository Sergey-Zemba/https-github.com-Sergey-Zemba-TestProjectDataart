angular.module("newsApp").controller("newsController",
    function ($scope, $http) {

        $scope.news = {};
        $scope.currentPage = 1;
        $scope.totalItems = {};
        $scope.maxSize = 5;
        $scope.setLane = function (data) {
            $scope.totalItems = data.pages * 10;
            $.each(data.articles,
                function (index, value) {
                    value.CreationDate = value.CreationDate;
                });
            $scope.news = {
                articles: data.articles
            };
        };
        $scope.getArticles = function (page, callback) {
            $http.get('/article/getarticles/' + page).success(function (data) {
                callback(data);
            });
        }
        $scope.getArticles(1, $scope.setLane);
    });

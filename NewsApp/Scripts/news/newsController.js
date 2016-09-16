angular.module("newsApp").controller("newsController",
    function ($scope, $http) {

        $scope.news = {};
        $scope.currentPage = 1;
        $scope.totalItems = {};
        $scope.maxSize = 5;
        $scope.setLane = function (data) {
            $scope.totalItems = data.articlesNum;
            $scope.news = {
                articles: data.articles
            };
            $(document).scrollTop(0);
        };
        $scope.getArticles = function (page, callback) {
            $http.get('/news/getarticles/' + page).success(function (data) {
                callback(data);
            });
        }
        $scope.delete = function(id) {
            $http.get('/news/delete/' + id).success(function (data) {
                $scope.getArticles($scope.currentPage, $scope.setLane);
            });
        }
        $scope.getArticles($scope.currentPage, $scope.setLane);
    });

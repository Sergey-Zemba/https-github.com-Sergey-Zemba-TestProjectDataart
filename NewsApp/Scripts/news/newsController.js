newsApp.controller("NewsController", ['$scope', 'newsService', 'pageService', function ($scope, newsService, pageService) {
    $scope.currentPage = 1;
    $scope.maxSize = 5;
    $scope.getArticles = function (page) {
        page = pageService.getPage(page);
        newsService.getContent(getArticlesUrl, page).then(function (result) {
            $scope.totalItems = result.articlesNum;
            $scope.news = {
                articles: result.articles
            };
            $scope.isAuthenticated = result.isAuthenticated;
            $scope.currentPage = page;
        });
        $(document).scrollTop(0);
    }
    $scope.delete = function (id) {
        newsService.deleteArticle(deleteUrl, id)
            .then(function(result) {
                $scope.getArticles($scope.currentPage);
            });
    }
    $scope.savePage = function () {
        pageService.savePage($scope.currentPage);
    }
    $scope.getArticles($scope.currentPage);
}]);

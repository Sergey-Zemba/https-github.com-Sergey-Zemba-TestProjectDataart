newsApp.service("newsService",
    [
        '$http', function ($http) {
            var getContent = function (url, page) {
                return $http.get(url + "/" + page)
                    .then(function (result) {
                        return result.data;
                    });
            }

            var deleteArticle = function (url, id) {
                return $http.get(url + '/' + id)
                    .then(function (result) {
                        return result.data;
                    });
            }

            return {
                getContent: getContent,
                deleteArticle: deleteArticle
            };
        }
    ]);
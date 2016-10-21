newsApp.service('pageService',
[
    '$cookies', function ($cookies) {
        var getPage = function (page) {
            var goToPage = parseInt($cookies.get("currentPage"));
            if (goToPage) {
                page = goToPage;
                $cookies.remove("currentPage", { path: '/NewsApp' });
            }
            return page;
        };

        var savePage = function (page) {
            $cookies.put("currentPage", page);
        };
        return {
            getPage: getPage,
            savePage: savePage
        };
    }
]);
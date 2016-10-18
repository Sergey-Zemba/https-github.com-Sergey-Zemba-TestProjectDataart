using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFDataService.Entities;

namespace WCFDataService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INewsService" in both code and config file together.
    [ServiceContract]
    public interface INewsService
    {
        [OperationContract]
        [WebGet]
        IEnumerable<Article> GetArticles(int page, out int numberOfItems);

        [OperationContract]
        [WebGet(UriTemplate = "articles/{id}")]
        Article GetArticle(int id);

        [OperationContract]
        Article CreateArticle(Article item);

        [OperationContract]
        Article UpdateArticle(Article item);

        [OperationContract]
        int DeleteArticle(int id);
    }
}

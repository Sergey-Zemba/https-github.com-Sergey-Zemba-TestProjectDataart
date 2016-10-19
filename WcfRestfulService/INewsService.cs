using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfRestfulService.Entities;

namespace WcfRestfulService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INewsService" in both code and config file together.
    [ServiceContract]
    public interface INewsService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/articles?page={page}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        IEnumerable<Article> GetArticles(string page, out int numberOfItems);

        [OperationContract]
        [WebGet(UriTemplate = "/articles/{id}", ResponseFormat = WebMessageFormat.Json)]
        Article GetArticle(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/articles/new", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Article CreateArticle(Article item);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/articles/edit", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Article UpdateArticle(Article item);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/articles/delete/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int DeleteArticle(string id);
    }
}

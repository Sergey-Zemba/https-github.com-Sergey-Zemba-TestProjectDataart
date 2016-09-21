using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFDataService.Entities
{
    [DataContract]
    public class Article
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string ShortDescription { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public string ImageName { get; set; }

        [DataMember]
        public string CreationDate { get; set; }
    }
}
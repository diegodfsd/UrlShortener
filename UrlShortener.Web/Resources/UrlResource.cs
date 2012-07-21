using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace UrlShortener.Web.Resources
{
    [DataContract]
    public class UrlResource
    {
        [DataMember(Name="source")]
        public string Source { get; set; }

        [DataMember(Name = "short")]
        public string Short { get; set; }
    }
}
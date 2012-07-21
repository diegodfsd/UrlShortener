using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrlShortener.Web.Helpers;

namespace UrlShortener.Web.Model
{
    public class Url
    {
        public Guid Id { get; protected set; }
        public string Source { get; protected set; }
        public string Short { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        private Url()
        {
            Id = Guid.NewGuid();
        }

        public Url(string souce)
            : this()
        {
            Source = souce;
            Short = Shortener.Generate(DateTime.Now.Ticks);
            CreatedAt = DateTime.Now;
        }

        public override int GetHashCode()
        {
            return Short.GetHashCode();
        }

        public override bool Equals(object other)
        {
            var otherUrl = other as Url;

            return (otherUrl == null) ?
                false : otherUrl.Short == this.Short;
        }
    }
}
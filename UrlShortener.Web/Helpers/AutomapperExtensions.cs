using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace UrlShortener.Web.Helpers
{
    public static class AutomapperExtensions
    {
        public static TResult Map<TResult>(this object source)
        {
            if(Mapper.FindTypeMapFor(source.GetType(), typeof(TResult)) == null)
            {
                Mapper.CreateMap(source.GetType(), typeof(TResult));
            }

            return (TResult)Mapper.Map(source, source.GetType(), typeof(TResult));
        }
    }
}
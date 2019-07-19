//using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        //public EntityMapper()
        //{
        //    //Mapper.CreateMap<Models.Article, Article>();
        //    //Mapper.CreateMap<Article, Models.Article>();
        //}
        //public TDestination Translate(TSource obj)
        //{
        //    return Mapper.Map<TDestination>(obj);
        //}
    }
}
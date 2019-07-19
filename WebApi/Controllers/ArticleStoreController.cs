using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    public class ArticleStoreController : ApiController
    {
        // GET: GetAllArticles
        [HttpGet]
        public JsonResult<List<Models.Article>> GetAllArticles()
        {
            List<Models.Article> mArtLst = new List<Models.Article>();
            List<DataAccessLayer.Article> lst = DAL.GetAllArticles();

            foreach (DataAccessLayer.Article item in lst)
            {
                Models.Article mArt = new Models.Article();
                mArt.ArticleId = item.ArticleId;
                mArt.ArticleName = item.ArticleName;
                mArt.ArticleContent = item.ArticleContent;
                mArtLst.Add(mArt);
            }

            //EntityMapper<DataAccessLayer.Article, Models.Article> mapObj = new EntityMapper<DataAccessLayer.Article, Models.Article>();
            //List<DataAccessLayer.Article> prodList = DAL.GetAllArticles();
            //List<Models.Article> Articles = new List<Models.Article>();
            //foreach (var item in prodList)
            //{
            //    Articles.Add(mapObj.Translate(item));
            //}
            return Json(mArtLst);
        }
        [HttpGet]
        public JsonResult<Models.Article> GetArticle(int id)
        {
            DataAccessLayer.Article article = DAL.GetArticle(id);


            //EntityMapper<DataAccessLayer.Article, Models.Article> mapObj = new EntityMapper<DataAccessLayer.Article, Models.Article>();
            //DataAccessLayer.Article dalArticle = DAL.GetArticle(id);
            Models.Article Articles = new Models.Article();
            //Articles = mapObj.Translate(dalArticle);
            //return Json<Models.Article>(Articles);
            Articles.ArticleName = article.ArticleName;
            Articles.ArticleContent = article.ArticleContent;
            return Json(Articles);
        }
        [HttpPost]
        public bool InsertArticle(Models.Article Article)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                //EntityMapper<Models.Article, DataAccessLayer.Article> mapObj = new EntityMapper<Models.Article, DataAccessLayer.Article>();
                DataAccessLayer.Article ArticleObj = new DataAccessLayer.Article();
                ArticleObj.ArticleName = Article.ArticleName;
                ArticleObj.ArticleContent = Article.ArticleContent;

                //ArticleObj = mapObj.Translate(Article);
                status = DAL.InsertArticle(ArticleObj);
            }
            return status;

        }
        [HttpPut]
        public bool UpdateArticle(Models.Article Article)
        {
            //EntityMapper<Models.Article, DataAccessLayer.Article> mapObj = new EntityMapper<Models.Article, DataAccessLayer.Article>();
            DataAccessLayer.Article ArticleObj = new DataAccessLayer.Article();
            ArticleObj.ArticleId = Article.ArticleId;
            ArticleObj.ArticleName = Article.ArticleName;
            ArticleObj.ArticleContent = Article.ArticleContent;

            //ArticleObj = mapObj.Translate(Article);
            var status = DAL.UpdateArticle(ArticleObj);
            return status;

        }
        [HttpDelete]
        public bool DeleteArticle(int id)
        {
            var status = DAL.DeleteArticle(id);
            return status;
        }
    }
}

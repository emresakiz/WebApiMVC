using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article  
        public ActionResult GetAllArticles()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/articlestore/getallArticles");
                response.EnsureSuccessStatusCode();
                List<Article> Articles = response.Content.ReadAsAsync<List<Article>>().Result;
                ViewBag.Title = "All Articles";
                return View(Articles);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]  
        public ActionResult EditArticle(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/articlestore/GetArticle?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Article Articles = response.Content.ReadAsAsync<Article>().Result;
            ViewBag.Title = "All Articles";
            return View(Articles);
        }
        //[HttpPost]  
        public ActionResult Update(Article Article)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/articlestore/UpdateArticle", Article);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllArticles");
        }
        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/articlestore/GetArticle?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Article Articles = response.Content.ReadAsAsync<Article>().Result;
            ViewBag.Title = "All Articles";
            return View(Articles);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Article Article)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/articlestore/InsertArticle", Article);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllArticles");
        }
        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/articlestore/DeleteArticle?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllArticles");
        }
    }
}
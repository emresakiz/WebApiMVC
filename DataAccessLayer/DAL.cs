using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public static class DAL
    {
        static ArticleWebApiEntities DbContext;
        static DAL()
        {
            DbContext = new ArticleWebApiEntities();
        }
        public static List<Article> GetAllArticles()
        {
            return DbContext.Article.ToList();
        }
        public static Article GetArticle(int ArticleId)
        {
            return DbContext.Article.Where(p => p.ArticleId == ArticleId).FirstOrDefault();
        }
        public static bool InsertArticle(Article ArticleItem)
        {
            bool status;
            try
            {
                DbContext.Article.Add(ArticleItem);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool UpdateArticle(Article ArticleItem)
        {
            bool status;
            try
            {
                Article artItem = DbContext.Article.Where(p => p.ArticleId == ArticleItem.ArticleId).FirstOrDefault();
                if (artItem != null)
                {
                    artItem.ArticleName = ArticleItem.ArticleName;
                    artItem.ArticleContent = ArticleItem.ArticleContent;
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteArticle(int id)
        {
            bool status;
            try
            {
                Article artItem = DbContext.Article.Where(p => p.ArticleId == id).FirstOrDefault();
                if (artItem != null)
                {
                    DbContext.Article.Remove(artItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}

using app_news_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_news_api.Data.Repositories
{
    public class NewsRepository : INewsRepository
    {
        public Task<bool> AddNews(News news)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteNews(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<News>> GetAllNews()
        {
            throw new NotImplementedException();
        }

        public Task<News> GetNewsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateNews(News news)
        {
            throw new NotImplementedException();
        }
    }
}

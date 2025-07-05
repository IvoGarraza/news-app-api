using app_news_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_news_api.Data.Repositories
{   
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetAllNews();
        Task<News> GetNewsById(int id);
        Task<bool> AddNews(News news);
        Task<bool> UpdateNews(News news);
        Task<bool> DeleteNews(int id);

    }
}

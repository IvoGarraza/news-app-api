using app_news_api.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_news_api.Data.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private PostgreSQLConfiguration _connectionString;

        public NewsRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> AddNews(News news)
        {
            var db = dbConnection();

            var sql = @"
                         INSERT INTO PUBLIC.""News"" (title, subtitle, description, img, date, author) 
                         VALUES (@Title, @Subtitle, @Description, @Img, @Date, @Author)
                        ";

            var result = await db.ExecuteAsync(sql, new { news.Title, news.Subtitle, news.Description, news.Img, news.Date, news.Author });

            return result > 0;
        }

        public async Task<bool> DeleteNews(int id)
        {
            var db = dbConnection();

            var sql = @"
                           DELETE FROM PUBLIC.""News"" 
                           WHERE id = @Id 
                           ";

            var result = await db.ExecuteAsync(sql, new { Id = id });

            return result > 0;
        }

        public async Task<IEnumerable<News>> GetAllNews()
        {
                var db = dbConnection();
                
                var sql = @"
                            SELECT id, title, subtitle, description, img, date, author 
                           FROM public.""News""
                           ";
                return await db.QueryAsync<News>(sql, new { });
        }

        public async Task<News> GetNewsById(int id)
        {
            var db = dbConnection();

            var sql = @"
                         SELECT id, title, subtitle, description, img, date, author 
                         FROM public.""News""
                         WHERE id = @Id
                           ";

            return await db.QueryFirstOrDefaultAsync<News>(sql, new { Id = id });
        }

        public async Task<bool> UpdateNews(News news)
        {
            var db = dbConnection();

            var sql = @"
                         UPDATE PUBLIC.""News"" 
                         SET title = @Title, 
                             subtitle = @Subtitle, 
                             description = @Description, 
                             img = @Img, 
                             date = @Date, 
                             author = @Author
                         WHERE id = @Id
                        ";

            var result = await db.ExecuteAsync(sql, new { news.Title, news.Subtitle, news.Description, news.Img, news.Date, news.Author, news.Id });

            return result > 0;
        }
    }
}
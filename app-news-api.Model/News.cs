using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_news_api.Model
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}

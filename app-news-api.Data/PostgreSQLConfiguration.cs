﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_news_api.Data
{
    public class PostgreSQLConfiguration
    {
        public string ConnectionString { get; set; }

        public PostgreSQLConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}

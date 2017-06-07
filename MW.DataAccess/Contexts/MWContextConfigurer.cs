using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MW.DataAccess.Contexts
{
    public static class MWContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MwSqlContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }
    }
}

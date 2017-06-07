using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace MW.DataAccess.Contexts
{
    public class MwContextFactory:IDbContextFactory<MwSqlContext>
    {
        private IConfigurationRoot _config;
        public MwSqlContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<MwSqlContext>();

            MWContextConfigurer.Configure(builder, "Server=52.62.180.87,1984;Database=MW;Uid=sa;Password=Pa$$w0rd;");

            return new MwSqlContext(builder.Options);
        }
    }
}

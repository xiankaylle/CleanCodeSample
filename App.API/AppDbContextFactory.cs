﻿using App.Infrastructure.DatbaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace App.API
{
  
    //public class AppDbContextFactory :
    //    IDesignTimeDbContextFactory<AppDbContext>
    //{
    //    public AppDbContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();

    //        var builder = new DbContextOptionsBuilder<AppDbContext>();

    //        var connectionString = configuration.GetConnectionString("DefaultConnection");

    //        builder.UseSqlServer(connectionString);

    //        return new AppDbContext(builder.Options);
    //    }
    //}
}

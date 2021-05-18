﻿using Microsoft.EntityFrameworkCore;
using Rest.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Api.Dal.EntityFramework
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories{ get; set; }


    }
}
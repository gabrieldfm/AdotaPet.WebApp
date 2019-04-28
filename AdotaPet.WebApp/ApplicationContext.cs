using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdotaPet.WebApp
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-5P677KP4;Initial Catalog=Db_AdotaPet;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
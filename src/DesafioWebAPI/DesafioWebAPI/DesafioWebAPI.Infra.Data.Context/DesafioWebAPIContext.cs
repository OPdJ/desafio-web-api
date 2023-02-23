using DesafioWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebAPI.Infra.Data.Context
{
    public class DesafioWebAPIContext : DbContext
    {
        public DesafioWebAPIContext()
        {
        }

        public DesafioWebAPIContext(DbContextOptions<DesafioWebAPIContext> dbContext)
            : base(dbContext)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
    }
}

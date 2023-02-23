using DesafioWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using DesafioWebAPI.Infra.Data.Context.helper;

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

        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizeBehavior();

            modelBuilder.ApplyConventions();
            base.OnModelCreating(modelBuilder);
        }
    }
}

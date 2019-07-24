using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepositoryPattern.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        //You can add your related entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //You can define your entity-relationships

            base.OnModelCreating(modelBuilder);
        }
    }
}

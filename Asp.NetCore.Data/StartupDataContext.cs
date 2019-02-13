using Asp.NetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Data
{
    public class StartupDataContext : DbContext
    {
        public virtual DbSet<Note> Note { get; set; }

        private readonly string _dbName;

        public StartupDataContext(DbContextOptions<StartupDataContext> options) : base(options)
        {
            // For Database  Migration Enable This.
            //Database.SetCommandTimeout(150000);
        }

        public StartupDataContext(string dbName)
        {
            _dbName = dbName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!string.IsNullOrEmpty(_dbName))
            {
                optionsBuilder.UseSqlServer(_dbName);
                
            }
                
        }
    }
}

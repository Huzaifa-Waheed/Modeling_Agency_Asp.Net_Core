﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modeling_Agency.Models.DbModels;

namespace Modeling_Agency.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<HireRecord> HireRecords { set; get; }
        public DbSet<ModelApplication> ModelApplications { set; get; }
        public DbSet<Messages> messages { set; get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

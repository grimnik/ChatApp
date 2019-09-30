﻿using System;
using System.Collections.Generic;
using System.Text;
using LetsChat.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LetsChat.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Groep> Groepen { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext(ModelBuilder builder)
        {
            builder.Entity<Groep>().HasMany(g => g.Channels);
            builder.Entity<Groep>().HasMany(g => g.Users);
        }
    }
}
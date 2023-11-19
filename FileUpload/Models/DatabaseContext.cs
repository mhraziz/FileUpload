﻿using Microsoft.EntityFrameworkCore;

namespace FileUpload.Models
{
        public class DatabaseContext : DbContext
        {
            public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
            {
            }
            public DbSet<Files> Files { get; set; }
        }
    
}

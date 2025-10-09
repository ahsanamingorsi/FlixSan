using FlixSan.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace FlixSan.Data
{
    public class FlixSanDbContext : DbContext
    {
        public FlixSanDbContext(DbContextOptions<FlixSanDbContext> options) : base(options)
        {

        }

        public DbSet<MovieDetails> tbl_MoviesDetails { get; set; }
    }
}

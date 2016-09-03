using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SKCDirectory1.Models
{
    public partial class DirectoryInfoContext : DbContext
    {
        public DirectoryInfoContext(DbContextOptions<DirectoryInfoContext> options)
            : base(options)
        { }

        public virtual DbSet<DirectoryEntries> DirectoryEntries { get; set; }
        public virtual DbSet<DirectoryView> DirectoryView { get; set; }
    }
}
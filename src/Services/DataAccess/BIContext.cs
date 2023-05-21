using Domain.Models;
using Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BIContext : DbContext
    {
        public BIContext(DbContextOptions<BIContext> options) : base (options) { }
        public virtual DbSet<UniqueWordsEntity> UniqueWords { get; set; }
        public virtual DbSet<HashedUniqueWordsEntitiy> HashedUniqueWords { get; set; }
        public virtual DbSet<WatchListEntity> WatchList { get; set; }
        public virtual DbSet<LogEntity> Logs { get; set; }
    }    
}
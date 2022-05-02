using ItemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data;

public class ApiDbContext : DbContext
{
    public virtual DbSet<ItemData> Items { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }
}

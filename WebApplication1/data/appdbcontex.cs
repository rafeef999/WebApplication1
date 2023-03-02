using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.data
{
    public class appdbcontex:DbContext
    {
        public appdbcontex(DbContextOptions<appdbcontex> options) :base(options)
        {

        }
        public DbSet<catagory> Catagories { get; set; }
    }
}

using Chat_System_Using_SignalR_ASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat_System_Using_SignalR_ASP.NET.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
    }
}

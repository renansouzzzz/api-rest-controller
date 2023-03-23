using api_rest_controller.Models;
using Microsoft.EntityFrameworkCore;

namespace api_rest_controller.src.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> opts)
            : base(opts)
        {
            
        }

        public DbSet <Customer> Customers { get; set; }
    }
}

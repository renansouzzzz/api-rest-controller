using api_rest_controller.Models;
using Microsoft.EntityFrameworkCore;

namespace api_rest_controller.src.Data;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> opts)
        : base(opts)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Employee> Employees { get; set; }
}

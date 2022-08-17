namespace WebAppMVC.Data;

public class UserContext : DbContext
{
    public DbSet<UserModel> Users { get; set; } = null!;

    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>().HasData(
            new UserModel { UserId = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com" },
            new UserModel { UserId = 2, FirstName = "Jane", LastName = "Mackenzie", Email = "jane@example.com"}
        );
    }
}
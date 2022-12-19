using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;


        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Employee>()
                .HasData(new Employee[] {
                    new()
                    {
                        Id = 1,
                        Name = "John",
                        Surname = "Smith",
                        Email = "johnsmithr@gmail.com",
                        DateOfBirth = "1995/07/15",
                        Description = "John Smith description Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        ImageFileName = "johnsmith-1art54e.jpg",
                        PhoneNumber = "055139341",
                        Salary = 280000,
                        DepartmentId = 1
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Adam",
                        Surname = "Lamberd",
                        Email = "adamlamberd11@gmail.com",
                        DateOfBirth = "1995/07/20",
                        Description = "Adam Lamberd description Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        ImageFileName = "adamlamberd-ambg478.jpg",
                        PhoneNumber = "093124578",
                        Salary = 360000,
                        DepartmentId = 2
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Alexandr",
                        Surname = "Tumanyan",
                        Email = "alexandrtumanyan78@gmail.com",
                        DateOfBirth = "1995/07/15",
                        Description = "Alexandr Tumanyan description Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        ImageFileName = "alexandrtumanyan-bbbg118.jpg",
                        PhoneNumber = "043567889",
                        Salary = 490000,
                        DepartmentId = 3
                    },
            });

            modelBuilder
                .Entity<Department>()
                .HasData(new Department[] {
                    new()
                    {
                        Id = 1,
                        Name = "IOS Developer"
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Android Developer"
                    },
                    new()
                    {
                        Id = 3,
                        Name = "React.js Developer"
                    },
                    new()
                    {
                        Id = 4,
                        Name = "HR"
                    },
                    new()
                    {
                        Id = 5,
                        Name = "UI/UX Designer"
                    },
                    new()
                    {
                        Id = 6,
                        Name = "Graphic Designer"
                    },
            });

            modelBuilder
                .Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

#region DbContext

// DbContext is the primary EF Core class that represents a session with the database.
// It manages database connections, tracks changes in entities,
// executes database queries, and maps C# entity classes to database tables.

// It acts as a bridge between the application and the database.
// It allows the application to perform CRUD operations
// and communicate with the database using C# objects instead of raw SQL.

#endregion


namespace WebNetCoreEntittyFramework.Entities
{
    public class StudentDbContext : DbContext // Inherits DbContext from the EF Core library
    {

        // Default constructor
        // Allows creating an instance of StudentDbContext without configuration.
        public StudentDbContext() : base()
        {
        }


        // Constructor used by Dependency Injection.
        // Receives DbContextOptions that contain database configuration
        // such as the database provider and connection string.
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }


        // DbSet represents a database table.
        // The Student generic type maps this property to the Student entity.
        // EF Core uses this to perform CRUD operations and generate migrations.
        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }

    }
}
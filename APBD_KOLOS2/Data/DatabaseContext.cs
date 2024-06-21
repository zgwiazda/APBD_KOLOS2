using APBD_KOLOS2.Models;
using Microsoft.EntityFrameworkCore;
using Object = APBD_KOLOS2.Models.Object;


public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Object> Objects { get; set; }
    public DbSet<Object_Type> ObjectTypes { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Object_Owner> ObjectOwners { get; set; }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Object_Owner>()
            .HasKey(oo => new { oo.Object_ID, oo.Owner_ID });

        modelBuilder.Entity<Object>()
            .HasOne(o => o.Warehouse)
            .WithMany(w => w.Objects)
            .HasForeignKey(o => o.Warehouse_ID);

        modelBuilder.Entity<Object>()
            .HasOne(o => o.ObjectType)
            .WithMany(ot => ot.Objects)
            .HasForeignKey(o => o.Object_Type_ID);

        modelBuilder.Entity<Object_Owner>()
            .HasOne(oo => oo.Object)
            .WithMany(o => o.ObjectOwners)
            .HasForeignKey(oo => oo.Object_ID);

        modelBuilder.Entity<Object_Owner>()
            .HasOne(oo => oo.Owner)
            .WithMany(ow => ow.ObjectOwners)
            .HasForeignKey(oo => oo.Owner_ID);

        modelBuilder.Entity<Warehouse>().HasData(
            new Warehouse { ID = 1, Name = "Warehouse A" },
            new Warehouse { ID = 2, Name = "Warehouse B" }
        );

        modelBuilder.Entity<Object_Type>().HasData(
            new Object_Type { ID = 1, Name = "Type 1" },
            new Object_Type { ID = 2, Name = "Type 2" }
        );

        modelBuilder.Entity<Owner>().HasData(
            new Owner { ID = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "123456789" },
            new Owner { ID = 2, FirstName = "Jane", LastName = "Smith", PhoneNumber = "987654321" }
        );

        modelBuilder.Entity<Object>().HasData(
            new Object { ID = 1, Warehouse_ID = 1, Object_Type_ID = 1, Width = 1.23M, Height = 2.34M },
            new Object { ID = 2, Warehouse_ID = 2, Object_Type_ID = 2, Width = 2.34M, Height = 3.45M }
        );

        modelBuilder.Entity<Object_Owner>().HasData(
            new Object_Owner { Object_ID = 1, Owner_ID = 1 },
            new Object_Owner { Object_ID = 2, Owner_ID = 2 }
        );
    }
}

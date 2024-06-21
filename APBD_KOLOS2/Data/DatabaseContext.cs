using APBD_KOLOS2.Models;
using Microsoft.EntityFrameworkCore;
using Object = System.Object;

namespace APBD_KOLOS2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Object> Objects { get ; set; }
    public DbSet<Object_Owner> Objects_owners { get; set; }
    public DbSet<Object_Type> Objects_types { get ; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }




}
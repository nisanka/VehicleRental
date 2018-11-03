namespace VehicleRentalUI.Context
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using VehicleRentalUI.Models;

    public class VehicleRentalContext : DbContext
    {
        // Your context has been configured to use a 'VehicleRentalContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'VehicleRentalUI.Context.VehicleRentalContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'VehicleRentalContext' 
        // connection string in the application configuration file.
        public VehicleRentalContext()
            : base("name=VehicleRentalContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProvinceCategory> ProvinceCategories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Attachment> VehicleImages { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
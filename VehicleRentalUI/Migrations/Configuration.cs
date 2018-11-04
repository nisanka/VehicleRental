namespace VehicleRentalUI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VehicleRentalUI.Context.VehicleRentalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "VehicleRentalUI.Context.VehicleRentalContext";
        }

        protected override void Seed(VehicleRentalUI.Context.VehicleRentalContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.ProvinceCategories.AddOrUpdate(x => x.Id,
                new Models.ProvinceCategory() { Id = "CP", Name = "Central Province" },
                new Models.ProvinceCategory() { Id = "EP", Name = "Eastern Province" },
                new Models.ProvinceCategory() { Id = "NC", Name = "North Central Province" },
                new Models.ProvinceCategory() { Id = "NP", Name = "Northern Province" },
                new Models.ProvinceCategory() { Id = "NW", Name = "North Western Province" },
                new Models.ProvinceCategory() { Id = "SG", Name = "Sabaragamuwa" },
                new Models.ProvinceCategory() { Id = "SP", Name = "Southern Province" },
                new Models.ProvinceCategory() { Id = "UP", Name = "Uva Province" },
                new Models.ProvinceCategory() { Id = "WP", Name = "Western Province" }
            );

            context.Brands.AddOrUpdate(x => x.Id,
                new Models.Brand() { Id = "Chevrolet", Name = "Chevrolet" },
                new Models.Brand() { Id = "Daihatsu", Name = "Daihatsu" },
                new Models.Brand() { Id = "Peugeot", Name = "Peugeot" },
                new Models.Brand() { Id = "Audi", Name = "Audi" },
                new Models.Brand() { Id = "Benz", Name = "Benz" },
                new Models.Brand() { Id = "BMW", Name = "BMW" },
                new Models.Brand() { Id = "Ford", Name = "Ford" },
                new Models.Brand() { Id = "Honda", Name = "Honda" },
                new Models.Brand() { Id = "Hyundai", Name = "Hyundai" },
                new Models.Brand() { Id = "Kia", Name = "Kia" },
                new Models.Brand() { Id = "Mazda", Name = "Mazda" },
                new Models.Brand() { Id = "Mercedes-Benz", Name = "Mercedes-Benz" },
                new Models.Brand() { Id = "Micro", Name = "Micro" },
                new Models.Brand() { Id = "Mini Cooper", Name = "Mini Cooper" },
                new Models.Brand() { Id = "Mitsubishi", Name = "Mitsubishi" },
                new Models.Brand() { Id = "Nissan", Name = "Nissan" },
                new Models.Brand() { Id = "Perodua", Name = "Perodua" },
                new Models.Brand() { Id = "Renault", Name = "Renault" },
                new Models.Brand() { Id = "SsangYong", Name = "SsangYong" },
                new Models.Brand() { Id = "Subaru", Name = "Subaru" },
                new Models.Brand() { Id = "Suzuki", Name = "Suzuki" },
                new Models.Brand() { Id = "Tata", Name = "Tata" },
                new Models.Brand() { Id = "Toyota", Name = "Toyota" },
                new Models.Brand() { Id = "Volvo", Name = "Volvo" }
            );

            context.VehicleTypes.AddOrUpdate(x => x.Id,
                new Models.VehicleType() { Id = "Motorbike", Name = "Motorbike" },
                new Models.VehicleType() { Id = "Car", Name = "Car" },
                new Models.VehicleType() { Id = "Van", Name = "Van" },
                new Models.VehicleType() { Id = "Cab", Name = "Cab" },
                new Models.VehicleType() { Id = "Bus", Name = "Bus" }
            );
        }
    }
}

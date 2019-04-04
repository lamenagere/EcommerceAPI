namespace Ecommerce.Data.Migrations
{
    using Ecommerce.Data.Entities;
    using Ecommerce.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ecommerce.Data.EcommerceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Ecommerce.Data.EcommerceContext context)
        {
            context.Database.ExecuteSqlCommand("ALTER TABLE [UserDetails] NOCHECK CONSTRAINT ALL");
            context.Database.ExecuteSqlCommand("ALTER TABLE [Accounts] NOCHECK CONSTRAINT ALL");
            context.Database.ExecuteSqlCommand("ALTER TABLE [Categories] NOCHECK CONSTRAINT ALL");
            context.Database.ExecuteSqlCommand("ALTER TABLE [Products] NOCHECK CONSTRAINT ALL");


            context.Database.ExecuteSqlCommand("DELETE FROM [ShoppingProducts]");

            context.Database.ExecuteSqlCommand("DELETE FROM [Products]");
            context.Database.ExecuteSqlCommand("DELETE FROM [Categories]");

            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Categories', RESEED, 1)");

            context.Database.ExecuteSqlCommand("ALTER TABLE [Categories] CHECK CONSTRAINT ALL");


            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Products', RESEED, 1)");

            context.Database.ExecuteSqlCommand("ALTER TABLE [Products] CHECK CONSTRAINT ALL");

            
            context.Database.ExecuteSqlCommand("DELETE FROM [UserDetails]");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('UserDetails', RESEED, 1)");

            
            context.Database.ExecuteSqlCommand("DELETE FROM [Accounts]");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Accounts', RESEED, 1)");


            // Principales catégories
            context.Categories.Add(new Category() { Name = "Informatique", ParentCategory = null, Products = null });
            context.Categories.Add(new Category() { Name = "Tv & Audio", ParentCategory = null, Products = null });
            context.Categories.Add(new Category() { Name = "Téléphonie", ParentCategory = null, Products = null });
            context.SaveChanges();

            // Catégorie Informatique
            var catInfo = context.Categories.Where(c => c.Name == "Informatique").SingleOrDefault();
            context.Categories.Add(new Category() { Name = "Ecrans", ParentCategory = catInfo, Products = null });
            context.Categories.Add(new Category() { Name = "Tours", ParentCategory = catInfo, Products = null });
            context.Categories.Add(new Category() { Name = "Accessoires", ParentCategory = catInfo, Products = null });
            context.SaveChanges();

            // Catégorie Ecrans
            var catEcrans = context.Categories.Where(c => c.Name == "Ecrans").SingleOrDefault();
            context.Categories.Add(new Category() { Name = "Iiyama", ParentCategory = catEcrans, Products = null });
            context.Categories.Add(new Category() { Name = "Lenovo", ParentCategory = catEcrans, Products = null });
            context.SaveChanges();

            // Catégorie Tours
            var catTours = context.Categories.Where(c => c.Name == "Tours").SingleOrDefault();
            context.Categories.Add(new Category() { Name = "Dell", ParentCategory = catTours, Products = null });
            context.Categories.Add(new Category() { Name = "Lenovo", ParentCategory = catTours, Products = null });
            context.Categories.Add(new Category() { Name = "HP", ParentCategory = catTours, Products = null });
            context.SaveChanges();

            // Catégorie Accessoires
            var catAcc = context.Categories.Where(c => c.Name == "Accessoires").SingleOrDefault();
            context.Categories.Add(new Category() { Name = "Souris", ParentCategory = catAcc, Products = null });
            context.Categories.Add(new Category() { Name = "Claviers", ParentCategory = catAcc, Products = null });
            context.SaveChanges();

            var product = context.Products.Add(new Product()
            {
                Name = "Laptop Vaio",
                Description = "Ordinateur Portable",
                Price = 1357,
                PublicationDate = DateTime.Now,
                Category = context.Categories.First(x => x.Name == "Dell")
            });

            context.SaveChanges();

            var product1 = context.Products.Add(new Product()
            {
                Name = "Laptop Apple",
                Description = "Ordinateur Portable",
                Price = 9999,
                PublicationDate = DateTime.Now,
                Category = context.Categories.First(x => x.Name == "Dell")
            });

            #region Users
            var adminDetails = context.UserDetails.Add(new UserDetails()
            {
                CompanyName = "Lambda",
                CreationDate = DateTime.Now,
                Email = "nicolassargos@hotmail.com",
                FirstName = "Nicolas",
                Name = "Sargos",
                Phone = "+3247359884"
            });

            var userDetails = context.UserDetails.Add(new UserDetails()
            {
                CompanyName = "none",
                CreationDate = DateTime.Now,
                Email = "nicolassargos@hotmail.com",
                FirstName = "Nicolas",
                Name = "Sargos",
                Phone = "+3247359884"
            });

            var userAdmin = context.Accounts.Add(new Account()
            {
                Password = "admin",
                UserName = "admin",
                Role = "Admin",
                Details = adminDetails
            });

            var userLambda = context.Accounts.Add(new Account()
            {
                Password = "atan",
                UserName = "john",
                Role = "Customer",
                Details = userDetails
            });

            context.SaveChanges();
            #endregion



            context.Database.ExecuteSqlCommand("ALTER TABLE [ShoppingProducts] NOCHECK CONSTRAINT ALL");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('ShoppingProducts', RESEED, 1)");
            context.Database.ExecuteSqlCommand("ALTER TABLE [ShoppingProducts] CHECK CONSTRAINT ALL");


            context.SaveChanges();

        }
    }
}

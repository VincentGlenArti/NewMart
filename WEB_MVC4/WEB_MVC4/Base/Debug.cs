using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using WEB_MVC4.Models;

namespace WEB_MVC4.Base
{
    public static class Debug
    {
        public static void PutSampleDataInYourDB()
        {
            using (databaseModelContainer DataBase = new databaseModelContainer())
            {
                try
                {
                    DataBase.CategorySet.Add(new Category() { Name = "SUPERPARRENT", CategoryID = 1 });
                    DataBase.SaveChanges();
                    for (int Category = 10; Category < 20; Category++ )
                        DataBase.CategorySet.Add(new Category() { Name = "Sample Category " + Category.ToString(), CategoryID = 1 });
                    DataBase.SaveChanges();
                    for (int Manufacturer = 1; Manufacturer < 2; Manufacturer++)
                        DataBase.ManufacturerSet.Add(new Manufacturer() { Name = "Sample Manufacturer " + Manufacturer.ToString()});
                    DataBase.SaveChanges();
                    for (int Product = 1; Product < 16; Product++)
                        DataBase.ProductSet.Add(new Product() { Name = "Product#" + Product.ToString(), CategoryID = 2,
                            Info = "Sample Product " + Product.ToString(), ManufacturerID = 1, Picture = "No Pic Yet", Price = "1.99" });
                    DataBase.SaveChanges();
                    DataBase.DiscountSet.Add(new Discount() { ProductID = 9, DiscountUnit = "$", DiscountVal = "1" });
                    DataBase.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    foreach (var item in ex.Entries)
                    {
                        foreach (var outval in item.CurrentValues.PropertyNames)
                            System.Diagnostics.Debug.WriteLine(outval.ToString());
                    }
                }
            }
        }
    }
}
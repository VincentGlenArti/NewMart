﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEB_MVC4.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class databaseModelContainer : DbContext
    {
        public databaseModelContainer()
            : base("name=databaseModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Product> ProductSet { get; set; }
        public virtual DbSet<Category> CategorySet { get; set; }
        public virtual DbSet<Manufacturer> ManufacturerSet { get; set; }
        public virtual DbSet<Discount> DiscountSet { get; set; }
        public virtual DbSet<Order> OrderSet { get; set; }
        public virtual DbSet<OrderProducts> OrderProductsSet { get; set; }
        public virtual DbSet<Location> LocationSet { get; set; }
        public virtual DbSet<Stock> StockSet { get; set; }
        public virtual DbSet<User> UserSet { get; set; }
        public virtual DbSet<Cart> CartSet { get; set; }
        public virtual DbSet<CartProducts> CartProductsSet { get; set; }
    }
}

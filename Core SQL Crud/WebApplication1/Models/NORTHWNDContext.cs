#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class NORTHWNDContext : DbContext
    {
        public NORTHWNDContext(DbContextOptions<NORTHWNDContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.OrderID).IsRequired();
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.EmployeeID).IsRequired();
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.CustomerID).IsRequired();
            });

        }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }

        public virtual DbSet<Customers> Customers { get; set; }
    }
}

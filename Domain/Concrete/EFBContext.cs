using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uh365898_db.Domain.Entities;
using System.Data.Entity;


namespace uh365898_db.Domain.Concrete
{
    public class EFBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Guestbook> Guestbooks { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Categone> Categones { get; set; }
         public DbSet<Producer>  Producers { get; set; }
         public DbSet<Categzer> Categzers { get; set; }

         public DbSet<Packing> Packings { get; set; }
         public DbSet<Categtw> Categtws { get; set; }
         public DbSet<Applying> Applyings { get; set; }
         public DbSet<Proper> Propers { get; set; }
         public DbSet<Techcharacter> Techcharacters { get; set; }
        public dynamic ViewBag { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

           modelBuilder.Entity<Proper>().HasMany(c => c.Products)
               .WithMany(t => t.Propers)
              .Map(t => t.MapLeftKey("ProperID")
              .MapRightKey("ProductID")
              .ToTable("ProperProduct"));

      //      modelBuilder.Entity<Product>().HasMany(c => c.Propers)
      //         .WithRequired()
  //  .HasForeignKey(c => c.ProperID)
 //   .WillCascadeOnDelete(false);
               
            
            
            modelBuilder.Entity<Applying>().HasMany(c => c.Products)
                .WithMany(s => s.Applyings)
                .Map(t => t.MapLeftKey("ApplyingID")
                .MapRightKey("ProductID")
                .ToTable("ApplyingProduct")); 
            
            modelBuilder.Entity<Techcharacter>().HasMany(c => c.Products)
                .WithMany(s => s.Techcharacters)
                .Map(t => t.MapLeftKey("TechcharacterID")
                .MapRightKey("ProductID")
                .ToTable("TechcharacterProduct"));
        }

       
    } 
   
}
//класс контекста связывать простую модель с базой данных.
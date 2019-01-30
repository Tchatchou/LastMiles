using Data_Base.DB_Identity_Management;
using Data_Base.DB_Product_Management;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data_Base
{

    public class DataContext : IdentityDbContext<User, Role, int,
                               IdentityUserClaim<int>, User_Role,
                               IdentityUserLogin<int>, IdentityRoleClaim<int>,
                               IdentityUserToken<int>>
    {
        const string connectionString = "Integrated Security=SSPI;Initial Catalog=LastMilesDB;Data Source=CHRIS\\SQLEXPRESS;";
       
        public DataContext() : base() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
//https://garywoodfine.com/using-ef-core-in-a-separate-class-library-project/
//https://stackoverflow.com/questions/51145780/using-entity-framework-core-migrations-for-class-library-project

/* 
        public DataContext CreateDbContext(string[] args)
        {
          var builder  = new ConfigurationBuilder()
                                    .SetBasePath(@"C:\Users\Jonathan\Desktop\Distribution\LastMiles\LastMiles.API")
                                    .AddJsonFile("appsettings.json")
                                    .Build();
          var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer(builder.GetConnectionString("DefaultConnection"));
            return new DataContext(optionsBuilder.Options);
        }  */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User_Role>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                userRole.HasOne(ur => ur.User)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
            });

            modelBuilder.Entity<Role_Permission>(rolePermission =>
            {
                rolePermission.HasKey(ur => new { ur.RoleId, ur.permission_id });

                rolePermission.HasOne(ur => ur.Role)
                        .WithMany(r => r.list_role_permissions)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                rolePermission.HasOne(ur => ur.permission)
                        .WithMany(r => r.list_role_permissions)
                        .HasForeignKey(ur => ur.permission_id)
                        .IsRequired();
            });


            modelBuilder.Entity<Role_Creation_Possibility>(rolecreationpossibility =>
            {
                rolecreationpossibility.HasKey(ur => new { ur.RoleId, ur.availablerole_id });

                rolecreationpossibility.HasOne(ur => ur.Role)
                        .WithMany(r => r.list_role_creation_possibility)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                rolecreationpossibility.HasOne(ur => ur.available_role)
                        .WithMany(r => r.list_role_creation_possibility)
                        .HasForeignKey(ur => ur.availablerole_id)
                        .IsRequired();
            });

            modelBuilder.Entity<Distributor_Company>()
               .HasKey(bc => new { bc.distributor_id, bc.company_id });
            modelBuilder.Entity<Distributor_Company>()
                .HasOne(bc => bc.distributor)
                .WithMany(b => b.list_distributor_companies)
                .HasForeignKey(bc => bc.distributor_id);
            modelBuilder.Entity<Distributor_Company>()
                .HasOne(bc => bc.Company)
                .WithMany(c => c.list_distributor_companies)
                .HasForeignKey(bc => bc.company_id);


            modelBuilder.Entity<Distributor_Retailer>()
                .HasKey(bc => new { bc.distributor_id, bc.retailer_id });
            modelBuilder.Entity<Distributor_Retailer>()
                .HasOne(bc => bc.distributor)
                .WithMany(b => b.list_distributor_retailer)
                .HasForeignKey(bc => bc.distributor_id);
            modelBuilder.Entity<Distributor_Retailer>()
                .HasOne(bc => bc.retailer)
                .WithMany(c => c.list_distributor_retailer)
                .HasForeignKey(bc => bc.retailer_id);


            modelBuilder.Entity<Distributor_Company>()
                .HasKey(bc => new { bc.distributor_id, bc.company_id });
            modelBuilder.Entity<Distributor_Company>()
                .HasOne(bc => bc.distributor)
                .WithMany(b => b.list_distributor_companies)
                .HasForeignKey(bc => bc.distributor_id);
            modelBuilder.Entity<Distributor_Company>()
                .HasOne(bc => bc.Company)
                .WithMany(c => c.list_distributor_companies)
                .HasForeignKey(bc => bc.company_id);

        }


        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Available_Role> Available_Roles { get; set; }
        public DbSet<Retailer> Retailers { get; set; }
        public DbSet<Retailer_Type> Retailer_Types { get; set; }
        public DbSet<Retailer_Disponibility> Retailer_Disponibilities { get; set; }
        public DbSet<Opening_Closing> Opening_Closings { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Distributor_Type> Distributor_Types { get; set; }
        public DbSet<Distributor_Retailer> Distributor_Retailers { get; set; }
        public DbSet<Distributor_Company> Distributor_Companies { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Company_Type> Company_Types { get; set; }

        // Product Management
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Category> Product_Categories { get; set; }

        public DbSet<Product_Pricing_Table_Distributor> Product_Pricing_Table_Distributors { get; set; }

        public DbSet<Product_Pricing_Table_Retailer> Product_Pricing_Table_Retailers { get; set; }

        /* 
               // ordering system
               public DbSet<Order_Receiver> Order_Receivers { get; set; }
               public DbSet<Order_Type> Order_Types { get; set; }
               public DbSet<Order_Sender> Order_Senders { get; set; }
               public DbSet<Order> Orders { get; set; }
               public DbSet<OrderDetail> OrderDetails { get; set; }
              
           */
    }
}
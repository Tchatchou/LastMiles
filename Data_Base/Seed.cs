using System;
using System.Collections.Generic;
using System.Linq;
using Data_Base.DB_Identity_Management;
using Microsoft.AspNetCore.Identity;

namespace Data_Base
{
    public class Seed
    {
        private readonly DataContext _db;

        public RoleManager<Role> _roleManager { get; }

        public UserManager<User> _userManager { get; }


        public Seed(DataContext  db, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
            _db = db;
            _userManager = userManager;
        }

        public void DataBaseSeeding()
        {
            if (_roleManager.Roles.Count() == 0)
            {
                var roles = new List<Role>{
                    new Role{Name="SuperAdmin"},
                    new Role{Name="Admin"},

                    new Role{Name="RetailerAdmin"},
                    new Role{Name="Retailer"},

                    new Role{Name="DistributeurAdmin"},
                    new Role{Name="Distributeur"},

                    new Role{Name="CompanyAdmin"},
                    new Role{Name="Company"},
                    new Role{Name="Commercial"},
                };

                int i = 1;
                foreach (var r in roles)
                {
                    _roleManager.CreateAsync(r).Wait(); // use .wait because async on void returning type don work
                    
                    var available_role= new Available_Role{availablerole_id = i,role_name = r.Name};

                    _db.Available_Roles.Add(available_role);
                    i++;
                    
                }                
                _db.SaveChanges();

            }

            if (!_userManager.Users.Any())
                {
                    var SuperAdmin = new List<User>(){
                        new User {
                            UserName = "SuperAdmin",
                            Email ="jonathan.nicanor@gmail.com",
                            PhoneNumber = "652021280",
                            FirstName = "Jean Christophe",
                            LastName = "Djouonang",
                            LastActive = DateTime.Now,
                            Created = DateTime.Now,
                            UserAccessingEntityWithPermissions = "ALL",
                            EntityUserMapTo_Id = 0,
                            EntityUserMapTo_Name = "User Administration",
                            EntityUserMapTo_Type ="User Administration"
                        },

                         new User {
                            UserName = "sa",
                            Email ="jonathan.nicanor@gmail.com",
                            PhoneNumber = "652021280",
                            FirstName = "Jean Christophe",
                            LastName = "Djouonang",
                            LastActive = DateTime.Now,
                            Created = DateTime.Now,
                            UserAccessingEntityWithPermissions = "ALL",
                            EntityUserMapTo_Id = 0,
                            EntityUserMapTo_Name = "User Administration",
                            EntityUserMapTo_Type ="User Administration"
                        }
                    };               

                    foreach (var u in SuperAdmin)
                    {
                        _userManager.CreateAsync(u, "password").Wait();
                        _userManager.AddToRoleAsync(u,"SuperAdmin").Wait();
                    }

                    /////////

                     var AdminUser = new List<User>(){
                        new User {
                            UserName = "Admin",
                            Email ="jonathan.nicanor@gmail.com",
                            PhoneNumber = "652021280",
                            FirstName = "Jean Christophe",
                            LastName = "Djouonang",
                            LastActive = DateTime.Now,
                            Created = DateTime.Now,
                            UserAccessingEntityWithPermissions = "ALL",
                            EntityUserMapTo_Id = 0,
                            EntityUserMapTo_Name = "User Administration",
                            EntityUserMapTo_Type ="User Administration"
                        }
                    };               

                    foreach (var u in AdminUser)
                    {
                        _userManager.CreateAsync(u, "password").Wait();
                        _userManager.AddToRoleAsync(u,"Admin").Wait();
                    }                   
                }

            if(_db.Company_Types.Count()==0)
            {
               _db.Company_Types.AddRange(new List<Company_Type>() {
                   new Company_Type {
                       Company_type_id = 1,
                       name = "super grossist",
                       desc ="La societe s'approvitionne localement chez un gros industrielle (SABC), et a ses propre circuit de distribution avec ses distributeur"
                   },
                   new Company_Type {
                          Company_type_id = 2,
                        name = "representant",
                       desc ="la societe represente une morque generalement etrangere"
                   },
                   new Company_Type {
                          Company_type_id = 3,
                        name = "fabricant",
                       desc ="La societe fabrique elle meme ses produits et les distribus"
                   }
               });     
            }

            if(_db.Retailer_Types.Count()==0)
            {
                  _db.Retailer_Types.AddRange(new List<Retailer_Type>() {
                      new Retailer_Type {
                       retailer_type_id =1,
                       name = "Etalage",
                       desc ="Etalage"
                   },
                   new Retailer_Type {
                       retailer_type_id =2,
                       name = "Boutique",
                       desc ="petite boutique du quartier"
                   },
                   new Retailer_Type {
                    retailer_type_id =3,
                        name = "Alimentation",
                       desc ="Alimentation"
                   },
                   new Retailer_Type {
                           retailer_type_id =4,
                        name = "Mini Super Marche",
                       desc ="Mini Super Marche"
                   },
                   new Retailer_Type {
                           retailer_type_id =5,
                        name = "Super Marche",
                       desc ="Super Marche"
                   }
               });    
            }

            if(_db.Distributor_Types.Count()==0)
            {
                _db.Distributor_Types.AddRange(new List<Distributor_Type>() {
                   new Distributor_Type {
                       distributor_type_id = 1,
                       name = "Interne",
                       desc ="compte distributer propre a une Compani"
                   },
                   new Distributor_Type {
                          distributor_type_id = 2,
                        name = "Externe",
                       desc ="distributeur independant"
                   }
               });     
            }
           
            if (_db.Set<Role_Creation_Possibility>().Count() ==0) {

               // super admin role can create
               _db.AddRange(new Role_Creation_Possibility{RoleId =1, availablerole_id=1});
               _db.AddRange(new Role_Creation_Possibility{RoleId =1, availablerole_id=2});
               _db.AddRange(new Role_Creation_Possibility{RoleId =1, availablerole_id=3});
               _db.AddRange(new Role_Creation_Possibility{RoleId =1, availablerole_id=4});
               _db.AddRange(new Role_Creation_Possibility{RoleId =1, availablerole_id=5});
               _db.AddRange(new Role_Creation_Possibility{RoleId =1, availablerole_id=6});
               _db.AddRange(new Role_Creation_Possibility{RoleId =1, availablerole_id=7});
               _db.AddRange(new Role_Creation_Possibility{RoleId =1, availablerole_id=8});
               _db.AddRange(new Role_Creation_Possibility{RoleId =1, availablerole_id=9});
    
               // admin role can create
               _db.AddRange(new Role_Creation_Possibility{RoleId =2, availablerole_id=3});
               _db.AddRange(new Role_Creation_Possibility{RoleId =2, availablerole_id=4});
               _db.AddRange(new Role_Creation_Possibility{RoleId =2, availablerole_id=5});
               _db.AddRange(new Role_Creation_Possibility{RoleId =2, availablerole_id=6});
               _db.AddRange(new Role_Creation_Possibility{RoleId =2, availablerole_id=7});
               _db.AddRange(new Role_Creation_Possibility{RoleId =2, availablerole_id=8}); 
               _db.AddRange(new Role_Creation_Possibility{RoleId =2, availablerole_id=9});
               
                // retailer admin role can create
               _db.AddRange(new Role_Creation_Possibility{RoleId =3, availablerole_id=3});
               _db.AddRange(new Role_Creation_Possibility{RoleId =3, availablerole_id=4});

                // distributor admin role can create
               _db.AddRange(new Role_Creation_Possibility{RoleId =5, availablerole_id=5});
               _db.AddRange(new Role_Creation_Possibility{RoleId =5, availablerole_id=6});
               _db.AddRange(new Role_Creation_Possibility{RoleId =5, availablerole_id=9});

                // company admin role can create
               _db.AddRange(new Role_Creation_Possibility{RoleId =7, availablerole_id=7});
               _db.AddRange(new Role_Creation_Possibility{RoleId =7, availablerole_id=8}); 
               _db.AddRange(new Role_Creation_Possibility{RoleId =7, availablerole_id=5});
               _db.AddRange(new Role_Creation_Possibility{RoleId =7, availablerole_id=9});
            
           }
           
            if(_db.Permissions.Count()==0)
            {
                _db.Permissions.Add(new Permission { permission_id = 1, desc = "ChangePassword"});
                _db.Permissions.Add(new Permission { permission_id = 2, desc = "Lock user"});
                _db.Permissions.Add(new Permission { permission_id = 3, desc = "Unclock user"});
                _db.Permissions.Add(new Permission { permission_id = 4, desc = "Reset user"});
                _db.Permissions.Add(new Permission { permission_id = 5, desc = "Get User"});
            }

             if (_db.Set<Role_Permission>().Count() ==0) 
             {

               // super admin default permission
               _db.AddRange(new Role_Permission{RoleId =1, permission_id=1});
               _db.AddRange(new Role_Permission{RoleId =1, permission_id=2});
               _db.AddRange(new Role_Permission{RoleId =1, permission_id=3});
               _db.AddRange(new Role_Permission{RoleId =1, permission_id=4});
               _db.AddRange(new Role_Permission{RoleId =1, permission_id=5});

               //  admin default permission
               _db.AddRange(new Role_Permission{RoleId =2, permission_id=1});
               _db.AddRange(new Role_Permission{RoleId =2, permission_id=2});
               _db.AddRange(new Role_Permission{RoleId =2, permission_id=3});
               _db.AddRange(new Role_Permission{RoleId =2, permission_id=4});
               _db.AddRange(new Role_Permission{RoleId =2, permission_id=5});

                // retailer admin default permission
               _db.AddRange(new Role_Permission{RoleId =3, permission_id=1});
               _db.AddRange(new Role_Permission{RoleId =3, permission_id=2});
               _db.AddRange(new Role_Permission{RoleId =3, permission_id=3});
               _db.AddRange(new Role_Permission{RoleId =3, permission_id=4});
               _db.AddRange(new Role_Permission{RoleId =3, permission_id=5});

                // retailer  default permission
               _db.AddRange(new Role_Permission{RoleId =4, permission_id=1});
               _db.AddRange(new Role_Permission{RoleId =4, permission_id=2});
               _db.AddRange(new Role_Permission{RoleId =4, permission_id=3});
               _db.AddRange(new Role_Permission{RoleId =4, permission_id=4});
               _db.AddRange(new Role_Permission{RoleId =4, permission_id=5});

                 // dsitributor admin  default permission
               _db.AddRange(new Role_Permission{RoleId =5, permission_id=1});
               _db.AddRange(new Role_Permission{RoleId =5, permission_id=2});
               _db.AddRange(new Role_Permission{RoleId =5, permission_id=3});
               _db.AddRange(new Role_Permission{RoleId =5, permission_id=4});
               _db.AddRange(new Role_Permission{RoleId =5, permission_id=5});

              // dsitributor   default permission
               _db.AddRange(new Role_Permission{RoleId =6, permission_id=1});
               _db.AddRange(new Role_Permission{RoleId =6, permission_id=2});
               _db.AddRange(new Role_Permission{RoleId =6, permission_id=3});
               _db.AddRange(new Role_Permission{RoleId =6, permission_id=4});
               _db.AddRange(new Role_Permission{RoleId =6, permission_id=5});

               // company admin  default permission
               _db.AddRange(new Role_Permission{RoleId =7, permission_id=1});
               _db.AddRange(new Role_Permission{RoleId =7, permission_id=2});
               _db.AddRange(new Role_Permission{RoleId =7, permission_id=3});
               _db.AddRange(new Role_Permission{RoleId =7, permission_id=4});
               _db.AddRange(new Role_Permission{RoleId =7, permission_id=5});

               // company   default permission
               _db.AddRange(new Role_Permission{RoleId =8, permission_id=1});
               _db.AddRange(new Role_Permission{RoleId =8, permission_id=2});
               _db.AddRange(new Role_Permission{RoleId =8, permission_id=3});
               _db.AddRange(new Role_Permission{RoleId =8, permission_id=4});
               _db.AddRange(new Role_Permission{RoleId =8, permission_id=5});

                // commercial   default permission
               _db.AddRange(new Role_Permission{RoleId =9, permission_id=1});
               _db.AddRange(new Role_Permission{RoleId =9, permission_id=2});
               _db.AddRange(new Role_Permission{RoleId =9, permission_id=3});
               _db.AddRange(new Role_Permission{RoleId =9, permission_id=4});
               _db.AddRange(new Role_Permission{RoleId =9, permission_id=5});

             }

            _db.SaveChanges();
        }
    }

}
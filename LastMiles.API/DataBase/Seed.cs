using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Identity;

namespace LastMiles.API.DataBase
{
    public class Seed
    {
        public RoleManager<Role> _roleManager { get; }

        public UserManager<User> _userManager { get; }


        public Seed(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
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
                    new Role{Name="Company"}
                };

                foreach (var r in roles)
                {
                    _roleManager.CreateAsync(r).Wait(); // use .wait because async on void returning type don work
                }
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

                        }
                    };               

                    foreach (var u in AdminUser)
                    {
                        _userManager.CreateAsync(u, "password").Wait();
                        _userManager.AddToRoleAsync(u,"Admin").Wait();
                    }

                     /////////

                     var RetailerAdmin = new List<User>(){
                        new User {
                            UserName = "RetailerAdmin",
                            Email ="jonathan.nicanor@gmail.com",
                            PhoneNumber = "652021280",
                            FirstName = "Jean Christophe",
                            LastName = "Djouonang",
                            LastActive = DateTime.Now,
                            Created = DateTime.Now,

                        }
                    };               

                    foreach (var u in RetailerAdmin)
                    {
                        _userManager.CreateAsync(u, "password").Wait();
                        _userManager.AddToRoleAsync(u,"RetailerAdmin").Wait();
                    }

                     /////////

                     var Retailer = new List<User>(){
                        new User {
                            UserName = "Retailer",
                            Email ="jonathan.nicanor@gmail.com",
                            PhoneNumber = "652021280",
                            FirstName = "Jean Christophe",
                            LastName = "Djouonang",
                            LastActive = DateTime.Now,
                            Created = DateTime.Now,

                        }
                    };               

                    foreach (var u in Retailer)
                    {
                        _userManager.CreateAsync(u, "password").Wait();
                        _userManager.AddToRoleAsync(u,"Retailer").Wait();
                    }

                      /////////

                     var DistributeurAdmin = new List<User>(){
                        new User {
                            UserName = "DistributeurAdmin",
                            Email ="jonathan.nicanor@gmail.com",
                            PhoneNumber = "652021280",
                            FirstName = "Jean Christophe",
                            LastName = "Djouonang",
                            LastActive = DateTime.Now,
                            Created = DateTime.Now,

                        }
                    };               

                    foreach (var u in DistributeurAdmin)
                    {
                        _userManager.CreateAsync(u, "password").Wait();
                        _userManager.AddToRoleAsync(u,"DistributeurAdmin").Wait();
                    }

                       /////////

                     var Distributeur = new List<User>(){
                        new User {
                            UserName = "Distributeur",
                            Email ="jonathan.nicanor@gmail.com",
                            PhoneNumber = "652021280",
                            FirstName = "Jean Christophe",
                            LastName = "Djouonang",
                            LastActive = DateTime.Now,
                            Created = DateTime.Now,

                        }
                    };               

                    foreach (var u in Distributeur)
                    {
                        _userManager.CreateAsync(u, "password").Wait();
                        _userManager.AddToRoleAsync(u,"Distributeur").Wait();
                    }

                        /////////

                     var CompanyAdmin = new List<User>(){
                        new User {
                            UserName = "CompanyAdmin",
                            Email ="jonathan.nicanor@gmail.com",
                            PhoneNumber = "652021280",
                            FirstName = "Jean Christophe",
                            LastName = "Djouonang",
                            LastActive = DateTime.Now,
                            Created = DateTime.Now,

                        }
                    };               

                    foreach (var u in CompanyAdmin)
                    {
                        _userManager.CreateAsync(u, "password").Wait();
                        _userManager.AddToRoleAsync(u,"CompanyAdmin").Wait();
                    }

                     /////////

                     var Company = new List<User>(){
                        new User {
                            UserName = "Company",
                            Email ="jonathan.nicanor@gmail.com",
                            PhoneNumber = "652021280",
                            FirstName = "Jean Christophe",
                            LastName = "Djouonang",
                            LastActive = DateTime.Now,
                            Created = DateTime.Now,

                        }
                    };               

                    foreach (var u in CompanyAdmin)
                    {
                        _userManager.CreateAsync(u, "password").Wait();
                        _userManager.AddToRoleAsync(u,"Company").Wait();
                    }
                }



        }
    }
}
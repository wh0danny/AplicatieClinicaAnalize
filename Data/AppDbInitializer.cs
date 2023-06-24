using AplicatieClinicaAnalize.Data.Static;
using AplicatieClinicaAnalize.Models;
using Microsoft.AspNetCore.Identity;

namespace AplicatieClinicaAnalize.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Clinici
                if (!context.Clinici.Any())
                {
                    context.Clinici.AddRange(new List<Clinica>()
                    {
                        new Clinica(){
                            NumeClinica = "Clinica 1",
                            LogoClinica = "https://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            DescriereClinica = "Descriere Clinica nr 1"
                        },
                        new Clinica(){
                            NumeClinica = "Clinica 2",
                            LogoClinica = "https://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            DescriereClinica = "Descriere Clinica nr 2"
                        },
                        new Clinica(){
                            NumeClinica = "Clinica 3",
                            LogoClinica = "https://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            DescriereClinica = "Descriere Clinica nr 3"
                        },
                        new Clinica(){
                            NumeClinica = "Clinica 4",
                            LogoClinica = "https://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            DescriereClinica = "Descriere Clinica nr 4"
                        },
                        new Clinica(){
                            NumeClinica = "Clinica 5",
                            LogoClinica = "https://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            DescriereClinica = "Descriere Clinica nr 5"
                        }
                    });
                    context.SaveChanges();
                }
                //Doctori
                if (!context.Doctori.Any())
                {
                    context.Doctori.AddRange(new List<Doctor>()
                    {
                        new Doctor()
                        {
                            NumeDoctor = "Nume Doctor 1",
                            DespreDoctor = "Informatii despre primul doctor",
                            PozaDeProfilURL = "https://dotnethow.net/images/actors/actor-1.jpeg"
                        },
                        new Doctor()
                        {
                            NumeDoctor = "Nume Doctor 2",
                            DespreDoctor = "Informatii despre al doilea doctor",
                            PozaDeProfilURL = "https://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Doctor()
                        {
                            NumeDoctor = "Nume Doctor 3",
                            DespreDoctor = "Informatii despre al treilea doctor",
                            PozaDeProfilURL = "https://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Doctor()
                        {
                            NumeDoctor = "Nume Doctor 4",
                            DespreDoctor = "Informatii despre al patrulea doctor",
                            PozaDeProfilURL = "https://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Doctor()
                        {
                            NumeDoctor = "Nume Doctor 5",
                            DespreDoctor = "Informatii despre al cincilea doctor",
                            PozaDeProfilURL = "https://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Analize
                if (!context.Analize.Any())
                {
                    context.Analize.AddRange(new List<Analiza>()
                    {
                        new Analiza()
                        {
                            NumeAnaliza = "Analize ORL",
                            PretAnaliza = 49.99,
                            CategorieAnaliza = Enums.CategorieAnaliza.AnalizeFizice,
                            ClinicaId = 1,
                        },
                        new Analiza()
                        {
                            NumeAnaliza = "Analize Ortopedie",
                            PretAnaliza = 49.99,
                            CategorieAnaliza = Enums.CategorieAnaliza.AnalizeFizice,
                            ClinicaId = 2,
                        },
                        new Analiza()
                        {
                            NumeAnaliza = "Analize Generale",
                            PretAnaliza = 49.99,
                            CategorieAnaliza = Enums.CategorieAnaliza.AnalizeDeSange,
                            ClinicaId = 3,
                        },
                        new Analiza()
                        {
                            NumeAnaliza = "Analize Markeri",
                            PretAnaliza = 49.99,
                            CategorieAnaliza = Enums.CategorieAnaliza.AnalizeDeSange,
                            ClinicaId = 4,
                        },
                        new Analiza()
                        {
                            NumeAnaliza = "Analize Gastrologie",
                            PretAnaliza = 49.99,
                            CategorieAnaliza = Enums.CategorieAnaliza.AnalizeMaterii,
                            ClinicaId = 5,
                        }
                    });
                    context.SaveChanges();
                }
                //Doctori_Analize
                if (!context.Doctori_Analize.Any())
                {
                    context.Doctori_Analize.AddRange(new List<Doctor_Analiza>()
                    {
                        new Doctor_Analiza()
                        {
                            DoctorId = 1,
                            AnalizaId = 1,
                        },
                        new Doctor_Analiza()
                        {
                            DoctorId = 2,
                            AnalizaId = 2,
                        },
                        new Doctor_Analiza()
                        {
                            DoctorId = 3,
                            AnalizaId = 3,
                        },
                        new Doctor_Analiza()
                        {
                            DoctorId = 4,
                            AnalizaId = 4,
                        },
                        new Doctor_Analiza()
                        {
                            DoctorId = 5,
                            AnalizaId = 5,
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if(!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminUserEmail = "admin@analize.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@analize.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Aplication User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Utilizator");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

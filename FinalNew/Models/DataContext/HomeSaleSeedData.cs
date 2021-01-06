using FinalNew.Models.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.Models.DataContext
{
    static public class HomeSaleSeedData
    {
        static public IApplicationBuilder Seed(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<HomeSaleDbContext>();
                //db.Database.Migrate(); //update-database


                //InitCities(db);
                //InitMetros(db);
                //InitCategories(db);
                InitAgents(db);
                InitHomes(db);
                //InitAppInfos(db);
                InitNMRDistricts(db);
                InitBakuDistricts(db);


            }

            return app;
        }

        private static void InitBakuDistricts(HomeSaleDbContext db)
        {
            if (!db.BakuDistricts.Any())
            {
                db.AddRange(
                     new BakuDistrict
                     {
                         Name = "Qaradağ",
                         CityId = 1
                     },
                     new BakuDistrict
                     {
                         Name = "Binəqədi",
                         CityId = 1
                     },
                     new BakuDistrict
                     {
                         Name = "Nizami",
                         CityId = 1
                     },
                     new BakuDistrict
                     {
                         Name = "Nərimanov",
                         CityId = 1
                     },
                     new BakuDistrict
                     {
                         Name = "Nəsimi",
                         CityId = 1
                     },
                     new BakuDistrict
                     {
                         Name = "Pirallahı",
                         CityId = 1
                     },
                     new BakuDistrict
                     {
                         Name = "Sabunçu",
                         CityId = 1
                     },
                     new BakuDistrict
                     {
                         Name = "Səbail",
                         CityId = 1
                     },
                     new BakuDistrict
                     {
                         Name = "Suraxanı",
                         CityId = 1
                     },
                     new BakuDistrict
                     {
                         Name = "Xətai",
                         CityId = 1
                     },
                     new BakuDistrict
                     {
                         Name = "Xəzər",
                         CityId = 1
                     },
                     new BakuDistrict
                     {
                         Name = "Yasamal",
                         CityId = 1
                     }
                    );
                db.SaveChanges();
            }
        }

        private static void InitNMRDistricts(HomeSaleDbContext db)
        {

            if (!db.NMRDistricts.Any())
            {
                db.AddRange(
                     new NMRDistrict
                     {
                         Name = "Babək",
                         CityId = 6
                     },
                     new NMRDistrict
                     {
                         Name = "Şərur",
                         CityId = 6
                     },
                     new NMRDistrict
                     {
                         Name = "Culfa",
                         CityId = 6
                     },
                     new NMRDistrict
                     {
                         Name = "Kəngərli",
                         CityId = 6
                     },
                     new NMRDistrict
                     {
                         Name = "Ordubad",
                         CityId = 6
                     },
                     new NMRDistrict
                     {
                         Name = "Sədərək",
                         CityId = 6
                     },
                     new NMRDistrict
                     {
                         Name = "Şahbuz",
                         CityId = 6
                     }
                    );

                db.SaveChanges();
            }
        }

        private static void InitAppInfos(HomeSaleDbContext db)
        {
            if (!db.AppInfos.Any())
            {
                db.Add(new AppInfo
                {
                    AppTitle="evim",
                    LogoPath="projectLogo.png",
                    FooterLogoPath = "projectLogo2.png",
                    Description = "You can contact us any way that is convenient for you. We are available 24/7 via fax or email. You can also use a quick contact form below or visit our office personally.",
                    Phone= "012-545-78-87",
                    Phone2= "012-545-55-22",
                    WorkOurs= "8:00 - 18:00 Mon - Sat",
                    Email= "Demo@gmail.com",
                    FacebookLink="https://facebook.com",
                    InstagramLink= "https://instagram.com",
                    TwitterLink= "https://github.com/Elcin500/FinalProject",
                    HomePhoto1 = "slide-1.jpg",
                    HomePhoto2= "slide-2.jpg",
                    HomePhoto3 = "slide-3.jpg",
                    AnnounceAdvantages= "Her gün onlarla yeni elan. Günlük minlerle baxış sayısı. Elanların kateqoryalar üzre bölünmesi.",
                    AgentAdvantages= "Satış agentleri üçün sexşi seyfeler. Satış agentlerinin elanları üzre axtarış."
                });

                db.SaveChanges();
            }
        }

        private static void InitMetros(HomeSaleDbContext db)
        {

            if (!db.Metros.Any())
            {
                db.Metros.AddRange(
                    new Metro
                    {
                        Name = "28 May"
                    },
                     new Metro
                     {
                         Name = "Gənclik"
                     },
                     new Metro
                     {
                         Name = "Sahil"
                     },
                     new Metro
                     {
                         Name = "Nəriman Nərimanov"
                     },
                     new Metro
                     {
                         Name = "Nizami"
                     },
                     new Metro
                     {
                         Name = "Xətai"
                     },
                     new Metro
                     {
                         Name = "Elmlər Akademiyası"
                     },
                     new Metro
                     {
                         Name = "20 Yanvar"
                     },
                     new Metro
                     {
                         Name = "Həzi Aslanov"
                     },
                     new Metro
                     {
                         Name = "Əhmədli"
                     },
                     new Metro
                     {
                         Name = "Nefçilər"
                     }


                    );
                db.SaveChanges();
            }

        }

        private static void InitCities(HomeSaleDbContext db)
        {
            if (!db.Cities.Any())
            {
                db.Cities.AddRange(
                    new City
                    {
                        Name="Bakı"
                    },
                     new City
                     {
                         Name = "Gəncə"
                     },
                     new City
                     {
                         Name = "Şamaxı"
                     },
                     new City
                     {
                         Name = "Qəbələ"
                     },
                     new City
                     {
                         Name = "Sumqayıt"
                     },
                     new City
                     {
                         Name = "Naxçıvan"
                     },
                     new City
                     {
                         Name = "Qusar"
                     },
                     new City
                     {
                         Name = "Goranboy"
                     }
                    );
                db.SaveChanges();
            }
        }

        private static void InitAgents(HomeSaleDbContext db)
        {
            if (!db.Agents.Any())
            {
                db.Agents.Add(new Agent { 
                Name="Sabir",
                Surname="Əliyev",
                Phone="055-454-54-54",
                Email="sabir@mail.ru",
                Address="Zon",
                Description="Hər cür evlərin təşkil olunması qısa zamanda.",
                FacebookLink="facebook.com",
                InstagramLink="instagram.com",
                TwitterLink="twitter.com",
                ImagePath="agent-detail-img.jpg",
                OwnerId=8
                });


                //db.Agents.Add(new Agent
                //{
                //    Name = "Leyla",
                //    Surname = "Əliyeva",
                //    Phone = "060-555-55-54",
                //    Email = "leyla@mail.ru",
                //    Address = "Baku",
                //    Description = "Hər cür evlərin təşkil olunması qısa zamanda.",
                //    FacebookLink = "facebook.com",
                //    InstagramLink = "instagram.com",
                //    TwitterLink = "twitter.com",
                //    ImagePath = "agent-detail-img.jpg"
                //});

                db.SaveChanges();
            }


        }

        private static void InitHomeImages(HomeSaleDbContext db)
        {

            if (!db.HomeImages.Any())
            {
                db.HomeImages.Add(new HomeImage
                {
                    Path= @"~\assets\img\home-deatil-1.jpg"
                });

                db.SaveChanges();
            }
        }

        private static void InitCategories(HomeSaleDbContext db)
        {

            if (!db.Categories.Any())
            {
                db.Categories.AddRange(
                    new Category
                    {
                        Name = "Bina"
                    },
                    new Category
                    {
                        Name = "Həyət evi / Villa"
                    },
                    new Category
                    {
                        Name = "Obyekt"
                    },
                    new Category
                    {
                        Name = "Torpaq"
                    },
                    new Category
                    {
                        Name = "Bağ"
                    },
                    new Category
                    {
                        Name = "Ofis"
                    }
                    );

                db.SaveChanges();
            }
        }

        private static void InitHomes(HomeSaleDbContext db)
        {
            if (!db.Homes.Any())
            {
                db.Homes.Add(new Home
                {
                   Address= "Bəhruz Nuriyev 20",
                   AnnounceType="Rent",
                   Period = "month",
                   Price=500,
                   Area="75",
                   RoomCount =3,
                   BathCount=1,
                   SellerName="Sabir",
                   Phone="055-245-45-45",
                   Description="Cox Qesek Evdir. Otur Yasa Evdir",
                   CategoryId=1,
                   CityId=1,
                   MetroId=1,
                   OwnerId=3,
                   Images = new[]
                    {
                        new HomeImage
                        {
                            Path="home-deatil-1.jpg"
                        },
                        new HomeImage
                        {
                            Path="home-deatil-2.jpg"

                        }
                        ,
                        new HomeImage
                        {
                            Path="home-deatil-3.jpg"
                        }
                    }
                });

                db.Homes.Add(new Home
                {
                    Address = "Eliyev 5",
                    AnnounceType = "Sale",
                    Price = 90000,
                    Area = "80",
                    RoomCount = 3,
                    BathCount = 1,
                    Phone = "055-799-76-35",
                    Description = "Çox az müddət yaşayış olub. Heç bir xərc tələb etmir",
                    CategoryId = 1,
                    CityId=1,
                    MetroId=2,
                    OwnerId = 6,
                    Images = new[]
                   {
                        new HomeImage
                        {
                            Path="home-deatil-3.jpg"
                        },
                        new HomeImage
                        {
                            Path="home-deatil-2.jpg"

                        }
                        ,
                        new HomeImage
                        {
                            Path="home-deatil-1.jpg"
                        }
                    }
                });

                db.Homes.Add(new Home
                {
                    Address = "Zaur Serifov 5",
                    AnnounceType = "Rent",
                    Period="month",
                    Price = 900,
                    Area = "150",
                    RoomCount = 5,
                    BathCount = 2,
                    AgentId = 7,
                    Phone = "055-620-99-99",
                    Description = "Çox az müddət yaşayış olub. Heç bir xərc tələb etmir",
                    CategoryId = 1,
                    CityId = 1,
                    MetroId = 3,
                    OwnerId = 8,
                    Images = new[]
                   {
                        new HomeImage
                        {
                            Path="home-deatil-3.jpg"
                        },
                        new HomeImage
                        {
                            Path="home-deatil-2.jpg"

                        }
                        ,
                        new HomeImage
                        {
                            Path="home-deatil-1.jpg"
                        }
                    }
                });

                db.SaveChanges();
            }
        }

    }
}

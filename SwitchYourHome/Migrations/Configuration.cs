namespace SwitchYourHome.Migrations
{
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SwitchYourHome.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SwitchYourHome.Data.AppDbContext context)
        {
            if (!context.Roles.Any())
            {
                this.CreateRole(context, "Admin");
                this.CreateRole(context, "User");
            }

            if (!context.Users.Any())
            {
                this.CreateUser("admin@admin.com", "Admin", "123", context);
                this.SetUserRole("admin@admin.com", "Admin", context);

                this.CreateUser("a@abv.com", "Adam", "111", context);
                this.SetUserRole("a@abv.com", "User", context);
            }

            if (context.Ads.Any())
            {
                return;
            }

            var user = context.Users.FirstOrDefault();

            if (user == null)
            {
                return;
            }

            context.Ads.Add(new Ad
            {
                Accommodates = 8,
                Available = "Available",
                Bathrooms = 2,
                Bedrooms = 4,
                Childrens = "Children are Wellcome",
                Description = "Lovely renovated 4 bedroom house at a small dike at the waterfront and next to the forest. Best of both worlds, living at the countryside and easy access to the city centre! The house is fully renovated and modernized last years with a nice (fenced) terrace at the front and at the waterside. At the groundfloor we have a spacious livingroom, which has a view at the forest at the front, and a view at the waterfront at the back. We have 2 fire places, one at the sitting area and one at the dining area, good for romantic evenings! With the double doors at the back you enter the big terrace directly at the waterfront. In the garden we have a large table and chairs for 6 persons and 2 comfortable loungebeds as well. In the summer you can swim in the clean water of the river. And do not worry for your kids, as we have 2 little ones ourselves the house and the waterfront are surrounded by a fence so you can sit back and relax, having a BBQ and enjoying the view. We have 2 bedrooms at the ground floor and 1 bedroom and 1 study/questroom at the first floor and its not a problem to arrange an extra bed as well. Our large bathroom with walk-in shower and bath is also at the groundfloor. The house has a garage for 1 car and a second parkingspot at our property. ",
                ImageUrl = "http://rentportlandhomes.com/wp-content/uploads/2014/08/Portland-Homes.jpg",
                Location = "Holland,Amsterdam",
                Pets = "Pets are Wellcome",
                Smoking = "No smoking",
                Title = "AMSTERDAM, house at the waterfront! ",
                OwnerId = user.Id

            });

            context.Ads.Add(new Ad
            {
                Accommodates = 8,
                Available = "Available",
                Bathrooms = 2,
                Bedrooms = 4,
                Childrens = "Children are Wellcome",
                Description = "Lovely renovated 4 bedroom house at a small dike at the waterfront and next to the forest. Best of both worlds, living at the countryside and easy access to the city centre! The house is fully renovated and modernized last years with a nice (fenced) terrace at the front and at the waterside. At the groundfloor we have a spacious livingroom, which has a view at the forest at the front, and a view at the waterfront at the back. We have 2 fire places, one at the sitting area and one at the dining area, good for romantic evenings! With the double doors at the back you enter the big terrace directly at the waterfront. In the garden we have a large table and chairs for 6 persons and 2 comfortable loungebeds as well. In the summer you can swim in the clean water of the river. And do not worry for your kids, as we have 2 little ones ourselves the house and the waterfront are surrounded by a fence so you can sit back and relax, having a BBQ and enjoying the view. We have 2 bedrooms at the ground floor and 1 bedroom and 1 study/questroom at the first floor and its not a problem to arrange an extra bed as well. Our large bathroom with walk-in shower and bath is also at the groundfloor. The house has a garage for 1 car and a second parkingspot at our property. ",
                ImageUrl = "http://rentportlandhomes.com/wp-content/uploads/2014/08/Portland-Homes.jpg",
                Location = "Holland,Amsterdam",
                Pets = "Pets are Wellcome",
                Smoking = "No smoking",
                Title = "AMSTERDAM, house at the waterfront! ",
                OwnerId = user.Id

            });

            context.Ads.Add(new Ad
            {
                Accommodates = 8,
                Available = "Available",
                Bathrooms = 2,
                Bedrooms = 4,
                Childrens = "Children are Wellcome",
                Description = "Lovely renovated 4 bedroom house at a small dike at the waterfront and next to the forest. Best of both worlds, living at the countryside and easy access to the city centre! The house is fully renovated and modernized last years with a nice (fenced) terrace at the front and at the waterside. At the groundfloor we have a spacious livingroom, which has a view at the forest at the front, and a view at the waterfront at the back. We have 2 fire places, one at the sitting area and one at the dining area, good for romantic evenings! With the double doors at the back you enter the big terrace directly at the waterfront. In the garden we have a large table and chairs for 6 persons and 2 comfortable loungebeds as well. In the summer you can swim in the clean water of the river. And do not worry for your kids, as we have 2 little ones ourselves the house and the waterfront are surrounded by a fence so you can sit back and relax, having a BBQ and enjoying the view. We have 2 bedrooms at the ground floor and 1 bedroom and 1 study/questroom at the first floor and its not a problem to arrange an extra bed as well. Our large bathroom with walk-in shower and bath is also at the groundfloor. The house has a garage for 1 car and a second parkingspot at our property. ",
                ImageUrl = "http://rentportlandhomes.com/wp-content/uploads/2014/08/Portland-Homes.jpg",
                Location = "Holland,Amsterdam",
                Pets = "Pets are Wellcome",
                Smoking = "No smoking",
                Title = "AMSTERDAM, house at the waterfront! ",
                OwnerId = user.Id

            });

            context.Ads.Add(new Ad
            {
                Accommodates = 8,
                Available = "Available",
                Bathrooms = 2,
                Bedrooms = 4,
                Childrens = "Children are Wellcome",
                Description = "Lovely renovated 4 bedroom house at a small dike at the waterfront and next to the forest. Best of both worlds, living at the countryside and easy access to the city centre! The house is fully renovated and modernized last years with a nice (fenced) terrace at the front and at the waterside. At the groundfloor we have a spacious livingroom, which has a view at the forest at the front, and a view at the waterfront at the back. We have 2 fire places, one at the sitting area and one at the dining area, good for romantic evenings! With the double doors at the back you enter the big terrace directly at the waterfront. In the garden we have a large table and chairs for 6 persons and 2 comfortable loungebeds as well. In the summer you can swim in the clean water of the river. And do not worry for your kids, as we have 2 little ones ourselves the house and the waterfront are surrounded by a fence so you can sit back and relax, having a BBQ and enjoying the view. We have 2 bedrooms at the ground floor and 1 bedroom and 1 study/questroom at the first floor and its not a problem to arrange an extra bed as well. Our large bathroom with walk-in shower and bath is also at the groundfloor. The house has a garage for 1 car and a second parkingspot at our property. ",
                ImageUrl = "http://rentportlandhomes.com/wp-content/uploads/2014/08/Portland-Homes.jpg",
                Location = "Holland,Amsterdam",
                Pets = "Pets are Wellcome",
                Smoking = "No smoking",
                Title = "AMSTERDAM, house at the waterfront! ",
                OwnerId = user.Id

            });

            context.Ads.Add(new Ad
            {
                Accommodates = 8,
                Available = "Available",
                Bathrooms = 2,
                Bedrooms = 4,
                Childrens = "Children are Wellcome",
                Description = "Lovely renovated 4 bedroom house at a small dike at the waterfront and next to the forest. Best of both worlds, living at the countryside and easy access to the city centre! The house is fully renovated and modernized last years with a nice (fenced) terrace at the front and at the waterside. At the groundfloor we have a spacious livingroom, which has a view at the forest at the front, and a view at the waterfront at the back. We have 2 fire places, one at the sitting area and one at the dining area, good for romantic evenings! With the double doors at the back you enter the big terrace directly at the waterfront. In the garden we have a large table and chairs for 6 persons and 2 comfortable loungebeds as well. In the summer you can swim in the clean water of the river. And do not worry for your kids, as we have 2 little ones ourselves the house and the waterfront are surrounded by a fence so you can sit back and relax, having a BBQ and enjoying the view. We have 2 bedrooms at the ground floor and 1 bedroom and 1 study/questroom at the first floor and its not a problem to arrange an extra bed as well. Our large bathroom with walk-in shower and bath is also at the groundfloor. The house has a garage for 1 car and a second parkingspot at our property. ",
                ImageUrl = "http://rentportlandhomes.com/wp-content/uploads/2014/08/Portland-Homes.jpg",
                Location = "Holland,Amsterdam",
                Pets = "Pets are Wellcome",
                Smoking = "No smoking",
                Title = "AMSTERDAM, house at the waterfront! ",
                OwnerId = user.Id

            });

            context.Ads.Add(new Ad
            {
                Accommodates = 8,
                Available = "Available",
                Bathrooms = 2,
                Bedrooms = 4,
                Childrens = "Children are Wellcome",
                Description = "Lovely renovated 4 bedroom house at a small dike at the waterfront and next to the forest. Best of both worlds, living at the countryside and easy access to the city centre! The house is fully renovated and modernized last years with a nice (fenced) terrace at the front and at the waterside. At the groundfloor we have a spacious livingroom, which has a view at the forest at the front, and a view at the waterfront at the back. We have 2 fire places, one at the sitting area and one at the dining area, good for romantic evenings! With the double doors at the back you enter the big terrace directly at the waterfront. In the garden we have a large table and chairs for 6 persons and 2 comfortable loungebeds as well. In the summer you can swim in the clean water of the river. And do not worry for your kids, as we have 2 little ones ourselves the house and the waterfront are surrounded by a fence so you can sit back and relax, having a BBQ and enjoying the view. We have 2 bedrooms at the ground floor and 1 bedroom and 1 study/questroom at the first floor and its not a problem to arrange an extra bed as well. Our large bathroom with walk-in shower and bath is also at the groundfloor. The house has a garage for 1 car and a second parkingspot at our property. ",
                ImageUrl = "http://rentportlandhomes.com/wp-content/uploads/2014/08/Portland-Homes.jpg",
                Location = "Holland,Amsterdam",
                Pets = "Pets are Wellcome",
                Smoking = "No smoking",
                Title = "AMSTERDAM, house at the waterfront! ",
                OwnerId = user.Id

            });

            context.Ads.Add(new Ad
            {
                Accommodates = 8,
                Available = "Available",
                Bathrooms = 2,
                Bedrooms = 4,
                Childrens = "Children are Wellcome",
                Description = "Lovely renovated 4 bedroom house at a small dike at the waterfront and next to the forest. Best of both worlds, living at the countryside and easy access to the city centre! The house is fully renovated and modernized last years with a nice (fenced) terrace at the front and at the waterside. At the groundfloor we have a spacious livingroom, which has a view at the forest at the front, and a view at the waterfront at the back. We have 2 fire places, one at the sitting area and one at the dining area, good for romantic evenings! With the double doors at the back you enter the big terrace directly at the waterfront. In the garden we have a large table and chairs for 6 persons and 2 comfortable loungebeds as well. In the summer you can swim in the clean water of the river. And do not worry for your kids, as we have 2 little ones ourselves the house and the waterfront are surrounded by a fence so you can sit back and relax, having a BBQ and enjoying the view. We have 2 bedrooms at the ground floor and 1 bedroom and 1 study/questroom at the first floor and its not a problem to arrange an extra bed as well. Our large bathroom with walk-in shower and bath is also at the groundfloor. The house has a garage for 1 car and a second parkingspot at our property. ",
                ImageUrl = "http://rentportlandhomes.com/wp-content/uploads/2014/08/Portland-Homes.jpg",
                Location = "Holland,Amsterdam",
                Pets = "Pets are Wellcome",
                Smoking = "No smoking",
                Title = "AMSTERDAM, house at the waterfront! ",
                OwnerId = user.Id

            });

            //context.Ads.Add(new Ad
            //{
            //    Accommodates = 20,
            //    Available = "Available",
            //    Bathrooms = 10,
            //    Bedrooms = 10,
            //    Childrens = "Children are Wellcome",
            //    Description = "Eversfield Manor is late Georgian style built in about 1805, set in about 30 acres garden and woodland, with stunning rural views across its own valley with a lake at the bottom, inside the house, we have completely renovated the kitchen in modern style with french door open to a newly built terrace. wood burners in sitting room and dining room. We also have a tennis court and wall garden with fruit trees and flowering bed.",
            //    ImageUrl = "http://rentportlandhomes.com/wp-content/uploads/2014/08/Portland-Homes.jpg",
            //    Location = "Saint Sulpice la Foret, France",
            //    Pets = "Pets are Wellcome",
            //    Smoking = "Smoking Allowed",
            //    Title = "10 bedrooms Manor house in 30 acres garden and woodland, tennis court ",
            //    OwnerId = user.Id

            //});

            //context.Ads.Add(new Ad
            //{
            //    Accommodates = 2,
            //    Available = "Available",
            //    Bathrooms = 1,
            //    Bedrooms = 1,
            //    Childrens = "Children are Wellcome",
            //    Description = "Our house is a Victorian, terraced, 4 storey town house, built in 1850, which has recently undergone a complete renovation, which took the best part of two years. The whole of the basement is given over to a state of the art kitchen, designed by Robert Timmons, recently voted Kitchen Designer of the Year. There is a dining area, and access to both front and back gardens. There are numerous spaces outside to sit and relax, depending on your mood and the position of the sun. On the next floor up, there is a living room, which runs the whole length of the house with large sash windows at either end. The room has been decorated with a 'seaside' theme and has a calm and light feel. On the first floor there is a bedroom facing south, again with large windows. There is a wonderfully comfortable bed handmade from wenge wood, and built in wardrobes, which give the room a Japanese feel. The mattress is king size and is hand made with 3500 pocket springs. Also on this floor, is the larger of the two bathrooms. This has a large bath big enough for two people, as well as a walk in shower. The whole room is clad in Italian stone. The attic floor has been decorated as a Morroccan 'souk' and can be used as an extra sitting room or a second bedroom. There are two single beds, which can be put together to make one very large double. A lovely space to spend the evening watching cable tv or dvd's. There are televisions and stereos in the other sitting areas, as well as both an iMac and a Mini Mac with 100 meg wireless broadband access, for your use. There is a Skype internet phone, which has been set up to contact other Skype users for free. A lot of time and effort has gone into the house and I guarantee you will enjoy your stay. A housekeeper comes once a week.",
            //    ImageUrl = "http://rentportlandhomes.com/wp-content/uploads/2014/08/Portland-Homes.jpg",
            //    Location = "London,England",
            //    Pets = "No Pets Allowed",
            //    Smoking = "No smoking",
            //    Title = "Beautifully restored Victorian house.",
            //    OwnerId = user.Id

            //});

            //context.Ads.Add(new Ad
            //{
            //    Accommodates = 4,
            //    Available = "Available",
            //    Bathrooms = 1,
            //    Bedrooms = 2,
            //    Childrens = "Children are Wellcome",
            //    Description = "Our apartment is about 200 sqm and contains a spacious living room with kitchen, TV corner, cabinet and bathroom on the first floor; 2 bedrooms and a bathroom on the second floor. You will enjoy the open spaces of the house as at the same time each separate part can provide you calm and relaxing moments. The house has a modern design and furniture and is completely comfortable to accommodate a 4 persons’ family or separate guests.There is wi-fi internet access. The open terrace is a roomy place where you can enjoy your morning coffee watching the sunrise over the sea. There is a small cozy terrace on the second floor, going out from master bedroom. The apartment is situated in a nice quarter of Varna town next to hotels and villas, just 5 minutes from the city center by car. Entering our house, you’ll be fascinated by the great view, covering 180o of the coast - beautiful houses, cape Galata and the sea. ",
            //    ImageUrl = "http://rentportlandhomes.com/wp-content/uploads/2014/08/Portland-Homes.jpg",
            //    Location = "Bulgaria,Varna",
            //    Pets = "Pets not Allowed",
            //    Smoking = "Smoking Allowed",
            //    Title = "VARNA, lovely apartment! ",
            //    OwnerId = user.Id

            //});

            //context.Ads.Add(new Ad
            //{
            //    Accommodates = 8,
            //    Available = "Available",
            //    Bathrooms = 5,
            //    Bedrooms = 5,
            //    Childrens = "Children are Wellcome",
            //    Description = "One acre property home at Portogalo Condominium at Angra dos Reis bay,with private tennis court, swimming pool, jacuzzi, volley ball and soccer lawn, tree house in atlantic forest, home theater, professional snooker table, table tennis, darts game, TVs, stereos, wireless Internet access, 4 suites, beautiful gardens, barbecue hut, native fruits, Marina, boating activities, fishing, snorkeling, trekking, waterfalls, with house maids and exclusive services.",
            //    ImageUrl = "http://rentportlandhomes.com/wp-content/uploads/2014/08/Portland-Homes.jpg",
            //    Location = "Rio de Janeiro, Brazil",
            //    Pets = "Pets are Wellcome",
            //    Smoking = "Smoking Allowed",
            //    Title = "Beach Villa swimming pool,gardens,house service boating, fishing",
            //    OwnerId = user.Id

            //});

            //context.Ads.Add(new Ad
            //{
            //    Accommodates = 8,
            //    Available = "Available",
            //    Bathrooms = 2,
            //    Bedrooms = 4,
            //    Childrens = "Children are Wellcome",
            //    Description = "Large family home on slopes of the Helderberg Mountain, Somerset West, overlooking False Bay, next to a nature reserve with hiking trails, indigenous fynbos and birds. 30 minutes drive on motorway from Cape Town. 10 minutes from the nearest beach. 5 minutes from world class shopping malls. Large swimming pool. Large 1 acre garden - wonderful for children. All modern amenities. Outdoor undercover braai (BBQ) . Huge patios on which to enjoy the wonderful view. Main bedroom en-suite bathroom. Additional family bathroom with jacuzzi bath. ",
            //    ImageUrl = "http://rentportlandhomes.com/wp-content/uploads/2014/08/Portland-Homes.jpg",
            //    Location = "Cape Town, South Africa ",
            //    Pets = "Pets not allowed",
            //    Smoking = "No smoking",
            //    Title = "Large family home next to nature reserve 30 mins from Cape Town ",
            //    OwnerId = user.Id

            //});
        }
        private void SetUserRole(string email, string role, SwitchYourHome.Data.AppDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var userId = context.Users.FirstOrDefault(u => u.Email.Equals(email)).Id;
            var result = userManager.AddToRole(userId, role);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateUser(string email, string fullName, string pass, SwitchYourHome.Data.AppDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            userManager.PasswordValidator = new PasswordValidator
            {
                RequireDigit = false,
                RequiredLength = 1,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
            };

            var user = new ApplicationUser()
            {
                Email = email,
                FullName = fullName,
                UserName = email,
            };

            var result = userManager.Create(user, pass);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateRole( SwitchYourHome.Data.AppDbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            var result = roleManager.Create(new IdentityRole(roleName));

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }
    }
}

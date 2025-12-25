using Microsoft.EntityFrameworkCore;
using RewindWebsite.Models;

namespace RewindWebsite.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        #region Tables
        public DbSet<Product> Products { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        #endregion
    }

    #region seeddata

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(
                serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }

                context.Products.AddRange(
                    new Product
                    {
                        name = "Truffle Almonds",
                        description = "Premium almonds coated in black truffle oil and sea salt",
                        price = 12.99m,
                        imageUrl = "/images/products/truffle-almonds.jpg",
                        category = "Nuts",
                        SEOKeywords = "truffle almonds, gourmet nuts, luxury snacks, premium almonds",
                        SEODescription = "Premium almonds coated in authentic black truffle oil and Himalayan sea salt",
                        isFeatured = true,
                        createdDate = DateTime.Now.AddDays(-10)
                    },
                    new Product
                    {
                        name = "Rosemary Sea Salt Crackers",
                        description = "Artisanal crackers with rosemary and Mediterranean sea salt",
                        price = 8.99m,
                        imageUrl = "/images/products/rosemary-crackers.jpg",
                        category = "Crackers",
                        SEOKeywords = "artisanal crackers, rosemary crackers, gourmet crackers",
                        SEODescription = "Handcrafted crackers infused with fresh rosemary and Mediterranean sea salt",
                        isFeatured = true,
                        createdDate = DateTime.Now.AddDays(-8)
                    },
                    new Product
                    {
                        name = "Dark Chocolate Cashews",
                        description = "Creamy cashews enrobed in rich 70% dark chocolate",
                        price = 15.99m,
                        imageUrl = "/images/products/chocolate-cashews.jpg",
                        category = "Chocolate",
                        SEOKeywords = "dark chocolate cashews, gourmet chocolate, premium nuts",
                        SEODescription = "Premium cashews coated in single-origin 70% dark chocolate",
                        isFeatured = true,
                        createdDate = DateTime.Now.AddDays(-5)
                    },
                    new Product
                    {
                        name = "Fig & Honey Bites",
                        description = "Organic figs stuffed with artisanal honey and walnuts",
                        price = 11.99m,
                        imageUrl = "/images/products/fig-bites.jpg",
                        category = "Fruit Snacks",
                        SEOKeywords = "fig snacks, honey bites, organic fruit snacks",
                        SEODescription = "Organic California figs stuffed with local honey and premium walnuts",
                        isFeatured = true,
                        createdDate = DateTime.Now.AddDays(-3)
                    }
                );

                context.TeamMembers.AddRange(
                    new TeamMember
                    {
                        name = "Sarah Chen",
                        position = "Head Chef & Flavor Director",
                        bio = "With 15 years in Michelin-starred kitchens, Sarah brings unparalleled expertise to snack creation.",
                        imageUrl = "/images/team/sarah-chen.jpg",
                        experienceYears = 15
                    },
                    new TeamMember
                    {
                        name = "Marcus Johnson",
                        position = "Quality Control Manager",
                        bio = "Marcus ensures every product meets our 5-star standards through rigorous testing protocols.",
                        imageUrl = "/images/team/marcus-johnson.jpg",
                        experienceYears = 12
                    },
                    new TeamMember
                    {
                        name = "Elena Rodriguez",
                        position = "Nutrition Specialist",
                        bio = "Elena balances flavor and nutrition, creating snacks that are both delicious and wholesome.",
                        imageUrl = "/images/team/elena-rodriguez.jpg",
                        experienceYears = 10
                    }
                );

                context.SaveChanges();
            }
        }
    }
    #endregion
}
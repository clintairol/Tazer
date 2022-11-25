using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using Tazer.Data;

namespace Tazer.Models
{
    public class Seed
    {
        public static void  Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TazerContext(serviceProvider.GetRequiredService<DbContextOptions<TazerContext>>()))
            {
                if (context.Tees.Any())
                {
                    return;
                }
                context.Tees.AddRange(
                    new Tees
                    {
                        Product = "Graphic Tee",
                        Quantity = 100,
                        Brand = "Adidas",
                        Color = "Red",
                        Design = "Adidas Logo",
                        Sizes = "S / M / XL / XXL",
                        Neckline = "Round",
                        Material = "Cotton",
                        Price = 2500.00,
                        Date = DateTime.Now

                    }

                    );
                context.SaveChanges();
            }
        }

    }
}

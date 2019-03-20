using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecisionAPI.Data
{
    public class DbSeeder
    {
        public static void SeedDb(ApplicationDbContext context)
        {
            SeedQuotes(context);

        }
        public static void SeedQuotes(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            context.Quotes.Add(
                new Models.Quote() { Id = 1, Title = "Master i Margarita", Author = "Bulgakov", Description = "The Master and Margarita (Russian: Мастер и Маргарита) is a novel by Russian writer Mikhail Bulgakov, written in the Soviet Union between 1928 and 1940." }

                );
            context.SaveChanges();
        }
    }
}

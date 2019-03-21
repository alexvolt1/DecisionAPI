using DecisionAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecisionAPI.Data.DbInitializers.QuoteInitializers
{
    public class QuoteInitializerConfiguration2 : IEntityTypeConfiguration<Quote2>
    {
        public void Configure(EntityTypeBuilder<Quote2> builder)
        {
            builder.Property(e => e.Id).IsRequired();

            var quotes = new Quote2[]
{
                new Quote2 { Id = 1, Title = "Master and Margarita", Author = "Bulgakov", Description = "The Master and Margarita (Russian: Мастер и Маргарита) is a novel by Russian writer Mikhail Bulgakov, written in the Soviet Union between 1928 and 1940." },
                new Quote2 { Id = 2, Title = "War and Peace ", Author = "Tolstoy", Description = "War and Peace is a novel by the Russian author Leo Tolstoy. It is regarded as a central work of world literature and one of Tolstoy's finest literary achievements." }
};
            builder.HasData(quotes);
        }

    }
}

﻿
using System;
using System.Linq;
using DecisionAPI.Data;
using DecisionAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DecisionAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            

            // Look for any students.
            if (context.Quotes.Any())
            {
                return;   // DB has been seeded
            }

            var quotes = new Quote[]
            {
                new Quote { Id = 1, Title = "Master and Margarita", Author = "Bulgakov", Description = "The Master and Margarita (Russian: Мастер и Маргарита) is a novel by Russian writer Mikhail Bulgakov, written in the Soviet Union between 1928 and 1940." },
                new Quote { Id = 2, Title = "War and Peace ", Author = "Tolstoy", Description = "War and Peace is a novel by the Russian author Leo Tolstoy. It is regarded as a central work of world literature and one of Tolstoy's finest literary achievements." }
            };

            foreach (Quote q in quotes)
            {
                context.Quotes.Add(q);
            }
            context.SaveChanges();

            context.Database.EnsureCreated();
        }
    }
}


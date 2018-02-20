﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BangazonWebApp.Data;
using BangazonWebApp.Models;
using BangazonWebApp.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BangazonWebApp.Data
{
    public static class DbInitializer
    {
        public async static void Initialize(ApplicationDbContext context)
        {

            context.Database.EnsureCreated();
            
                // Look for any products.
                if (context.ProductType.Any())
                {
                    return;   // DB has been seeded
                }

                // Create product types
               var productTypes = new ProductType[]
                {
                    new ProductType {
                        Name = "Electronics"
                    },
                    new ProductType {
                        Name = "Appliances"
                   },
                    new ProductType {
                        Name = "Housewares"
                   },
                };
                
               // Add the created product types
                foreach (ProductType i in productTypes)
                {
                    context.ProductType.Add(i);
                }

                context.SaveChanges();
            
        }
    }
}

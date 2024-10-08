﻿using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, CategoryId = 1, Title = "Introduction to Computer Science", Price = 75 },
                new Book { Id = 2, CategoryId = 2, Title = "Introduction to Computer Networks", Price = 175 },
                new Book { Id = 3, CategoryId = 1, Title = "Data Structures and Algorithms", Price = 275 }
                );
        }
    }

}

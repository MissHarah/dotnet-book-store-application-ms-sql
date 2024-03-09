﻿using Microsoft.EntityFrameworkCore;

namespace MyBookApp.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {

        }
        public DbSet<Book> Books{ get; set;}

        public DbSet<BookGallery> BookGallery { get; set; }

        public DbSet<Language> Languages {  get; set;} 
       
    }
}


using HappyTrees;
using HappyTrees.Models;
using System;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;


namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new NullDatabaseInitializer<PaintingContext>());
            InsertPainting();
            Console.ReadLine();
        }

        private static void InsertPainting()
        {
            var painting = new Painting
            {
                Title = "A Walk in the Woods",
                Season = 1,
                Episode = 1,
                Description = "The very first episode of 'The Joy of Painting' with Bob Ross.",
                ThumbnailFile = "~/Images/Thumbnails/S01E01.png",
                VideoURL = "https://www.youtube.com/embed/oh5p5f5_-7A",
            };
            using (var context=new PaintingContext())
            {
                Console.WriteLine(context.Database.CurrentTransaction);
                context.Paintings.Add(painting);
                context.SaveChanges();
            }
        }
    }
}

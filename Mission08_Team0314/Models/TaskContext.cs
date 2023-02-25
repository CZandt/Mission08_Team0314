using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_Team0314.Models
{
    public class TaskContext : DbContext
    {
        //Constructor class
        public TaskContext (DbContextOptions<TaskContext> options) : base (options)
        {

        }

        public DbSet<Task> tasks { get; set; }
        public DbSet<Category> categories { get; set; }


        //Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Seed data for different categories
            mb.Entity<Category>().HasData(
                new Category { CategoryID=1, CategoryName = "Home" },
                new Category { CategoryID=2, CategoryName = "School" },
                new Category { CategoryID=3, CategoryName = "Work" },
                new Category { CategoryID=4, CategoryName = "Church" }
            );

            //Seed tasks for each quadrant
            mb.Entity<Task>().HasData(
                new Task
                {
                    TaskID = 1,
                    TaskName = "Take 404 Test",
                    DueDate = new DateTime(2023, 2, 24),
                    Quadrant = 1,
                    CategoryID = 2, 
                    Completed = false
                },
                new Task
                {
                    TaskID = 2,
                    TaskName = "Study for 414 Test",
                    DueDate = new DateTime(2023, 2, 28),
                    Quadrant = 2,
                    CategoryID = 2,
                    Completed = false
                },
                new Task
                {
                    TaskID = 3,
                    TaskName = "Go to Vasa",
                    DueDate = new DateTime(2023, 2, 24),
                    Quadrant = 3,
                    CategoryID = 1,
                    Completed = false
                },
                new Task
                {
                    TaskID = 4,
                    TaskName = "Beat Hogwarts Legacy",
                    DueDate = new DateTime(2023, 12, 31),
                    Quadrant = 3,
                    CategoryID = 1,
                    Completed = false
                }
            );
        }
    }
}

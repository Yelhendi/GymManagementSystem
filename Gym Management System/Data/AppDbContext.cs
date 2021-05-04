using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.Data
{

    public class AppDbContext: DbContext
    {
        //Create constructor
        //constructor chaining 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Workout> Workouts { get; set; }

        //Enable Exercises 
        public DbSet<Exercise> Exercises{ get; set; }


    }
}


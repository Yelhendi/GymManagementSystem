using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.Models
{
    //Properties I want to collect
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string Type { get; set; }
     
        public Difficulty Difficulty { get; set; }
        public int Time { get; set; }
        public DateTime CreatedAt { get; set; }
        //Relationships
       

        //Link Workout to exercise

        public virtual List<Workout> Workouts { get; set; }

        
    }
    public enum Difficulty
    {
        Beginner = 1,
        Intermediate,
        Advanced
    }



}

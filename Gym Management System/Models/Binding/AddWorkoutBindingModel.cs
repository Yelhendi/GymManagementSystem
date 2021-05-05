using GymManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.Models.Binding
{
    public class AddWorkoutBindingModel
    {
        public int WorkoutId { get; set; }
        public string Type { get; set; }
     
        public Difficulty Difficulty { get; set; }
        public int Time { get; set; }
        public DateTime CreatedAt { get; set; }

        //Link ingredient to recipe 

        public virtual List<Workout> Workouts { get; set; }
    }
    public enum Difficulty
    {
        Beginner = 1,
        Intermediate,
        Advanced
    }



}

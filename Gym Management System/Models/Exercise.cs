using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.Models
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Picture  { get; set; }
        public int Sets { get; set; }
        public int Weight { get; set; }
        public Status Status { get; set; }


        //Connect workout and Exercises

        public virtual Workout Workout  { get; set; }
    }
    public enum Status 
    {
        Completed=1,
        Incomplete 
    }

    
}

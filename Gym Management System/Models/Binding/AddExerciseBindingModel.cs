using GymManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.Models.Binding
{
    public class AddExerciseBindingModel
    {
       
 
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public int Sets { get; set; }
        public int Weight { get; set; }
        public Status Status { get; set; }
        public int WorkoutId { get; set; }



        //Connect workout and exercises

        public virtual Workout Workout { get; set; }
    }


}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.Interfaces
{
    public interface IRepositoryWrapper
    {
        IExerciseRepository Exercises { get; }
        IWorkoutRepository Workouts { get; }
        void Save();
    }
}

using GymManagementSystem.Data;
using GymManagementSystem.Interfaces;
using GymManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        AppDbContext _repoContext; 
        public RepositoryWrapper(AppDbContext repoContext)
        {
            _repoContext = repoContext;
        }
        IExerciseRepository _Exercises;

        IWorkoutRepository _Workouts;


        public IExerciseRepository Exercises
        {
            get
            {
                if (_Exercises == null)
                {
                    _Exercises = new ExerciseRepository(_repoContext);
                }
                return _Exercises;
            }
        }
            

         public IWorkoutRepository Workouts
         {
            get
            {
                if (_Workouts == null)
                {
                    _Workouts = new WorkoutRepository(_repoContext);
                }
                return _Workouts;
            }
        }
        
        void IRepositoryWrapper.Save()
        {
            _repoContext.SaveChanges();
        }
    }
}

using GymManagementSystem.Data;
using GymManagementSystem.Models;
using GymManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.Interfaces
{
    public class WorkoutRepository : Repository<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(AppDbContext dbContext): base(dbContext)
        {

        }
    }
}

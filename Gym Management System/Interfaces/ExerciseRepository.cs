using GymManagementSystem.Data;
using GymManagementSystem.Models;
using GymManagementSystem.Repositories;

namespace GymManagementSystem.Interfaces
{
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}

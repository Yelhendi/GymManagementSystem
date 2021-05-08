using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GymManagementSystem.Models;
using GymManagementSystem.Data;
using GymManagementSystem.Models.Binding;
using GymManagementSystem.Interfaces;

namespace GymManagementSystem.Controllers
{
    [Route("[Controller]")]
    public class ExerciseController : Controller

    {
        //Inject applicationdb context readonly means it will not change
        //Create constructor
        //private readonly AppDbContext dbContext;
        private IRepositoryWrapper repository;
        public ExerciseController(/*AppDbContext appDbContext*/ IRepositoryWrapper repositoryWrapper)
        {
            //dbContext = appDbContext;
            repository = repositoryWrapper;
        }

        //READ
        [Route("")]

        public IActionResult Index()
        {
            var allExercises = repository.Exercises.FindAll();
           // var allExercises = dbContext.Exercises.ToList();
            return View(allExercises);
        }
        //Route is a placeholder that maps directly to what you are putting in
        [Route("details/{id:int}")]

        //Exercise Details
        //goes to get Exercise that has specific Id
        public IActionResult Details(int id)
        {
            var exerciseById = repository.Exercises.FindByCondition(w => w.ExerciseId == id).FirstOrDefault();
           // var exerciseById = dbContext.Exercises.FirstOrDefault(w => w.ExerciseId == id);
            return View(exerciseById);
        }

        ////add route

        [Route("update/{id:int}")]
        ////UPDATE remember to pass in id
        public IActionResult Update(int id)
        {
            var ExerciseById = repository.Exercises.FindByCondition(w => w.ExerciseId == id).FirstOrDefault();
            //var ExerciseById = dbContext.Exercises.FirstOrDefault(w => w.ExerciseId == id);
            return View(ExerciseById);
        }

        [HttpPost] //editing  data 
        [Route("update/{id:int}")]
        public IActionResult Update(Exercise exercise, int id)
        {
            var ExerciseToUpdate = repository.Exercises.FindByCondition(w => w.ExerciseId == id).FirstOrDefault();
            //var ExerciseToUpdate = dbContext.Exercises.FirstOrDefault(w => w.ExerciseId == id);
            ExerciseToUpdate.Name = exercise.Name;
            ExerciseToUpdate.Picture = exercise.Picture;
            ExerciseToUpdate.Sets = exercise.Sets;
            ExerciseToUpdate.Weight = exercise.Weight;
            ExerciseToUpdate.Status = exercise.Status;

            repository.Save();
            //dbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        //Delete
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var ExerciseToDelete = repository.Exercises.FindByCondition(w => w.ExerciseId == id).FirstOrDefault();
            //var ExerciseToDelete = dbContext.Exercises.FirstOrDefault(w => w.ExerciseId == id);
            repository.Exercises.Delete(ExerciseToDelete);
            //dbContext.Exercises.Remove(ExerciseToDelete);
            repository.Save();
            //dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

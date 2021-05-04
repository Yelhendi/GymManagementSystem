using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GymManagementSystem.Models;
using GymManagementSystem.Data;
using GymManagementSystem.Models.Binding;

namespace GymManagementSystem.Controllers
{
    [Route("[Controller]")]
    public class ExerciseController : Controller

    {
        //Inject applicationdb context readonly means it will not change
        //Create constructor
        private readonly AppDbContext dbContext;
        public ExerciseController(AppDbContext appDbContext)
        {
            dbContext = appDbContext;
        }

        //READ
        [Route("")]

        public IActionResult Index()
        {
            var allExercises = dbContext.Exercises.ToList();
            return View(allExercises);
        }
        //Route is a placeholder that maps directly to what you are putting in
        [Route("details/{id:int}")]

        //Exercise Details
        //goes to get Exercise that has specific Id
        public IActionResult Details(int id)
        {
            var exerciseById = dbContext.Exercises.FirstOrDefault(w => w.ExerciseId == id);
            return View(exerciseById);
        }

        //CREATE Exercise
        //make it create from form
        //public IActionResult CreateExercise()
        //{
        //    return View();
        //}
        //[HttpPost] //sending data 
        //public IActionResult Create(AddExerciseBindingModel bindingModel)
        //{
        //    var ExerciseToCreate = new Exercise
        //    {
        //        Name = bindingModel.Name,
        //        Picture = bindingModel.Picture,
        //        Sets = bindingModel.Sets,
        //        Weight = bindingModel.Weight,
        //        Status = (Models.Status)bindingModel.Status
        //};
        //    dbContext.Exercises.Add(ExerciseToCreate);
        //    //save changes
        //    dbContext.SaveChanges();
        //    //return to action
        //    return RedirectToAction("Index");
        //}

        ////add route

        [Route("update/{id:int}")]
        ////UPDATE remember to pass in id
        public IActionResult Update(int id)
        {
            var ExerciseById = dbContext.Exercises.FirstOrDefault(w => w.ExerciseId == id);
            return View(ExerciseById);
        }

        [HttpPost] //editing  data 
        [Route("update/{id:int}")]
        public IActionResult Update(Exercise exercise, int id)
        {
            var ExerciseToUpdate = dbContext.Exercises.FirstOrDefault(w => w.ExerciseId == id);
            ExerciseToUpdate.Name = exercise.Name;
            ExerciseToUpdate.Picture = exercise.Picture;
            ExerciseToUpdate.Sets = exercise.Sets;
            ExerciseToUpdate.Weight = exercise.Weight;
            ExerciseToUpdate.Status = exercise.Status;

            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        //Delete
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var ExerciseToDelete = dbContext.Exercises.FirstOrDefault(w => w.ExerciseId == id);
            dbContext.Exercises.Remove(ExerciseToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

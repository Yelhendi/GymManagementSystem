using GymManagementSystem.Data;
using GymManagementSystem.Models;
using GymManagementSystem.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymManagementSystem.Controllers
{
    [Route("[Controller]")]

    public class WorkoutController : Controller

    {
        //Inject applicationdb context readonly means it will not change
        //Create constructor
        private readonly AppDbContext dbContext;
        public WorkoutController(AppDbContext appDbContext)
        {
            dbContext = appDbContext;
        }
        //READ
        [Route("")]

        public IActionResult Index()
        {
            var allWorkouts = dbContext.Workouts.ToList();
            return View(allWorkouts);
        }
        //Route is a placeholder that maps directly to what you are putting in
        [Route("details/{id:int}")]

        //Workout Details
        //goes to get recipe that has specific Id
        public IActionResult Details(int id)
        {
            var workoutById = dbContext.Workouts.FirstOrDefault(w => w.WorkoutId == id);
            return View(workoutById);
        }

        //CREATE Workout
        //make it create from form
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")] //sending data 
        public IActionResult Create(AddWorkoutBindingModel bindingModel)
        {
            var workoutToCreate = new Workout
            {
                Type = bindingModel.Type,
                Difficulty = (Models.Difficulty)bindingModel.Difficulty,
                Time = bindingModel.Time,
                CreatedAt = DateTime.Now
            };

            dbContext.Workouts.Add(workoutToCreate);
            //save changes
            dbContext.SaveChanges();
            //return to action
            return RedirectToAction("Index");
        }

        //UPDATE

      
        [Route("update/{id:int}")]
        public IActionResult Update(int id)
        {
            var workoutById = dbContext.Workouts.FirstOrDefault(w => w.WorkoutId == id);
            return View(workoutById);
        }


        [HttpPost] //editing  data 
        [Route("update/{id:int}")]
        public IActionResult Update(Workout workout, int id)
        {
            var workoutToUpdate = dbContext.Workouts.FirstOrDefault(w=>w.WorkoutId == id );
            workoutToUpdate.Type = workout.Type;
            workoutToUpdate.Difficulty = workout.Difficulty;
            workoutToUpdate.Time = workout.Time;
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        //Delete
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var workoutToDelete = dbContext.Workouts.FirstOrDefault(w => w.WorkoutId == id);
            dbContext.Workouts.Remove(workoutToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        //Exercises

        ////CREATE Exercises 
        ////make it create from form
        ///
        [Route("addExercise/{WorkoutId:int}")]
        public IActionResult CreateExercise(int WorkoutId)
        {
            var Workout = dbContext.Workouts.FirstOrDefault(w => w.WorkoutId == WorkoutId);
            //return Exercise property 
            ViewBag.WorkoutType = Workout.Type;
            return View();
        }
        [HttpPost] //sending data 
        [Route("addExercise/{WorkoutId:int}")]
        public IActionResult CreateExercise(AddExerciseBindingModel bindingModel, int WorkoutId)
        {
            bindingModel.WorkoutId = WorkoutId;
            var ExerciseToCreate = new Exercise
            {
                Name = bindingModel.Name,
                Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTHgNMJAXVs5aU1iyPQxvD9UhKKB70qHp1Vbg&usqp=CAU",
                Sets = bindingModel.Sets,
                Weight = bindingModel.Weight,
                Status = (Models.Status)bindingModel.Status,
                //Recipe mapped to that will be 
                Workout = dbContext.Workouts.FirstOrDefault(w => w.WorkoutId == WorkoutId),

            };
            dbContext.Exercises.Add(ExerciseToCreate);
            //save changes
            dbContext.SaveChanges();
            //return to action
            return RedirectToAction("Index");
        }
        //[Route("{id:int}/Exercises")]
        //update
       
        [HttpPost] //sending data 
        [Route("addExercises/{WorkoutId:int}")]
        public IActionResult CreateExercises(AddExerciseBindingModel bindingModel, int WorkoutId)
        {
            bindingModel.WorkoutId = WorkoutId;
            var ExerciseToCreate = new Exercise
            {
                Name = bindingModel.Name,
                Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTHgNMJAXVs5aU1iyPQxvD9UhKKB70qHp1Vbg&usqp=CAU",
                Sets = bindingModel.Sets,
                Weight = bindingModel.Weight,
                Status = (Models.Status)bindingModel.Status,
                //Recipe mapped to that will be 
                Workout = dbContext.Workouts.FirstOrDefault(w => w.WorkoutId == WorkoutId),

            };
            dbContext.Exercises.Add(ExerciseToCreate);
            //save changes
            dbContext.SaveChanges();
            //return to action
            return RedirectToAction("Index");
        }
        [Route("{id:int}/Exercises")]
        public IActionResult ViewExercise(int id)
        {
            var Workouts = dbContext.Workouts.FirstOrDefault(w => w.WorkoutId == id);
            var Exercises = dbContext.Exercises.Where(w => w.Workout.WorkoutId == id).ToList();
            ViewBag.WorkoutType = Workouts.Type;
            return View(Exercises);

        }
        
        //[Route("addvisit/{workoutId:int}")]
        //public IActionResult CreateVisit(int workoutID)
        //{
        //    var workout = dbContext.Workouts.FirstOrDefault(w => w.WorkoutId == workoutID);
        //    ViewBag.WorkoutType = workout.Type;

        //    var pageInject = new AddVisitBindingModel { Vets = dbContext.Vets.ToList().GetViewModels() };
        //    return View(pageInject);
        //}
    }
}

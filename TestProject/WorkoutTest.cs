using GymManagementSystem.Controllers;
using GymManagementSystem.Interfaces;
using GymManagementSystem.Models;
using GymManagementSystem.Models.Binding;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestProject
{

    public class WorkoutTest

    {
        private WorkoutController WorkoutController;
        private ExerciseController ExerciseController;
        private readonly Mock<IRepositoryWrapper> mockRepo;
        private AddWorkoutBindingModel addWorkout;
        private AddExerciseBindingModel addExercise;

        public WorkoutTest()
        { 
         //sample models
            addWorkout = new AddWorkoutBindingModel { WorkoutId = 1, Type = "Legs", Difficulty = Difficulty.Intermediate, Time = 20 };
            addExercise = new AddExerciseBindingModel { ExerciseId = 1, Name = "Squats", Picture = "https://cdn.thespaces.com/wp-content/uploads/2020/01/Gymshark-hero-crop.jpg", Sets = 20, Weight = 20, Status = Status.Completed };
            mockRepo = new Mock<IRepositoryWrapper>();
            WorkoutController = new WorkoutController(mockRepo.Object);
            ExerciseController = new ExerciseController(mockRepo.Object);

        }
      
        [Fact]
        public void GetAllWorkouts_Test()
        {
            //Arrange
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.Workouts.FindAll()).Returns(GetWorkouts);
            //Act
            var controllerActionResult = WorkoutController.Index();
            //Assert
            Assert.NotNull(controllerActionResult);
        }

        private IEnumerable<Workout> GetWorkouts()
        {
            var Workout = new List<Workout>
            {
             new Workout(){WorkoutId = 1,
             Type = "Legs",
             Difficulty = Difficulty.Beginner,
             Time = 20 },
             new Workout(){WorkoutId = 2,
             Type = "Chest",
             Difficulty = Difficulty.Advanced,
             Time = 20 }
            };
            return Workout;
        }
        private Workout GetWorkout()
        {
            return GetWorkouts().ToList()[0];
        }

        [Fact]
        public void AddWorkout_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Workouts.FindByCondition(w => w.WorkoutId == It.IsAny<int>())).Returns(GetWorkouts());
            //Act
            var controllerActionResult = WorkoutController.Create(addWorkout);
            //Assert
            Assert.NotNull(controllerActionResult);
            //Assert.IsType<ActionResult<WorkoutViewModel>>(controllerActionResult);
        }
        [Fact]
        public void UpdateWorkouts_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Workouts.FindByCondition(w => w.WorkoutId == It.IsAny<int>())).Returns(GetWorkouts());
            mockRepo.Setup(repo => repo.Workouts.Update(GetWorkout()));
            //Act
            var controllerActionResult = new WorkoutController(mockRepo.Object).Update(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }
        [Fact]
        public void DeleteWorkouts_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Workouts.FindByCondition(w => w.WorkoutId == It.IsAny<int>())).Returns(GetWorkouts());
            mockRepo.Setup(repo => repo.Workouts.Delete(GetWorkout()));
            //Act
            var controllerActionResult = new WorkoutController(mockRepo.Object).Delete(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }
        [Fact]
        public void UpdateExercises_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Exercises.FindByCondition(w => w.ExerciseId == It.IsAny<int>())).Returns(GetExercises());
            mockRepo.Setup(repo => repo.Exercises.Update(GetExercise()));
            //Act
            var controllerActionResult = new ExerciseController(mockRepo.Object).Update(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }
        [Fact]
        public void DeleteExercises_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.Exercises.FindByCondition(w => w.ExerciseId == It.IsAny<int>())).Returns(GetExercises());
            mockRepo.Setup(repo => repo.Exercises.Delete(GetExercise()));
            //Act
            var controllerActionResult = new ExerciseController(mockRepo.Object).Delete(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }
        [Fact]
        public void GetAllExercises_Test()
        {
            //Arrange
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.Exercises.FindAll()).Returns(GetExercises);
            //Act
            var controllerActionResult = ExerciseController.Index();
            //Assert
            Assert.NotNull(controllerActionResult);

        }

        private IEnumerable<Exercise> GetExercises()
        {
            var Exercise = new List<Exercise>
            {
                new Exercise(){ExerciseId = 1,
                Name = "Squats",
                Picture = "https://cdn.thespaces.com/wp-content/uploads/2020/01/Gymshark-hero-crop.jpg",
                Sets = 20,
                Weight = 20,
                Status = GymManagementSystem.Models.Status.Completed },
                new Exercise(){ExerciseId = 2,
                Name = "Legs",
                Picture = "https://cdn.thespaces.com/wp-content/uploads/2020/01/Gymshark-hero-crop.jpg",
                Sets = 10,
                Weight = 20,
                Status = GymManagementSystem.Models.Status.Completed },
            };
            return Exercise;
        }
        private Exercise GetExercise()
        {
            return GetExercises().ToList()[0];
        }

    }
}
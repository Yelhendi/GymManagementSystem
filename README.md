# Gym Managment System 
> This is a simple gym tracker app made using C#, ASP.Net and SQL.

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Architecture](#architecture)
   * [Project Tracking](#project-tracking)
* [Risk assessment](#risk-assessment)
* [Coverage Report](#coverage-report)
* [Setup](#setup)
* [Deployment](#deployment)
* [Features](#features)
* [Status](#status)
* [Contact](#contact)

## General info
This project main objective was to create a CRUD application that utilises the tools and technologies learnt througout my QA training. My overall motivation for this project was based on my love of the gym. I wanted an app where I was able to manage my workouts on a daily bases.

## Technologies
* C# - version 9.0
* MySQL - version 5.0.0
* ASP.NET- version 5.0.5

## Architecture 
### Database structure
The Image below shows an Entity Relationship Diagram(ERD) with a many-to-many relationship between workouts and exercises. This means the the user can create workouts and add many exercises to the database with only one workout type. When observing this the other way, many workouts can be associated with one exercise. The diagram shows everything that has been implemented into my SQL database.

![image](https://user-images.githubusercontent.com/64641730/117540080-55752e00-b005-11eb-874c-15e2a7a227eb.png)

## Project Tracking
A trello board was used for the project management side of this project. This board shows everything that has been implimneted into the project from Epics to Testing.
The board consits of Epics which are broken down into corresponsing user stroies which outline the requirments of the epics. The user stories are broken down into tasks which are placed into the backlog, these tasks underpin all the technical aspects of the user stories. The board is colour-coded which is used link the Epics to User stroies and to tasks. Below shows a detailed explanation of what each section means.

![image](https://user-images.githubusercontent.com/64641730/117541211-b6533500-b00a-11eb-9822-df368b20b108.png)

* Epics Encompase a vague feature or addition which is made up of several user stroies.
* User Stories These are non-technical features that explain how the user uses the features.This keeps the development process user focused and puts the user experience first. 
* Tasks These are the technical steps which are required  for the user stories. 
* Backlog  This is a collection of items or products which need to be done.
* Testing This out lines all the code testing that needs to be done in order to produce a coverage report. The functionality of the test will be tested.
* To do These are the tasks that need to be done. These will be taken from the backlog and when put in progress these will be the tasks that will be put into focus.
* Doing Once I have began writing code this means that the task is in progress.
* Done Once the code has been considered and carries out its function it is placed in the done list.

## Risk Assessment 
The screen shot below shows the risk assessment of the app, possible risks that could occur to the user of the app. The risk assessment contains the risks, liklihood,severity,control measures and revisits.

![image](https://user-images.githubusercontent.com/64641730/117568563-e0633080-b0b8-11eb-9888-40c24e205868.png)

## Coverage Report
The screen shot below shows the converage report of my app. The coverage is 4.4% this is significantly low than the value which was required. The tests consisted of repository testing and MOQ testing. The controllers were tested this included the delete, update, details and view. Integration testing was used to test the features of the code. This allows us to test the main CRUD features in sequence and requires no data dependencies which means this test can be run against a blank database, the data it needs will be constructed through assertions.

To improve the coverage report I would have to remove dead or unreachable code. 

![image](https://user-images.githubusercontent.com/64641730/117569882-a3e70300-b0bf-11eb-805c-2190318d01f3.png)

The exercise controller shows that the following buttons worked which were, index, Update and delete however the details button was not working. 

![image](https://user-images.githubusercontent.com/64641730/117620637-92a60100-b168-11eb-920f-49f1a1633ed6.png)

The Workout controller shows that after undergoing testing the test for details and create did not work.

![image](https://user-images.githubusercontent.com/64641730/117621015-08aa6800-b169-11eb-8d98-6070daecec1b.png)

## Deployment
The app was deployed by creating a web app service on Microsoft Azure. This was then connected to GitHub. The link to the website is: https://gymwebapp.azurewebsites.net 


## Setup
To use the website firstly load the homepage. The homepage contains the two buttons these are create workout and view workouts. Firstly click on create workouts.
![image](https://user-images.githubusercontent.com/64641730/117573028-b36d4880-b0cd-11eb-9415-fa08a4df39cb.png)

Once the button is clicked fill in the form to include all the details of your workout. Click save once done.
![image](https://user-images.githubusercontent.com/64641730/117573119-21b20b00-b0ce-11eb-8e33-62133dacaa97.png)

Once saved it will take you to an Index page. This page shows you the workout you have just inputted.
![image](https://user-images.githubusercontent.com/64641730/117573160-5d4cd500-b0ce-11eb-937f-c814405a83dd.png)

Click on Add exercise to add an exercise for the workout and input data into this form.
![image](https://user-images.githubusercontent.com/64641730/117573219-91c09100-b0ce-11eb-8896-625b2d6b5680.png)

This will take you to the index page where you are able to view your exercises.
![image](https://user-images.githubusercontent.com/64641730/117573267-dc420d80-b0ce-11eb-855f-ce993917bcba.png)

You are able to click the delete button to remove the exercise. There is also the delete button on the workout list that enables you to delete the workout. 
The edit button allows you to update the data you have inputted. 

## Code Examples
Show examples of usage:
* This code shows is to enable the create function for workouts.

`       


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

            repository.Workouts.Create(workoutToCreate);
            repository.Save();
            return RedirectToAction("Index");
        }  
  `
   
        

## Features
List of the main features ready and TODOs for future development
* Add a workout and create a wokout, you input the type of workout, time and difficulty.
* Create a Exercise, you can add an exercise to the workout, by clicking the add exercise button. You can add the Name, picture, sets, weight and status.
* Update a Exercise, you can click on edit to update the exercise button.
* View all Exercises, this allows you to view the list of exercises associated with the workouts.
* Delete a Exercise , you are able to delete an exercise from the workout.

To-do list:
* Add a workout and for it to randomly generates an exercise 
* For it to contain videos on how to do certain exercises 
* To contain a search bar where you can search the website
* To contain a log in system where users can make an account
* To contain a location system to give you gyms that are near you in the area.
* Change the layout of the website to make it more visually appealing

## Status
Project is: _in progress_ as I want to try and add on extra features to imporve the project.

## Contact
Created by [@Yelhendi] - feel free to contact me!

# Gym Managment System 
> This is a simple gym tracker app made using C#, ASP.Net and SQL.

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Architecture](#Architecture)
* [Database structure](#Database structure)
* [Project Tracking](#Project Tracking)
* [Risk Assessment](#Risk Assessment)
* [Setup](#setup)
* [Features](#features)
* [Status](#status)
* [Contact](#contact)

## General info
This project main objective was to create a CRUD application that utilises the tools and technologies learnt througout my QA training. My overall motivation for this project was based on my love of the gym. I wanted an app where I was able to manage my workouts on a daily bases.

## Technologies
* C# - version 9.0
* MySQL - version 5.0.0
* ASP.NET- version 5.0.5

### Architecture 
### Database structure
The Image below shows an Entity Relationship Diagram(ERD) with a many-to-many relationship between workouts and exercises. This means the the user can create workouts and add many exercises to the database with only one workout type. When observing this the other way, many workouts can be associated with one exercise. The diagram shows everything that has been implemented into my SQL database.


![image](https://user-images.githubusercontent.com/64641730/117540080-55752e00-b005-11eb-874c-15e2a7a227eb.png)

## Project Tracking
A trello board was used for the project management side of this project. This board shows everything that has been implimneted into the project from Epics to Testing.
The board consits of Epics which are broken down into corresponsing user stroies which outline the requirments of the epics. The user stories are broken down into tasks which are placed into the backlog, these tasks underpin all the technical aspects of the user stories. The board is colour-coded which is used link the Epics to User stroies and to tasks. Below shows a detailed explanation of what each section means.

![image](https://user-images.githubusercontent.com/64641730/117541211-b6533500-b00a-11eb-9822-df368b20b108.png)

*Epics Encompase a vague feature or addition which is made up of several user stroies.
*User Stories These are non-technical features that explain how the user uses the features.This keeps the development process user focused and puts the user experience first. 
*Tasks These are the technical steps which are required  for the user stories. 
*Backlog  This is a collection of items or products which need to be done.
*Testing This out lines all the code testing that needs to be done in order to produce a coverage report. The functionality of the test will be tested.
*To do These are the tasks that need to be done. These will be taken from the backlog and when put in progress these will be the tasks that will be put into focus.
*Doing Once I have began writing code this means that the task is in progress.
*Done Once the code has been considered and carries out its function it is placed in the done list.

## Risk Assessment 
The screen shot below shows the risk assessment of the app, possible risks that could occur to the user of the app. The risk assessment contains the risks, liklihood,severity,control measures and revisits.

![image](https://user-images.githubusercontent.com/64641730/117568563-e0633080-b0b8-11eb-9888-40c24e205868.png)

## Setup
Describe how to install / setup your local environement / add link to demo version.

## Code Examples
Show examples of usage:
`put-your-code-here`

## Features
List of the main features ready and TODOs for future development
* Add a workout and create a wokout, you input the type of workout, time and difficulty.
* Create a Exercise, you can add an exercise to the workout, by clicking the add exercise button. You can add the Name, picture, sets, weight and status.
* Update a Exercise, you can click on edit to update the exercise button.
* View all Exercises, this allows you to view the list of exercises associated with the workouts.
* Delete a Exercise , you are able to delete an exercise from the workout.

To-do list:
* Add a workout and for it to randomly generate an exercise 
* For it to contain videos on how to do certain exercises 
* To contain a search bar where you can search the website

## Status
Project is: _in progress_ as I want to try and add on extra features to imporve the project.

## Contact
Created by [@Yelhendi] - feel free to contact me!

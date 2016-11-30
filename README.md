# Agile Scrum Manager

Web app for managing software projects in an Agile way using the Scrum methodology.
Built this in 2014 for my Bachelor's thesis in Computer Science

##Agile & Scrum
<a href="https://www.wikiwand.com/en/Agile_software_development">Agile software development</a> describes a set of principles for software development under which requirements and solutions evolve through the collaborative effort of self-organizing cross-functional teams. It advocates adaptive planning, evolutionary development, early delivery, and continuous improvement, and it encourages rapid and flexible response to change.

<a href="https://www.wikiwand.com/en/Scrum_(software_development)">Scrum</a> is an iterative and incremental agile software development framework for managing product development. It defines "a flexible, holistic product development strategy where a development team works as a unit to reach a common goal", challenges assumptions of the "traditional, sequential approach" to product development, and enables teams to self-organize by encouraging physical co-location or close online collaboration of all team members, as well as daily face-to-face communication among all team members and disciplines involved.

![Sprint cycle](readme-images/sprint-cycle.png?raw=true "Sprint cycle")

##Web app architecture
![Architecture](readme-images/architecture-diagram.jpg?raw=true "Architecture")

##Built with
 - Frontend:
   - Razor
   - Angular.js
   - Bootstrap
   - <a href="https://startbootstrap.com/template-overviews/sb-admin-2/">SB Admin 2 Template</a>
   - <a href="http://morrisjs.github.io/morris.js/">Morris.js</a> for charts

 - Backend
  - ASP.NET MVC
  - ASP.NET Web API
  - C#
  - Entity Framework code first
  
 - DB
  - Local SQL

##Design patterns
 - MVC
 - Repository

##Roles

 - Product Owner
  - Create sprint
  - Cancel sprint
  - Add task to Sprint/Backlog
  - Edit task
  - Search for task
  - Add comments to task
  
 - Team member
  - Add task to Backlog
  - Edit task
  - Search for task
  - Assign and work on task
  - Add comments to task
  
 - Team Leader
  - Add task to Sprint/Backlog
  - Edit task
  - Search for task
  - Assign and work on task
  - Add comments to task
  
 - Admin
  - Send email invites for registration
  - Create and assign products
  - Create and assign teams
  - Assign Product Owners and Team leaders

##Features

# msa2024-phase-2
Kevin Cheung's MSA 2024 Software Stream Phase 2 Project

The main motivation behind my project is my dislike on Canvas, the course management tool that lecturer's at The University of Auckland use. I think most of it is pretty good, but for tracking courses over my semesters here, I wanted more control. So I started to develop this project, CourseTrace, for tracking your semesters, courses, and assignments while attending university. 

The main thing I'm proud of with this project is the handling of M:N relationships between semesters and courses. At first, I thought it would be easier to make it a 1:N relationship because courses are generally always confined to one semester, but I wanted the challenge of handling courses that can sometimes span a full year with multiple semesters. This made me rethink my models, especially in how data was passed around the backend and returned to the frontend, as I had to then deal with the problem of preventing object cycles.

This project uses ASP.NET for the backend, with EF Core as the ORM, persisting data in a Azure SQL Database. It implements CRUD operations, which can be accessed in the frontend, a React Typescript project. The frontend uses MUI as its styling library, and is responsive to different screen sizes. It also uses React Router for routing, has switching between dark/light mode, and Git has been used throughout (pull requests, branches). 

The frontend is also not currently complete. Due to personal circumstances, I wasn't able to finish the frontend and properly integrate it with the backend. My progress is documented in the demo.

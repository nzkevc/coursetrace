using Microsoft.EntityFrameworkCore;
using Models;

public static class CoursesSeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Semester>().HasData(
            new Semester { Id = 1, Name = "Sem 1 2021", Year = 2021 },
            new Semester { Id = 2, Name = "Sem 2 2021", Year = 2021 },
            new Semester { Id = 3, Name = "Sem 1 2022", Year = 2022 }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, Name = "Course 1" },
            new Course { Id = 2, Name = "Course 2" },
            new Course { Id = 3, Name = "Course 3" },
            new Course { Id = 4, Name = "Course 4" },
            new Course { Id = 5, Name = "Course 5" },
            new Course { Id = 6, Name = "Course 6" }
        );

        modelBuilder.Entity("CourseSemester").HasData(
            new { CoursesId = 1, SemestersId = 1 },
            new { CoursesId = 2, SemestersId = 1 },
            new { CoursesId = 1, SemestersId = 2 },
            new { CoursesId = 3, SemestersId = 2 },
            new { CoursesId = 4, SemestersId = 3 },
            new { CoursesId = 5, SemestersId = 3 }
        );

        // TODO: add the other assignment fields so I can test
        modelBuilder.Entity<Assignment>().HasData(
            new Assignment { Id = 1, Name = "Assignment 1", CourseId = 1 },
            new Assignment { Id = 2, Name = "Assignment 2", CourseId = 1 },
            new Assignment { Id = 3, Name = "Assignment 3", CourseId = 2 },
            new Assignment { Id = 4, Name = "Assignment 4", CourseId = 3 },
            new Assignment { Id = 5, Name = "Assignment 5", CourseId = 4 },
            new Assignment { Id = 6, Name = "Assignment 6", CourseId = 5 }
        );
    }
}
import { CourseAssignmentDto } from "./Assignments";
import { CourseSemesterDto } from "./Semesters";

export interface CourseDto {
  Id: number;
  Name: string;
  Semesters: CourseSemesterDto[];
  Assignments: CourseAssignmentDto[];
}

export interface CoursePostDto {
  Name: string;
  SemesterIds: number[];
}

export interface AssignmentCourseDto {
  Id: number;
  Name: string;
  Semesters: CourseSemesterDto[];
}

import { AssignmentCourseDto } from "./Courses";

export interface AssignmentDto {
  Id: number;
  Name: string;
  Score: number;
  MaxScore: number;
  Weighting: number;
  DueDate: Date;
  CourseId: number;
  Course: AssignmentCourseDto;
}

export interface AssignmentPostDto {
  Name: string;
  Score: number;
  MaxScore: number;
  Weighting: number;
  DueDate: Date;
  CourseId: number;
}

export interface CourseAssignmentDto {
  Id: number;
  Name: string;
  Score: number;
  MaxScore: number;
  Weighting: number;
  DueDate: Date;
}

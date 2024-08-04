import { CourseDto } from "./Courses";

export interface SemesterDto {
  Id: number;
  Name: string;
  Year: number;
  Courses: CourseDto[];
}

export interface SemesterPostDto {
  Name: string;
  Year: number;
  CourseIds?: number[];
}

export interface CourseSemesterDto {
  Id: number;
  Name: string;
  Year: number;
}

import { CourseDto, CoursePostDto } from "../types/Courses";
import config from "./apiConfig";

const { courseApiUrl } = config;

export const getCourses = async (): Promise<CourseDto[]> => {
  const response = await fetch(courseApiUrl);
  const data = await response.json();
  return data;
};

export const getCourse = async (id: number): Promise<CourseDto> => {
  const response = await fetch(`${courseApiUrl}/${id}`);
  const data = await response.json();
  return data;
};

export const createCourse = async (
  course: CoursePostDto
): Promise<CourseDto> => {
  const response = await fetch(courseApiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(course),
  });
  const data = await response.json();
  return data;
};

export const updateCourse = async (
  id: number,
  course: CoursePostDto
): Promise<void> => {
  await fetch(`${courseApiUrl}/${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(course),
  });
};

export const deleteCourse = async (id: number): Promise<void> => {
  await fetch(`${courseApiUrl}/${id}`, {
    method: "DELETE",
  });
};

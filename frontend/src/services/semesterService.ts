import { SemesterDto, SemesterPostDto } from "../types/Semesters";
import config from "./apiConfig";

const { semesterApiUrl } = config;

export const getSemesters = async (): Promise<SemesterDto[]> => {
  const response = await fetch(semesterApiUrl);
  const data = await response.json();
  return data;
};

export const getSemester = async (id: number): Promise<SemesterDto> => {
  const response = await fetch(`${semesterApiUrl}/${id}`);
  const data = await response.json();
  return data;
};

export const createSemester = async (
  semester: SemesterPostDto
): Promise<SemesterDto> => {
  const response = await fetch(semesterApiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(semester),
  });
  const data = await response.json();
  return data;
};

// TODO: do we need the returned status code?
export const updateSemester = async (
  id: number,
  semester: SemesterPostDto
): Promise<void> => {
  await fetch(`${semesterApiUrl}/${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(semester),
  });
};

export const deleteStudent = async (id: number): Promise<void> => {
  await fetch(`${semesterApiUrl}/${id}`, {
    method: "DELETE",
  });
};

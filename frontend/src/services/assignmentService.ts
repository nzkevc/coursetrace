import { AssignmentDto, AssignmentPostDto } from "../types/Assignments";
import config from "./apiConfig";

const { assignmentApiUrl } = config;

export const getAssignments = async (): Promise<AssignmentDto[]> => {
  const response = await fetch(assignmentApiUrl);
  const data = await response.json();
  return data;
};

export const getAssignment = async (id: number): Promise<AssignmentDto> => {
  const response = await fetch(`${assignmentApiUrl}/${id}`);
  const data = await response.json();
  return data;
};

export const createAssignment = async (
  assignment: AssignmentPostDto
): Promise<AssignmentDto> => {
  const response = await fetch(assignmentApiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(assignment),
  });
  const data = await response.json();
  return data;
};

export const updateAssignment = async (
  id: number,
  assignment: AssignmentPostDto
): Promise<void> => {
  await fetch(`${assignmentApiUrl}/${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(assignment),
  });
};

export const deleteAssignment = async (id: number): Promise<void> => {
  await fetch(`${assignmentApiUrl}/${id}`, {
    method: "DELETE",
  });
};

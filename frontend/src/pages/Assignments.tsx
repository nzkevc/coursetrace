import { useEffect, useState } from "react";
import { Container } from "@mui/material";
import { AssignmentDto } from "../types/Assignments";
import { getAssignments } from "../services/assignmentService";
import { ContainerButton } from "../components/ContainerButton";

export default function Assignments() {
  const [assignments, setAssignments] = useState<AssignmentDto[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const [isFormOpen, setIsFormOpen] = useState(false);

  const fetchAssignments = async () => {
    try {
      const data = await getAssignments();
      console.log(data);
      setAssignments(data);
      setLoading(false);
    } catch (err) {
      setError("Failed to fetch assignments, check if server is running.");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchAssignments();
  }, []);

  return (
    <Container>
      <h1>Assignments</h1>
      <ContainerButton label="Add Assignment" action={setIsFormOpen} />
    </Container>
  );
}

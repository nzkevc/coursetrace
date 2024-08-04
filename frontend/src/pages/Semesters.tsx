import { Box, Button, Container, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { SemesterDto, SemesterPostDto } from "../types/Semesters";
import { createSemester, getSemesters } from "../services/semesterService";
import SemesterDataGrid from "../components/SemesterDataGrid";
import AddSemesterForm from "../components/AddSemesterForm";
import { ContainerButton } from "../components/ContainerButton";

export default function Semesters() {
  const [semesters, setSemesters] = useState<SemesterDto[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const [isFormOpen, setIsFormOpen] = useState(false);

  const fetchSemesters = async () => {
    try {
      const data = await getSemesters();
      console.log(data);
      setSemesters(data);
      setLoading(false);
    } catch (err) {
      setError("Failed to fetch semesters, check if server is running.");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchSemesters();
  }, []);

  const handleAddSemester = async (semester: SemesterPostDto) => {
    try {
      const newSemester = await createSemester(semester);
      setSemesters((prev) => [...prev, newSemester]);
      setIsFormOpen(false);
    } catch (err) {
      setError("Failed to add semester");
    }
  };

  return (
    <Container>
      <h1>Semesters</h1>
      <Box mb={2}>
        <ContainerButton label="Add Semester" action={setIsFormOpen} />
        {/* <SemesterDataGrid
          semesters={semesters}
          setSemesters={setSemesters}
          loading={loading}
          error={error}
        /> */}
      </Box>
      <AddSemesterForm
        open={isFormOpen}
        onClose={() => setIsFormOpen(false)}
        onAddSemester={handleAddSemester}
      />
    </Container>
  );
}

import { useEffect, useState } from "react";
import { Container } from "@mui/material";
import { CourseDto } from "../types/Courses";
import { getCourses } from "../services/courseService";
import { ContainerButton } from "../components/ContainerButton";

export default function Courses() {
  const [courses, setCourses] = useState<CourseDto[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const [isFormOpen, setIsFormOpen] = useState(false);

  const fetchCourses = async () => {
    try {
      const data = await getCourses();
      console.log(data);
      setCourses(data);
      setLoading(false);
    } catch (err) {
      setError("Failed to fetch courses, check if server is running.");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchCourses();
  }, []);

  return (
    <Container>
      <h1>Courses</h1>
      <ContainerButton label="Add Course" action={setIsFormOpen} />
    </Container>
  );
}

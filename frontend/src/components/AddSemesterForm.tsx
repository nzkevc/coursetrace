import React, { useState } from "react";
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Button,
  TextField,
} from "@mui/material";
import { SemesterPostDto } from "../types/Semesters";

interface AddSemesterFormProps {
  open: boolean;
  onClose: () => void;
  onAddSemester: (semester: SemesterPostDto) => Promise<void>;
}

const AddSemesterForm: React.FC<AddSemesterFormProps> = ({
  open,
  onClose,
  onAddSemester,
}) => {
  const [Name, setName] = useState("");
  const [Year, setYear] = useState(0);
  const [CourseIds, setCourseIds] = useState<number[]>([]);

  const handleSubmit = async () => {
    await onAddSemester({ Name, Year, CourseIds });
    setName("");
    setYear(0);
    setCourseIds([]);
    onClose();
  };

  return (
    <Dialog open={open} onClose={onClose}>
      <DialogTitle>Add Semester</DialogTitle>
      <DialogContent>
        <TextField
          autoFocus
          margin="dense"
          label="Name"
          type="text"
          fullWidth
          value={Name}
          onChange={(e) => setName(e.target.value)}
        />
        <TextField
          margin="dense"
          label="Year"
          type="number"
          fullWidth
          value={Year}
          onChange={(e) => setYear(Number(e.target.value))}
        />
      </DialogContent>
      <DialogActions>
        <Button onClick={onClose} color="primary">
          Cancel
        </Button>
        <Button onClick={handleSubmit} color="primary">
          Add
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default AddSemesterForm;

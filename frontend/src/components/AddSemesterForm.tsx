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
  const [Year, setYear] = useState("");
  const [CourseIds, setCourseIds] = useState([]);

  const handleSubmit = async () => {
    await onAddSemester({ Name, Year, CourseIds });
    setName("");
    setYear("");
    setCourseIds([]);
    onClose();
  };

  return (
    <Dialog open={open} onClose={onClose}>
      <DialogTitle>Add Student</DialogTitle>
      <DialogContent>
        <TextField
          autoFocus
          margin="dense"
          label="First Name"
          type="text"
          fullWidth
          value={firstName}
          onChange={(e) => setFirstName(e.target.value)}
        />
        <TextField
          margin="dense"
          label="Last Name"
          type="text"
          fullWidth
          value={lastName}
          onChange={(e) => setLastName(e.target.value)}
        />
        <TextField
          margin="dense"
          label="Email"
          type="email"
          fullWidth
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <TextField
          margin="dense"
          label="University"
          type="text"
          fullWidth
          value={university}
          onChange={(e) => setUniversity(e.target.value)}
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

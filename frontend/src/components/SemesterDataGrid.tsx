import React from "react";
import {
  DataGrid,
  GridColDef,
  GridRowsProp,
  GridActionsCellItem,
  GridRowModel,
} from "@mui/x-data-grid";
import DeleteIcon from "@mui/icons-material/Delete";
import { SemesterDto, SemesterPostDto } from "../types/Semesters";
import { deleteStudent, updateStudent } from "../Services/StudentService";
import { updateSemester } from "../services/semesterService";

interface SemesterDataGridProps {
  semesters: SemesterDto[];
  setSemesters: React.Dispatch<React.SetStateAction<SemesterDto[]>>;
  loading: boolean;
  error: string | null;
}

const SemesterDataGrid: React.FC<SemesterDataGridProps> = ({
  semesters,
  setSemesters,
  loading,
  error,
}) => {
  const handleDelete = async (id: number) => {
    await deleteStudent(id);
    setSemesters((prev) => prev.filter((semester) => semester.Id !== id));
  };

  const processRowUpdate = async (newRow: GridRowModel) => {
    // TODO: FUCKKKKKKK
    const updatedSemester = newRow as SemesterPostDto;
    try {
      // TODO: FUCKKKKKKKK
      await updateSemester(updatedSemester.Id, updatedSemester);
      setSemesters((prev) =>
        prev.map((semester) =>
          semester.Id === updatedSemester.Id ? updatedSemester : semester
        )
      );
      return updatedSemester;
    } catch (err) {
      console.error("Failed to update semester");
      return newRow;
    }
  };

  // TODO: MODIFY GRID COLUMNS
  const columns: GridColDef[] = [
    {
      field: "firstName",
      headerName: "First Name",
      width: 150,
      editable: true,
    },
    { field: "lastName", headerName: "Last Name", width: 150, editable: true },
    { field: "email", headerName: "Email", width: 250, editable: true },
    {
      field: "university",
      headerName: "University",
      width: 300,
      editable: true,
    },
    {
      field: "actions",
      headerName: "Actions",
      width: 100,
      renderCell: (params) => (
        <GridActionsCellItem
          icon={<DeleteIcon style={{ color: "red" }} />}
          label="Delete"
          onClick={() => handleDelete(params.id as number)}
        />
      ),
    },
  ];

  const rows: GridRowsProp = semesters.map((student) => ({
    id: student.Id,
    firstName: student.firstName,
    lastName: student.lastName,
    email: student.email,
    university: student.university,
  }));

  return (
    <div style={{ height: "70vh", width: "100%" }}>
      <DataGrid
        rows={rows}
        columns={columns}
        initialState={{
          pagination: {
            paginationModel: { pageSize: 10, page: 0 },
          },
        }}
        pageSizeOptions={[5, 10, 20, 50, 100]}
        pagination
        paginationMode="client"
        loading={loading}
        autoHeight
        processRowUpdate={processRowUpdate}
      />
    </div>
  );
};

export default SemesterDataGrid;

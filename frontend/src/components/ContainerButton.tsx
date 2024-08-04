import { Box, Button } from "@mui/material";

interface ContainerButtonProps {
  label: string;
  action: (arg0: boolean) => void;
}

export function ContainerButton({ label, action }: ContainerButtonProps) {
  return (
    <Box display="flex" gap={2} mb={2}>
      <Button variant="contained" color="primary" onClick={() => action(true)}>
        {label}
      </Button>
    </Box>
  );
}

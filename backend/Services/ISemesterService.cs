using Models;

public interface ISemesterService
{
    Task<IEnumerable<Semester>> GetAllSemesters();
    Task<Semester?> GetSemesterById(int id);
    Task CreateSemester(Semester semester);
    Task UpdateSemester(int id, Semester semester);
    Task DeleteSemester(int id);
}
using Demo.BusinessLogic.DataTransferObjects;

namespace Demo.BusinessLogic.Services
{
    public interface IDepartmentService
    {
        int AddDepartment(CreatedDepartmentDto createdDepartmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentsDetailDto? GetDepartmentById(int id);
        int UpdateDepartment(UpdatedDepartmentDto updatedDepartmentDto);
    }
}
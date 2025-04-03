using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {
        // Get All Departments
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();

            return departments.Select(D => D.ToDepartmentDto());
        }

        // Manual Mapping
        // Auto Mapper
        // Constructor Mapping
        // Extension Method


        // Get Department By Id
        public DepartmentsDetailDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);

            return department is null ? null : department.ToDepartmentsDetailDto();


        }


        // Add New Department

        public int AddDepartment(CreatedDepartmentDto createdDepartmentDto)
        {
            var department = createdDepartmentDto.ToEntity();

            return _departmentRepository.Add(department);
        }


        // Update Department

        public int UpdateDepartment(UpdatedDepartmentDto updatedDepartmentDto)
        {
            return _departmentRepository.Update(updatedDepartmentDto.ToEntity());
        }



        // Delete Department
        public bool DeleteDepartment(int id)
        {
            var Department = _departmentRepository.GetById(id);
            if (Department is null) return false;
            else
            {
                int Result = _departmentRepository.Remove(Department);
                return Result > 0 ? true : false;
            }
        }
    }
}

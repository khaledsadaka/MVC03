using Demo.BusinessLogic.DataTransferObjects;
using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Factories
{
    static class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            return new DepartmentDto
            {
                DeptId = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = DateOnly.FromDateTime(department.CreatedOn)
            };
        }

        public static DepartmentsDetailDto ToDepartmentsDetailDto(this Department department)
        {
            return new DepartmentsDetailDto()
            {
                Id = department.Id,
                Name = department.Name,
                CreatedBy = department.CreatedBy,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn),
                LastModifiedBy = department.LastModifiedBy,
                LastModifiedOn = DateOnly.FromDateTime(department.LastModifiedOn),
                IsDeleted = department.IsDeleted,
                Code = department.Code,
                Description = department.Description

            };
        }


        public static Department ToEntity (this CreatedDepartmentDto createdDepartmentDto)
        {
            return new Department()
            {
                Name = createdDepartmentDto.Name,
                Code = createdDepartmentDto.Code,
                Description = createdDepartmentDto.Description,
                CreatedOn = createdDepartmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }

        public static Department ToEntity(this UpdatedDepartmentDto updatedDepartmentDto)
        {
            return new Department()
            {
                Id = updatedDepartmentDto.Id,
                Name = updatedDepartmentDto.Name,
                Code = updatedDepartmentDto.Code,
                Description = updatedDepartmentDto.Description,
                CreatedOn = updatedDepartmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };

        }
    }
}

using StudentManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Interfaces
{
    public interface IStudentRegistrationRepository
    {
        Task<bool> CreateStudentRegistration(StudentRegistration StudentRegistration);
        Task<StudentRegistration> UpdateStudentRegistration(StudentRegistration StudentRegistration);
        Task<bool> DeleteStudentRegistration(StudentRegistration StudentRegistration);
        Task<StudentRegistration> GetStudentRegistrationById(Guid StudentRegistrationID);
        Task<List<StudentRegistration>> GetListStudentRegistration();
        Task<StudentRegistration> GetStudentRegistrationByName(string StudentName);
        Task<StudentRegistration>? GetStudentRegistrationByCode(string StudentCode);
        Task<string> GenerateUniqueStudentCodeAsync();
    }
}

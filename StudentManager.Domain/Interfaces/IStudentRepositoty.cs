using StudentManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Domain.Interfaces
{
    public interface IStudentRepositoty
    {
        Task<bool> CreateStudent(Student Student);
        Task<bool> UpdateStudent(Student Student);
        Task<bool> DeleteStudent(Student Student);
        Task<Student> GetStudentById(Guid StudentID);
        Task<List<Student>> GetListStudent();
        Task<Student> GetStudentByName(string StudentName);
        Task<Student>? GetStudentByCode(string StudentCode);
    }
}

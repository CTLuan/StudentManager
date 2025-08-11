using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentManager.Domain.Entities;
using StudentManager.Domain.Interfaces;
using StudentManager.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Infrastructure.Persistence.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DBContext _db;

        public StudentRepository(DBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<bool> CreateStudent(Student Student)
        {
            try
            {
                await _db.Students.AddAsync(Student);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteStudent(Student Student)
        {
            try
            {
                var student = await _db.Students.FirstOrDefaultAsync(x => x.StudentID == Student.StudentID);
                if(student == null)
                    return false;

                student.Active = false; // Assuming there's an Active property to mark as deleted
                _db.Students.Update(student);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Student>> GetListStudent()
        {
            try
            {
                var students = await _db.Students
                    .Where(s => s.Active)
                    .ToListAsync();
                return students;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Student>? GetStudentByCode(string StudentCode)
        {
            try
            {
                var student = await _db.Students
                    .FirstOrDefaultAsync(s => s.StudentCode == StudentCode && s.Active);
                return student;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Student> GetStudentById(Guid StudentID)
        {
            try
            {
                var student = await _db.Students
                    .FirstOrDefaultAsync(s => s.StudentID == StudentID && s.Active);
                return student;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Student> GetStudentByName(string StudentName)
        {
            try
            {
                var student = await _db.Students
                    .FirstOrDefaultAsync(s => s.StudentName == StudentName && s.Active);
                return student;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateStudent(Student Student)
        {
            var student = await _db.Students.FirstOrDefaultAsync(x => x.StudentID == Student.StudentID);
            if (student == null)
                return false;

            student.Active = false;
            _db.Students.Update(Student);
            return true;
        }
    }
}

using Microsoft.EntityFrameworkCore;
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
    public class StudentRegistrationRepository : IStudentRegistrationRepository
    {
        private readonly DBContext _db;

        public StudentRegistrationRepository(DBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<bool> CreateStudentRegistration(StudentRegistration StudentRegistration)
        {
            try
            {
                await _db.StudentRegistrations.AddAsync(StudentRegistration);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteStudentRegistration(StudentRegistration StudentRegistration)
        {
            try
            {
                var student = await _db.StudentRegistrations.FindAsync(StudentRegistration.StudentRegistrationID);
                if (student == null)
                    return false;

                student.Active = false;
                _db.StudentRegistrations.Update(student);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<string> GenerateUniqueStudentCodeAsync()
        {
            try
            {
                var rng = new Random();
                string code;

                do
                {
                    code = rng.Next(100000, 999999).ToString("D6"); // Tạo chuỗi 6 chữ số, có thể bắt đầu bằng số 0
                }
                while (await _db.StudentRegistrations.AnyAsync(s => s.StudentCode == code)); // Kiểm tra trùng DB

                return code;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
            
        }

        public async Task<List<StudentRegistration>> GetListStudentRegistration()
        {
            var students = await _db.StudentRegistrations
                .Where(s => s.Active)
                .ToListAsync();

            return students;
        }

        public async Task<StudentRegistration>? GetStudentRegistrationByCode(string StudentCode)
        {
            var student = await _db.StudentRegistrations
                .FirstOrDefaultAsync(s => s.StudentCode == StudentCode && s.Active);

            if (student == null)
                return null;
            
            return student;
        }

        public async Task<StudentRegistration> GetStudentRegistrationById(Guid StudentRegistrationID)
        {
            var student = await _db.StudentRegistrations
                .FirstOrDefaultAsync(s => s.StudentRegistrationID == StudentRegistrationID && s.Active);
            return student;
        }

        public async Task<StudentRegistration> GetStudentRegistrationByName(string StudentName)
        {
            var student = await _db.StudentRegistrations
                .FirstOrDefaultAsync(s => s.StudentName == StudentName && s.Active);
            return student;
        }

        public async Task<StudentRegistration> UpdateStudentRegistration(StudentRegistration StudentRegistration)
        {
            try
            {
                var student = await _db.StudentRegistrations.FindAsync(StudentRegistration.StudentRegistrationID);
                if (student == null)
                    return null;

                _db.StudentRegistrations.Update(StudentRegistration);

                return StudentRegistration;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

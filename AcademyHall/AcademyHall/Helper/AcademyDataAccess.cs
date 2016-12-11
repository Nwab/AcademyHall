using AcademyHall.DataLink;
using AcademyHall.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademyHall.Helper
{
    public class AcademyDataAccess
    {
        static AcademyHallDbContext _db = new AcademyHallDbContext();

        public static List<CombinedStudentDetailVM> GetAllStudentList()
        {
            List<CombinedStudentDetailVM> listStudent = new List<CombinedStudentDetailVM>();
            var allStudentList = _db.StudentDetails.ToList();
            foreach (var student in allStudentList)
            {

                var studentDet = new StudentDetailVM
                {
                    Address = student.Address,
                    DateOfBirth = student.DateOfBirth,
                    DateRegistered = student.DateRegistered,
                    FirstName = student.FirstName,
                    MiddleName = student.MiddleName,
                    LastName = student.LastName,
                    Gender = student.Gender,
                    MobilePhone = student.MobilePhone,
                    Telephone = student.Telephone,
                    StudentRegistrationNo = student.StudentRegistrationNo
                };

                var familyDet = new StudentFamilyDetailVM
                {
                    FatherEmailAddress = student.FatherEmailAddress,
                    FatherFullName = student.FatherFullName
                };


                listStudent.Add(new CombinedStudentDetailVM
                {
                    studentDetailVM = studentDet,
                    familyDetailVM = familyDet
                });
            }
            return listStudent;
        }
    }
}
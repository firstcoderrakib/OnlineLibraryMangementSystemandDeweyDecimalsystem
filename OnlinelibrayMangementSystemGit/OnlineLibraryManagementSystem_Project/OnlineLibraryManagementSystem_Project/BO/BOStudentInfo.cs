using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BO
{
    public class BOStudentInfo
    {
        private string studentID;

        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }
        private string studentName;

        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }
        private string departmentID;

        public string DepartmentID
        {
            get { return departmentID; }
            set { departmentID = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string fatherName;

        public string FatherName
        {
            get { return fatherName; }
            set { fatherName = value; }
        }
        private string motherName;

        public string MotherName
        {
            get { return motherName; }
            set { motherName = value; }
        }
        private string mobileNo;

        public string MobileNo
        {
            get { return mobileNo; }
            set { mobileNo = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string studentPic;

        public string StudentPic
        {
            get { return studentPic; }
            set { studentPic = value; }
        }
        private string entryBy;

        public string EntryBy
        {
            get { return entryBy; }
            set { entryBy = value; }
        }
        private string entryDate;

        public string EntryDate
        {
            get { return entryDate; }
            set { entryDate = value; }
        }
    }
}
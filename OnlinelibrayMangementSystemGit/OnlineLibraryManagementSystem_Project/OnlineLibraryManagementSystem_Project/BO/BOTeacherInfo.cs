using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BO
{
    public class BOTeacherInfo
    {
        private string _TeacherID;

        public string TeacherID
        {
            get { return _TeacherID; }
            set { _TeacherID = value; }
        }
        private string _TeacherName;

        public string TeacherName
        {
            get { return _TeacherName; }
            set { _TeacherName = value; }
        }
        private string _DepartmentID;

        public string DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }
        private string _Address;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
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

        private string _MobileNo;

        public string MobileNo
        {
            get { return _MobileNo; }
            set { _MobileNo = value; }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private string _TeacherPic;

        public string TeacherPic
        {
            get { return _TeacherPic; }
            set { _TeacherPic = value; }
        }
        private string _EntryBy;

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }
        private string _EntryDate;

        public string EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }
    }
}
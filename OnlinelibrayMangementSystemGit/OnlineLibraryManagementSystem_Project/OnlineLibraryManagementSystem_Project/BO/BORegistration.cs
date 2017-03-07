using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BO
{
    public class BORegistration
    {
        private string _FullName;

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }
        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        private string _UniversityID;

        public string UniversityID
        {
            get { return _UniversityID; }
            set { _UniversityID = value; }
        }
        private string _Department;

        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }
        private string _FatherName;

        public string FatherName
        {
            get { return _FatherName; }
            set { _FatherName = value; }
        }
        private string _MotherName;

        public string MotherName
        {
            get { return _MotherName; }
            set { _MotherName = value; }
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
        private string _Picture;

        public string Picture
        {
            get { return _Picture; }
            set { _Picture = value; }
        }
        private string _UserType;

        public string UserType
        {
            get { return _UserType; }
            set { _UserType = value; }
        }
            
    }
}
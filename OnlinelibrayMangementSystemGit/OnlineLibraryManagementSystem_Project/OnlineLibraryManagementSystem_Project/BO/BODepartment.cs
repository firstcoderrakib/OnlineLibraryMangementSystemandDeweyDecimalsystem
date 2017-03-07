using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BO
{
    public class BODepartment
    {
        private int _DepartmentID;

        public int DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }
        private string _DepartmentTitle;

        public string DepartmentTitle
        {
            get { return _DepartmentTitle; }
            set { _DepartmentTitle = value; }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BO
{
    public class BOAddIssueType
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _IssueType;

        public string IssueType
        {
            get { return _IssueType; }
            set { _IssueType = value; }
        }
        
    }
}
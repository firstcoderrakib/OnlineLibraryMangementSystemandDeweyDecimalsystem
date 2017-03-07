using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BO
{
    public class BOUserType
    {
        private int _UserID;

        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        private string _UserType;

        public string UserType
        {
            get { return _UserType; }
            set { _UserType = value; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BO
{
    public class BOAddEdition
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _EditionTitle;

        public string EditionTitle
        {
            get { return _EditionTitle; }
            set { _EditionTitle = value; }
        }
    }
}
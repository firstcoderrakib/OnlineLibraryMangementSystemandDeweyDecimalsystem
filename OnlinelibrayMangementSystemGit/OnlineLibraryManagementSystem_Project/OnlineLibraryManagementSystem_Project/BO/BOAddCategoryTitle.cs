using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BO
{
    public class BOAddCategoryTitle
    {
        private string _CategoryID;

        public string CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        private string _CategoryTitle;

        public string CategoryTitle
        {
            get { return _CategoryTitle; }
            set { _CategoryTitle = value; }
        }
    }
}
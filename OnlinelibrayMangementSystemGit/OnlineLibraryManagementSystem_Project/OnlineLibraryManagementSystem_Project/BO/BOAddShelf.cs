using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BO
{
    public class BOAddShelf
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _ShelfTitle;

        public string ShelfTitle
        {
            get { return _ShelfTitle; }
            set { _ShelfTitle = value; }
        }
    }
}
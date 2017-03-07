using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BO
{
    public class BOAddBookCell
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _BookCellTitle;

        public string BookCellTitle
        {
            get { return _BookCellTitle; }
            set { _BookCellTitle = value; }
        }
    }
}
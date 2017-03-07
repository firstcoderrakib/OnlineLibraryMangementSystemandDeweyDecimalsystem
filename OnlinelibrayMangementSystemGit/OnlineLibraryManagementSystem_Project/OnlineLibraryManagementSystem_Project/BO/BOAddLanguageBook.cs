using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BO
{
    public class BOAddLanguageBook
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _BookLanguage;

        public string BookLanguage
        {
            get { return _BookLanguage; }
            set { _BookLanguage = value; }
        }
    }
}
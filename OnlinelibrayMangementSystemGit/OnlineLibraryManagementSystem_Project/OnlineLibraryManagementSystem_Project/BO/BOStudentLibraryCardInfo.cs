﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BO
{
    public class BOStudentLibraryCardInfo
    {
        private string _StudentName;

        public string StudentName
        {
            get { return _StudentName; }
            set { _StudentName = value; }
        }
        private string _StudentID;

        public string StudentID
        {
            get { return _StudentID; }
            set { _StudentID = value; }
        }
        private string _BookID;

        public string BookID
        {
            get { return _BookID; }
            set { _BookID = value; }
        }
        private string _IsueeDate;

        public string IsueeDate
        {
            get { return _IsueeDate; }
            set { _IsueeDate = value; }
        }
        private string _ReturnDate;

        public string ReturnDate
        {
            get { return _ReturnDate; }
            set { _ReturnDate = value; }
        }

        private int _IsRetrun;
        public int IsRetrun
        {
            get { return _IsRetrun; }
            set { _IsRetrun = value; }
        }

        private int _IsRenew;
        public int IsRenew
        {
            get { return _IsRenew; }
            set { _IsRenew = value; }
        }
        private int _IssueType;

        public int IssueType
        {
            get { return _IssueType; }
            set { _IssueType = value; }
        }
        private string _EntryDate;

        public string EntryDate
        {
            get { return _EntryDate; }
            set { _EntryDate = value; }
        }
        private string _EntryBy;

        public string EntryBy
        {
            get { return _EntryBy; }
            set { _EntryBy = value; }
        }
            
    }
}
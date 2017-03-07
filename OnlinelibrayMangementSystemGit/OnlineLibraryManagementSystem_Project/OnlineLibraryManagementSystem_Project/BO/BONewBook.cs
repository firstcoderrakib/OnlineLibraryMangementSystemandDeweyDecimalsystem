using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BO
{
    public class BONewBook
    {
        private string bookID;

        public string BookID
        {
            get { return bookID; }
            set { bookID = value; }
        }
        private string bookName;

        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }
        private string bookCategoryID;

        public string BookCategoryID
        {
            get { return bookCategoryID; }
            set { bookCategoryID = value; }
        }
     
        private string writerName;

        public string WriterName
        {
            get { return writerName; }
            set { writerName = value; }
        }
       
        private string edition;

        public string Edition
        {
            get { return edition; }
            set { edition = value; }
        }

        private string publishedYear;

        public string PublishedYear
        {
            get { return publishedYear; }
            set { publishedYear = value; }
        }
        private string bookLanguageID;

        public string BookLanguageID
        {
            get { return bookLanguageID; }
            set { bookLanguageID = value; }
        }
        private string shelfID;

        public string ShelfID
        {
            get { return shelfID; }
            set { shelfID = value; }
        }
        private string cellID;

        public string CellID
        {
            get { return cellID; }
            set { cellID = value; }
        }
        private string issueTypeID;

        public string IssueTypeID
        {
            get { return issueTypeID; }
            set { issueTypeID = value; }
        }
     
        private string numberOfBook;

        public string NumberOfBook
        {
            get { return numberOfBook; }
            set { numberOfBook = value; }
        }
      
        private string entryDate;

        public string EntryDate
        {
            get { return entryDate; }
            set { entryDate = value; }
        }
        private string entryBy;

        public string EntryBy
        {
            get { return entryBy; }
            set { entryBy = value; }
        }
    }
} 
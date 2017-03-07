using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineLibraryManagementSystem_Project.BL
{
    public class BLGlobalVar
    {
        public static string Connection = @"Data Source=DESKTOP-JAF3C38\SQLEXPRESS;Initial Catalog=OnlineLibraryMagamement;Integrated Security=True";
        public static string FromEmailAddress = "rajibdas194@yahoo.com";
        public static string FromEmailPassword = "01716131977";
        public static string SMTPServer = "smtp.mail.yahoo.com";
        public static string EmailSubject = "Book Issue from Library";
        
    }
}
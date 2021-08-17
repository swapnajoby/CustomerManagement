using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Models
{
   
    public class Customer
    {
       
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string BusinessName { get; set; }

        public DateTime CreatedDate { get; set; }

        //private DateTime Created_Date;
        //public DateTime CreatedDate
        //{
        //    get { return Created_Date; }
        //    set { Created_Date = new DateTime().ToLocalTime(); }
        //}

        //private string str_Created_Date;
        //public string strCreatedDate
        //{
        //    get { return str_Created_Date; }
        //    set { str_Created_Date = CreatedDate.ToLocalTime().ToString(); }
        //}
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string BusinessName { get; set; }

        public DateTime CreatedDate { get; set; }



        private string str_Created_Date;
        public string strCreatedDate
        {
            get { return str_Created_Date; }
            set { str_Created_Date = CreatedDate.ToLocalTime().ToString(); }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookApp.Models
{
    public class Contact
    {
        //properties of a phone contact
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }
    }


}

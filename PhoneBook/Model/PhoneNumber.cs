using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phonebook.Model
{
    /// <summary>
    /// PhoneNumber Entity
    /// </summary>
    public class PhoneNumber
    {
        public int PhoneID { get; set; }
        public string PNumber { get; set; }
        public int PersonID { get; set; }
    }
}
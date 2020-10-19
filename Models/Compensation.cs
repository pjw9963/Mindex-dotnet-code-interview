using System;

namespace challenge.Models
{
    public class Compensation 
    {
        public String compensationID { get; set; }
        public Employee employee { get; set; }
        public double salary { get; set; }
        public System.DateTime effectiveDate { get; set; }
    }

}
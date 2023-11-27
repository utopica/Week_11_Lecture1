using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Week_11_Lecture1.Domain.Common;

namespace Week_11_Lecture1.Domain.Entities
{
    public class BankAccount : EntityBase<Guid>
    {
 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; }

    }
}

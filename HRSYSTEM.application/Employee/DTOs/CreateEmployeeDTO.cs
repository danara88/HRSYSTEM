using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSYSTEM.application
{
    /// <summary>
    /// This is the DTO for Employee Entity to create a new one
    /// </summary>
    public class CreateEmployeeDTO
    {
        /// <summary>
        /// Employee's firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Employee's lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Employee's middlename
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Employee's age
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Employee's status Ex. 2 = Active, 1 = Inactive
        /// </summary>
        public int Status { get; set; }
    }
}

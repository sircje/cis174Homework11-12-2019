using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class ErrorLogTable
    {
        string httpCode { get; set; }
        DateTime errorTime { get; set; }
        [Key]
        public Guid requestId { get; set; }
        string exceptionMessage { get; set; }
        string stackTrace { get; set; }

    }
}

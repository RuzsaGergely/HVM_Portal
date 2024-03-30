using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Log : BaseEntity
    {
        public User? User { get; set; }
        public string LogMessage { get; set; }
        public DateTime Time { get; set; }
    }
}

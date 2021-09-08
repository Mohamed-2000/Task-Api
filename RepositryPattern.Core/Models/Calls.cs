using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.Core.Models
{
    public class Calls
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public string CallTitle { get; set; }
        public DateTime Date { get; set; }
        public string TheProject { get; set; }

        public virtual ICollection<Employee> employees { get; set; }
        public virtual ICollection<client> clients { get; set; }

        public string CallType { get; set; }

        public string status { get; set; }
        public string IsComing { get; set; }

        public string EnterBy { get; set; }
        public Nullable<System.DateTime> EnterDate { get; set; }
        public string LastEdit { get; set; }
    }
}

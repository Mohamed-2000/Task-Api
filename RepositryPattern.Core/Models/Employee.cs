using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        
        public virtual ICollection<client> Clients { get; set; }

    }
}

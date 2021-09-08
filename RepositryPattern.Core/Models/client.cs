using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.Core.Models
{
    public class client
    {
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Address { get; set; }

        public Nullable<int> Mobile { get; set; }
        public Nullable<int> TelOne { get; set; }
        public Nullable<int> TelTwo { get; set; }
        public Nullable<int> whatsapp { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        public string Nationality { get; set; }

        public string Residence { get; set; }
        public string Description { get; set; }
        public string Occupation { get; set; }
        public string EnterBy { get; set; }
        public Nullable<System.DateTime> EnterDate { get; set; }
        public string LastEdit { get; set; }
        public Nullable<System.DateTime> LastEditIn { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public string ClientSource { get; set; }
        public Nullable<int> CustomerRate { get; set; }
    }
}

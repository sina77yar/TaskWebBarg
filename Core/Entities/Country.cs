using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [MaxLength(100)]
        public string CountryName { get; set; }
        //public Person Person { get; set; }

    }
}

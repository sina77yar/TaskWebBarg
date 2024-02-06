using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [MaxLength(100)]
        public string CityName { get; set; }    
        public int CountryId { get; set; }
        //public Country Country { get; set; }

    }
}

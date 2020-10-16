using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TpBooks
{
    public class Bookdto
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Authors { get; set; }
        public string Publisher { get; set; }
        public int PublishedDate { get; set; }
        public string Description { get; set; }

    }
}

   

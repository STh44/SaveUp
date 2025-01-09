using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveUp.Models
{
    public class SavedItem
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateSaved { get; set; } = DateTime.Now;
    }
}


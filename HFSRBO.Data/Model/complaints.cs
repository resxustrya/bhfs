using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace HFSRBO.Data
{
    public class complaints
    {
        [Key]
        public Int32 ID { get; set; }
        public DateTime? dateEntry { get; set; }
    }
}

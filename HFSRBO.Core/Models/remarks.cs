using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace HFSRBO.Core
{
    public class remarks
    {
        [Key]
        public Int32 ID { get; set; }
        public String remark { get; set; }
    }
}

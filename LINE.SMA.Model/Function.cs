using System;
using System.Linq;
using System.Text;
using LINE.SMA.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINE.SMA.Model
{
     [Table("t_function")] 
     public class Function : EntityBase
     {
         //  
         public long Id { get; set; }
         //  
         public int parentid { get; set; }
         //  
         public string funname { get; set; }
         //  
         public string funurl { get; set; }
         //  
         public int LoginType { get; set; }
         //  
         public string typeName { get; set; }
         // 排序编号 
         public int OrderId { get; set; }
         // 0 可见  1不可见 
        
         public int hidden { get; set; }
        [NotMapped]
        public string icon { get; set; }
     }
}


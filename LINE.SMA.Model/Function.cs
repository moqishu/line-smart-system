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
         // ������ 
         public int OrderId { get; set; }
         // 0 �ɼ�  1���ɼ� 
        
         public int hidden { get; set; }
        [NotMapped]
        public string icon { get; set; }
     }
}


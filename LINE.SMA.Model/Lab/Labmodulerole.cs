
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_module_role")]
    public class Labmodulerole : EntityBase
    {
        /// <summary>
        /// 模块角色id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 模块id
        /// </summary>
        [Column("module_id")]
        public int Module_id { get; set; }

        /// <summary>
        /// 角色id 
        /// </summary>
        [Column("role_id")]
        public int Role_id { get; set; }

        /// <summary>
        /// 0-使用  1-停用
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        public DateTime? Create_time { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Column("update_time")]
        public DateTime? Update_time { get; set; }

        }
}



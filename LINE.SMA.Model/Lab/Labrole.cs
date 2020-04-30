
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_role")]
    public class Labrole : EntityBase
    {
        /// <summary>
        /// 角色id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Column("role_name")]
        public string Role_name { get; set; }

        /// <summary>
        /// 角色说明
        /// </summary>
        [Column("role_description")]
        public string Role_description { get; set; }

        /// <summary>
        /// 0-启用   10-禁用
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

        /// <summary>
        /// 
        /// </summary>
        [Column("version")]
        public int Version { get; set; }

        }
}



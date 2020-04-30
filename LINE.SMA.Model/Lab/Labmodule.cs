
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_module")]
    public class Labmodule : EntityBase
    {
        /// <summary>
        /// 模块编号
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        [Column("module_name")]
        public string Module_name { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        [Column("url")]
        public string Url { get; set; }

        /// <summary>
        /// 模块级别 1-顶级  2-二级 
        /// </summary>
        [Column("level")]
        public int Level { get; set; }

        /// <summary>
        /// 父级id
        /// </summary>
        [Column("f_id")]
        public long F_id { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        [Column("sort")]
        public int Sort { get; set; }

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



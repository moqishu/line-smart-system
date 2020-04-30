
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_example")]
    public class Labexample : EntityBase
    {
        /// <summary>
        /// 习题id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 习题名称
        /// </summary>
        [Column("example_name")]
        public string Example_name { get; set; }

        /// <summary>
        /// 习题内容
        /// </summary>
        [Column("example_content")]
        public string Example_content { get; set; }

        /// <summary>
        /// 习题用途
        /// </summary>
        [Column("example_use")]
        public string Example_use { get; set; }

        /// <summary>
        /// 是否查看[0:未查看, 1:已查看]
        /// </summary>
        [Column("looked")]
        public int Looked { get; set; }

        /// <summary>
        /// 删除状态[0:停用, 1:启用]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [Column("operator")]
        public string Operator { get; set; }

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



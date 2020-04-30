
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_class")]
    public class Labclass : EntityBase
    {
        /// <summary>
        /// 班级ID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 班级编号
        /// </summary>
        [Column("class_code")]
        public string Class_code { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        [Column("class_name")]
        public string Class_name { get; set; }

        /// <summary>
        /// 院系ID
        /// </summary>
        [Column("department_id")]
        public long Department_id { get; set; }

        /// <summary>
        /// 院系名称
        /// </summary>
        [Column("department_name")]
        public string Department_name { get; set; }

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




using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_group")]
    public class Labgroup : EntityBase
    {
        /// <summary>
        /// 分组id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>
        [Column("group_name")]
        public string Group_name { get; set; }

        /// <summary>
        /// 分组编号
        /// </summary>
        [Column("group_num")]
        public string Group_num { get; set; }

        /// <summary>
        /// 班级id
        /// </summary>
        [Column("class_id")]
        public long Class_id { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        [Column("class_name")]
        public string Class_name { get; set; }

        /// <summary>
        /// 由谁分组[0:教师, 1:学生]
        /// </summary>
        [Column("type")]
        public int Type { get; set; }

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



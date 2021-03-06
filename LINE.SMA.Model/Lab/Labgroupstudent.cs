
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_group_student")]
    public class Labgroupstudent : EntityBase
    {
        /// <summary>
        /// 学生分组id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 分组id
        /// </summary>
        [Column("group_id")]
        public long Group_id { get; set; }

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
        /// 学生id
        /// </summary>
        [Column("student_id")]
        public long Student_id { get; set; }

        /// <summary>
        /// 学生名称
        /// </summary>
        [Column("student_name")]
        public string Student_name { get; set; }

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




using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_course_student_station")]
    public class Labcoursestudentstation : EntityBase
    {
        /// <summary>
        /// 学生预约id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 课位id
        /// </summary>
        [Column("station_id")]
        public long Station_id { get; set; }

        /// <summary>
        /// 预约时间id
        /// </summary>
        [Column("time_id")]
        public long Time_id { get; set; }

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
        /// 当前状态[0:停用, 1:启用]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// 操作人id
        /// </summary>
        [Column("operator_id")]
        public long Operator_id { get; set; }

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




using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_course_order")]
    public class Labcourseorder : EntityBase
    {
        /// <summary>
        /// 预约id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 课程id
        /// </summary>
        [Column("course_id")]
        public long Course_id { get; set; }

        /// <summary>
        /// 班级id
        /// </summary>
        [Column("class_id")]
        public long Class_id { get; set; }

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
        /// 备注
        /// </summary>
        [Column("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 删除状态[0:停用, 1:启用]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// 考勤状态[0:未签到, 1:已签到]
        /// </summary>
        [Column("check_work")]
        public int Check_work { get; set; }

        /// <summary>
        /// 上课状态[0:未上课, 1:已上课]
        /// </summary>
        [Column("work_state")]
        public int Work_state { get; set; }

        /// <summary>
        /// 操作人id
        /// </summary>
        [Column("operator_id")]
        public string Operator_id { get; set; }

        /// <summary>
        /// 操作人名称
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

        /// <summary>
        /// 预约时间id
        /// </summary>
        [Column("time_id")]
        public long Time_id { get; set; }

        }
}



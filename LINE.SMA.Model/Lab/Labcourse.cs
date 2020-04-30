
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_course")]
    public class Labcourse : EntityBase
    {
        /// <summary>
        /// 课程id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        [Column("course_name")]
        public string Course_name { get; set; }

        /// <summary>
        /// 实验id
        /// </summary>
        [Column("experiment_id")]
        public long Experiment_id { get; set; }

        /// <summary>
        /// 实验名称
        /// </summary>
        [Column("experiment_name")]
        public string Experiment_name { get; set; }

        /// <summary>
        /// 习题id
        /// </summary>
        [Column("example_id")]
        public long Example_id { get; set; }

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
        /// 预约时间id
        /// </summary>
        [Column("time_id")]
        public long Time_id { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Column("begin_time")]
        public DateTime? Begin_time { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [Column("end_time")]
        public DateTime? End_time { get; set; }

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
        /// 教室id
        /// </summary>
        [Column("room_id")]
        public long Room_id { get; set; }

        /// <summary>
        /// 教室名称
        /// </summary>
        [Column("room_name")]
        public string Room_name { get; set; }

        /// <summary>
        /// 课位数量
        /// </summary>
        [Column("place_count")]
        public int Place_count { get; set; }

        /// <summary>
        /// 已预约课位数量
        /// </summary>
        [Column("place_ok_count")]
        public int Place_ok_count { get; set; }

        /// <summary>
        /// 删除状态[0:停用, 1:未开始 20:执行中 30:已完成]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// 教师id
        /// </summary>
        [Column("teacher_id")]
        public long Teacher_id { get; set; }

        /// <summary>
        /// 教师名称
        /// </summary>
        [Column("teacher_name")]
        public string Teacher_name { get; set; }

        /// <summary>
        /// 教师名称
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



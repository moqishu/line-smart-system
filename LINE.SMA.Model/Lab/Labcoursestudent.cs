
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_course_student")]
    public class Labcoursestudent : EntityBase
    {
        /// <summary>
        /// 课程选择学生id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 课程id
        /// </summary>
        [Column("course_id")]
        public long Course_id { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        [Column("course_name")]
        public string Course_name { get; set; }

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
        /// 已做习题内容
        /// </summary>
        [Column("example_content")]
        public string Example_content { get; set; }

        /// <summary>
        /// 习题学生已做[0:未做, 1:已做]
        /// </summary>
        [Column("example_flag")]
        public int Example_flag { get; set; }

        /// <summary>
        /// 习题是否批改[0:未批改, 1:已批改]
        /// </summary>
        [Column("example_checked")]
        public int Example_checked { get; set; }

        /// <summary>
        /// 习题评分
        /// </summary>
        [Column("example_score")]
        public int Example_score { get; set; }

        /// <summary>
        /// 习题评语
        /// </summary>
        [Column("example_comment")]
        public string Example_comment { get; set; }

        /// <summary>
        /// 学生实验报告
        /// </summary>
        [Column("experiment_report")]
        public string Experiment_report { get; set; }

        /// <summary>
        /// 习题学生已做[0:未做, 1:已做]
        /// </summary>
        [Column("experiment_flag")]
        public int Experiment_flag { get; set; }

        /// <summary>
        /// 报告是否批改[0:未批改, 1:已批改]
        /// </summary>
        [Column("experiment_checked")]
        public int Experiment_checked { get; set; }

        /// <summary>
        /// 报告评分
        /// </summary>
        [Column("experiment_score")]
        public int Experiment_score { get; set; }

        /// <summary>
        /// 报告评语
        /// </summary>
        [Column("experiment_comment")]
        public string Experiment_comment { get; set; }

        /// <summary>
        /// 开始答题时间
        /// </summary>
        [Column("begin_time")]
        public DateTime? Begin_time { get; set; }

        /// <summary>
        /// 结束答题时间
        /// </summary>
        [Column("end_time")]
        public DateTime? End_time { get; set; }

        /// <summary>
        /// 作业状态[0:停用, 1:未开始 20:执行中 30:已完成]
        /// </summary>
        [Column("example_state")]
        public int Example_state { get; set; }

        /// <summary>
        /// 报告状态[0:停用, 1:未开始 20:执行中 30:已完成]
        /// </summary>
        [Column("experiment_state")]
        public int Experiment_state { get; set; }

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

        /// <summary>
        /// 预约时间id
        /// </summary>
        [Column("time_id")]
        public long Time_id { get; set; }

        }
}



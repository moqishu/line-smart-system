
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_experiment")]
    public class Labexperiment : EntityBase
    {
        /// <summary>
        /// 实验id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 实验编号
        /// </summary>
        [Column("experiment_code")]
        public string Experiment_code { get; set; }

        /// <summary>
        /// 实验名称
        /// </summary>
        [Column("experiment_name")]
        public string Experiment_name { get; set; }

        /// <summary>
        /// 类型id
        /// </summary>
        [Column("type_id")]
        public long Type_id { get; set; }

        /// <summary>
        /// 实验类型
        /// </summary>
        [Column("type_name")]
        public string Type_name { get; set; }

        /// <summary>
        /// 实验者类别
        /// </summary>
        [Column("student_type")]
        public string Student_type { get; set; }

        /// <summary>
        /// 每组人数
        /// </summary>
        [Column("person_count")]
        public int Person_count { get; set; }

        /// <summary>
        /// 计划学时
        /// </summary>
        [Column("study_time")]
        public int Study_time { get; set; }

        /// <summary>
        /// 实验教程
        /// </summary>
        [Column("experiment_book")]
        public string Experiment_book { get; set; }

        /// <summary>
        /// 考核方式
        /// </summary>
        [Column("check_type")]
        public string Check_type { get; set; }

        /// <summary>
        /// 实验设备及数量
        /// </summary>
        [Column("experiment_count")]
        public string Experiment_count { get; set; }

        /// <summary>
        /// 实验描述
        /// </summary>
        [Column("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 目的与要求
        /// </summary>
        [Column("require_content")]
        public string Require_content { get; set; }

        /// <summary>
        /// 实验名称
        /// </summary>
        [Column("file_name")]
        public string File_name { get; set; }

        /// <summary>
        /// 实验url
        /// </summary>
        [Column("file_url")]
        public string File_url { get; set; }

        /// <summary>
        /// 实验大小
        /// </summary>
        [Column("file_size")]
        public int File_size { get; set; }

        /// <summary>
        /// 教学计划名称
        /// </summary>
        [Column("file_name2")]
        public string File_name2 { get; set; }

        /// <summary>
        /// 教学计划url
        /// </summary>
        [Column("file_url2")]
        public string File_url2 { get; set; }

        /// <summary>
        /// 教学帮助
        /// </summary>
        [Column("file_name3")]
        public string File_name3 { get; set; }

        /// <summary>
        /// 教学帮助url
        /// </summary>
        [Column("file_url3")]
        public string File_url3 { get; set; }

        /// <summary>
        /// 删除状态[0:停用, 1:启用 2：正常]
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



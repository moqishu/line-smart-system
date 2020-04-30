
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_message")]
    public class Labmessage : EntityBase
    {
        /// <summary>
        /// 实验id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 实验室名称
        /// </summary>
        [Column("message_name")]
        public string Message_name { get; set; }

        /// <summary>
        /// 实验内容
        /// </summary>
        [Column("message_content")]
        public string Message_content { get; set; }

        /// <summary>
        /// 发送方类型[0 学生 1 教师 2 系统管理员]
        /// </summary>
        [Column("sender")]
        public int Sender { get; set; }

        /// <summary>
        /// 发送方类型[0 学生 1 教师 2 系统管理员]
        /// </summary>
        [Column("receiver")]
        public int Receiver { get; set; }

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



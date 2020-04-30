
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_room_time")]
    public class Labroomtime : EntityBase
    {
        /// <summary>
        /// 教室ID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 教室ID
        /// </summary>
        [Column("room_id")]
        public long Room_id { get; set; }

        /// <summary>
        /// 教室编号
        /// </summary>
        [Column("room_code")]
        public string Room_code { get; set; }

        /// <summary>
        /// 教室名称
        /// </summary>
        [Column("room_name")]
        public string Room_name { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [Column("room_day")]
        public string Room_day { get; set; }

        /// <summary>
        /// 课时名称
        /// </summary>
        [Column("time_name")]
        public string Time_name { get; set; }

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
        /// 时间周期：上午 下午 晚上
        /// </summary>
        [Column("room_time_type")]
        public string Room_time_type { get; set; }

        /// <summary>
        /// 删除状态[0:停用, 1:启用]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// 是否可预约[1:可预约, 2:不可预约]
        /// </summary>
        [Column("check_state")]
        public int Check_state { get; set; }

        /// <summary>
        /// 审核状态 0:无效, 1: 审核不通过, 2: 审核通过 
        /// </summary>
        [Column("audit_state")]
        public int Audit_state { get; set; }

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



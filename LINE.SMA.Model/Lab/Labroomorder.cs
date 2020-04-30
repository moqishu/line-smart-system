
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_room_order")]
    public class Labroomorder : EntityBase
    {
        /// <summary>
        /// 预约ID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 时间id
        /// </summary>
        [Column("time_id")]
        public long Time_id { get; set; }

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
        /// 教师ID
        /// </summary>
        [Column("teacher_id")]
        public long Teacher_id { get; set; }

        /// <summary>
        /// 教师名称
        /// </summary>
        [Column("teacher_name")]
        public string Teacher_name { get; set; }

        /// <summary>
        /// 审核人ID
        /// </summary>
        [Column("shenhe_id")]
        public long Shenhe_id { get; set; }

        /// <summary>
        /// 审核状态[0:无效, 10: 预约新提交(审核中), 20:预约重新提交(审核中) , 30: 预约未通过, 100: 预约通过]
        /// </summary>
        [Column("audit_state")]
        public int Audit_state { get; set; }

        /// <summary>
        /// 删除状态[0:停用, 1:启用]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// 审核意见[审核通过 就清空,不通过 就填充个意见]
        /// </summary>
        [Column("remark")]
        public string Remark { get; set; }

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



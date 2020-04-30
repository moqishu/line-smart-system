
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_room")]
    public class Labroom : EntityBase
    {
        /// <summary>
        /// 教室ID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

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
        /// 院系名称
        /// </summary>
        [Column("department")]
        public string Department { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        [Column("measure_area")]
        public string Measure_area { get; set; }

        /// <summary>
        /// 地点
        /// </summary>
        [Column("area")]
        public string Area { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [Column("leader")]
        public string Leader { get; set; }

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
        /// 课位排
        /// </summary>
        [Column("room_rows")]
        public int Room_rows { get; set; }

        /// <summary>
        /// 课位列
        /// </summary>
        [Column("room_cols")]
        public int Room_cols { get; set; }

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



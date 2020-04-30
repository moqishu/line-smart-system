
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_room_station")]
    public class Labroomstation : EntityBase
    {
        /// <summary>
        /// 课位ID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 教室ID
        /// </summary>
        [Column("room_id")]
        public long Room_id { get; set; }

        /// <summary>
        /// 课位第几排
        /// </summary>
        [Column("room_row")]
        public int Room_row { get; set; }

        /// <summary>
        /// 课位第几列
        /// </summary>
        [Column("room_col")]
        public int Room_col { get; set; }

        /// <summary>
        /// 课位名字
        /// </summary>
        [Column("station_name")]
        public string Station_name { get; set; }

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




using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_discuss")]
    public class Labdiscuss : EntityBase
    {
        /// <summary>
        /// 讨论id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 讨论标题
        /// </summary>
        [Column("discuss_title")]
        public string Discuss_title { get; set; }

        /// <summary>
        /// 讨论组id
        /// </summary>
        [Column("discuss_group_id")]
        public long Discuss_group_id { get; set; }

        /// <summary>
        /// 讨论组
        /// </summary>
        [Column("discuss_group_name")]
        public string Discuss_group_name { get; set; }

        /// <summary>
        /// 讨论内容
        /// </summary>
        [Column("discuss_content")]
        public string Discuss_content { get; set; }

        /// <summary>
        /// 点击量
        /// </summary>
        [Column("click_count")]
        public int Click_count { get; set; }

        /// <summary>
        /// 回复量
        /// </summary>
        [Column("reply_count")]
        public int Reply_count { get; set; }

        /// <summary>
        /// 删除状态[0:停用, 1:启用]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// 操作人（作者）
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



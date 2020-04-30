
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_discuss_reply")]
    public class Labdiscussreply : EntityBase
    {
        /// <summary>
        /// 讨论回复id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 讨论id
        /// </summary>
        [Column("discuss_id")]
        public long Discuss_id { get; set; }

        /// <summary>
        /// 回复内容
        /// </summary>
        [Column("reply_content")]
        public string Reply_content { get; set; }

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



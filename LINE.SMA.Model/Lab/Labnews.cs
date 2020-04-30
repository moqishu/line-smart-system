
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_news")]
    public class Labnews : EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Column("title")]
        public string Title { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [Column("source")]
        public string Source { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        [Column("keyword")]
        public string Keyword { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        [Column("abstractTitle")]
        public string AbstractTitle { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Column("content")]
        public string Content { get; set; }

        /// <summary>
        /// 类别[1:科研成果, 2:科研项目]
        /// </summary>
        [Column("flag")]
        public int Flag { get; set; }

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



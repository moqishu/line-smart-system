
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("sys_button")]
    public class SysButton : EntityBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Column("title")]
        public string Title { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Column("code")]
        public string Code { get; set; }

        /// <summary>
        /// 菜单id
        /// </summary>
        [Column("muneId")]
        public long MuneId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("createTime")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("updateTime")]
        public DateTime? UpdateTime { get; set; }

        }
}



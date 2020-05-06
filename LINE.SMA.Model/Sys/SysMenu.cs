
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("sys_menu")]
    public class SysMenu : EntityBase
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
        /// 网址
        /// </summary>
        [Column("url")]
        public string Url { get; set; }

        /// <summary>
        /// 父级id
        /// </summary>
        [Column("parentId")]
        public long ParentId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Column("sort")]
        public int Sort { get; set; }

        /// <summary>
        /// 模块级别 1-顶级  2-二级
        /// </summary>
        [Column("level")]
        public int Level { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Column("icon")]
        public string Icon { get; set; }

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

        [NotMapped]
        public List<SysMenu> Child { get; set; }

    }
}



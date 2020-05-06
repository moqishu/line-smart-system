
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("sys_author")]
    public class SysAuthor : EntityBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        [Column("roleId")]
        public long RoleId { get; set; }

        /// <summary>
        /// 资源id
        /// </summary>
        [Column("resourceId")]
        public long ResourceId { get; set; }

        /// <summary>
        ///  资源类型 0:菜单;1:按钮
        /// </summary>
        [Column("resourceType")]
        public int ResourceType { get; set; }

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



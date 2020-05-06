
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("sys_role")]
    public class SysRole : EntityBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Column("role_id")]
        public int Role_id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Column("role_name")]
        public string Role_name { get; set; }

        /// <summary>
        /// 角色备注
        /// </summary>
        [Column("role_remark")]
        public string Role_remark { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        [Column("role_desc")]
        public string Role_desc { get; set; }

        /// <summary>
        /// 角色状态 0=无效 1=有效
        /// </summary>
        [Column("role_status")]
        public int Role_status { get; set; }

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

        /// <summary>
        /// 主键
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

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



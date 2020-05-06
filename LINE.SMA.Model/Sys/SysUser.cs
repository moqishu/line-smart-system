
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("sys_user")]
    public class SysUser : EntityBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Column("user_id")]
        public int User_id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Column("user_name")]
        public string User_name { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [Column("user_account")]
        public string User_account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column("user_pwd")]
        public string User_pwd { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Column("user_phone")]
        public string User_phone { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("user_remark")]
        public string User_remark { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Column("user_desc")]
        public string User_desc { get; set; }

        /// <summary>
        /// 状态 0=无效 1=有效
        /// </summary>
        [Column("user_status")]
        public int User_status { get; set; }

        /// <summary>
        /// 0 普通用户 1 内置超级管理员
        /// </summary>
        [Column("user_admin")]
        public int User_admin { get; set; }

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
        /// 用户名
        /// </summary>
        [Column("username")]
        public string Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        [Column("lastLoginTime")]
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        [Column("isAdmin")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 账号状态 0 使用 1 注销
        /// </summary>
        [Column("status")]
        public int Status { get; set; }

        /// <summary>
        /// 账号是否锁定，1：锁定，0未锁定
        /// </summary>
        [Column("isLocked")]
        public bool IsLocked { get; set; }

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

        }
}




using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_user")]
    public class Labuser : EntityBase
    {
        /// <summary>
        /// 人员ID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 人员编号
        /// </summary>
        [Column("user_num")]
        public string User_num { get; set; }

        /// <summary>
        /// 人员登录账号
        /// </summary>
        [Column("user_name")]
        public string User_name { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Column("real_name")]
        public string Real_name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// 性别 0 男 1 女
        /// </summary>
        [Column("sex")]
        public int Sex { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        [Column("class_id")]
        public long Class_id { get; set; }

        /// <summary>
        /// 班级
        /// </summary>
        [Column("class_name")]
        public string Class_name { get; set; }

        /// <summary>
        /// 人员类型 1 学生 2 教师 3 系统管理员
        /// </summary>
        [Column("type")]
        public int Type { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [Column("role_id")]
        public long Role_id { get; set; }

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



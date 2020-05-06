
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
        /// ����ID
        /// </summary>
        [Column("user_id")]
        public int User_id { get; set; }

        /// <summary>
        /// �û���
        /// </summary>
        [Column("user_name")]
        public string User_name { get; set; }

        /// <summary>
        /// �˺�
        /// </summary>
        [Column("user_account")]
        public string User_account { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("user_pwd")]
        public string User_pwd { get; set; }

        /// <summary>
        /// �ֻ���
        /// </summary>
        [Column("user_phone")]
        public string User_phone { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        [Column("user_remark")]
        public string User_remark { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("user_desc")]
        public string User_desc { get; set; }

        /// <summary>
        /// ״̬ 0=��Ч 1=��Ч
        /// </summary>
        [Column("user_status")]
        public int User_status { get; set; }

        /// <summary>
        /// 0 ��ͨ�û� 1 ���ó�������Ա
        /// </summary>
        [Column("user_admin")]
        public int User_admin { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        [Column("create_time")]
        public DateTime? Create_time { get; set; }

        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        [Column("update_time")]
        public DateTime? Update_time { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// �û���
        /// </summary>
        [Column("username")]
        public string Username { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// �ϴε�¼ʱ��
        /// </summary>
        [Column("lastLoginTime")]
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// �Ƿ����Ա
        /// </summary>
        [Column("isAdmin")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// �˺�״̬ 0 ʹ�� 1 ע��
        /// </summary>
        [Column("status")]
        public int Status { get; set; }

        /// <summary>
        /// �˺��Ƿ�������1��������0δ����
        /// </summary>
        [Column("isLocked")]
        public bool IsLocked { get; set; }

        /// <summary>
        /// ��ע
        /// </summary>
        [Column("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        [Column("createTime")]
        public DateTime? CreateTime { get; set; }

        }
}



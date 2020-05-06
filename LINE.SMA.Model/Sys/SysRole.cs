
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
        /// ����ID
        /// </summary>
        [Column("role_id")]
        public int Role_id { get; set; }

        /// <summary>
        /// ��ɫ����
        /// </summary>
        [Column("role_name")]
        public string Role_name { get; set; }

        /// <summary>
        /// ��ɫ��ע
        /// </summary>
        [Column("role_remark")]
        public string Role_remark { get; set; }

        /// <summary>
        /// ��ɫ����
        /// </summary>
        [Column("role_desc")]
        public string Role_desc { get; set; }

        /// <summary>
        /// ��ɫ״̬ 0=��Ч 1=��Ч
        /// </summary>
        [Column("role_status")]
        public int Role_status { get; set; }

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
        /// ��ɫ��
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

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

        /// <summary>
        /// ����ʱ��
        /// </summary>
        [Column("updateTime")]
        public DateTime? UpdateTime { get; set; }

        }
}



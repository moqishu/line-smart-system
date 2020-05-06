
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
        /// ����
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ��ɫid
        /// </summary>
        [Column("roleId")]
        public long RoleId { get; set; }

        /// <summary>
        /// ��Դid
        /// </summary>
        [Column("resourceId")]
        public long ResourceId { get; set; }

        /// <summary>
        ///  ��Դ���� 0:�˵�;1:��ť
        /// </summary>
        [Column("resourceType")]
        public int ResourceType { get; set; }

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



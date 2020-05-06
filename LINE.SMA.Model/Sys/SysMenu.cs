
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
        /// ����
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// ��ַ
        /// </summary>
        [Column("url")]
        public string Url { get; set; }

        /// <summary>
        /// ����id
        /// </summary>
        [Column("parentId")]
        public long ParentId { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("sort")]
        public int Sort { get; set; }

        /// <summary>
        /// ģ�鼶�� 1-����  2-����
        /// </summary>
        [Column("level")]
        public int Level { get; set; }

        /// <summary>
        /// ͼ��
        /// </summary>
        [Column("icon")]
        public string Icon { get; set; }

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

        [NotMapped]
        public List<SysMenu> Child { get; set; }

    }
}



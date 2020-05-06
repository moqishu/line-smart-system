
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
        /// ����
        /// </summary>
        [Column("title")]
        public string Title { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("code")]
        public string Code { get; set; }

        /// <summary>
        /// �˵�id
        /// </summary>
        [Column("muneId")]
        public long MuneId { get; set; }

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



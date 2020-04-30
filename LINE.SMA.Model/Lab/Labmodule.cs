
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_module")]
    public class Labmodule : EntityBase
    {
        /// <summary>
        /// ģ����
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ģ������
        /// </summary>
        [Column("module_name")]
        public string Module_name { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("url")]
        public string Url { get; set; }

        /// <summary>
        /// ģ�鼶�� 1-����  2-���� 
        /// </summary>
        [Column("level")]
        public int Level { get; set; }

        /// <summary>
        /// ����id
        /// </summary>
        [Column("f_id")]
        public long F_id { get; set; }

        /// <summary>
        /// ���ȼ�
        /// </summary>
        [Column("sort")]
        public int Sort { get; set; }

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

        }
}



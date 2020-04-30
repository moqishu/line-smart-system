
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_discuss_reply")]
    public class Labdiscussreply : EntityBase
    {
        /// <summary>
        /// ���ۻظ�id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ����id
        /// </summary>
        [Column("discuss_id")]
        public long Discuss_id { get; set; }

        /// <summary>
        /// �ظ�����
        /// </summary>
        [Column("reply_content")]
        public string Reply_content { get; set; }

        /// <summary>
        /// ɾ��״̬[0:ͣ��, 1:����]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Column("operator")]
        public string Operator { get; set; }

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



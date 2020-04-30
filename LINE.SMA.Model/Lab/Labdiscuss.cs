
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_discuss")]
    public class Labdiscuss : EntityBase
    {
        /// <summary>
        /// ����id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ���۱���
        /// </summary>
        [Column("discuss_title")]
        public string Discuss_title { get; set; }

        /// <summary>
        /// ������id
        /// </summary>
        [Column("discuss_group_id")]
        public long Discuss_group_id { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Column("discuss_group_name")]
        public string Discuss_group_name { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Column("discuss_content")]
        public string Discuss_content { get; set; }

        /// <summary>
        /// �����
        /// </summary>
        [Column("click_count")]
        public int Click_count { get; set; }

        /// <summary>
        /// �ظ���
        /// </summary>
        [Column("reply_count")]
        public int Reply_count { get; set; }

        /// <summary>
        /// ɾ��״̬[0:ͣ��, 1:����]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// �����ˣ����ߣ�
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



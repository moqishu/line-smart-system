
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_news")]
    public class Labnews : EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("title")]
        public string Title { get; set; }

        /// <summary>
        /// ��Դ
        /// </summary>
        [Column("source")]
        public string Source { get; set; }

        /// <summary>
        /// �ؼ���
        /// </summary>
        [Column("keyword")]
        public string Keyword { get; set; }

        /// <summary>
        /// ժҪ
        /// </summary>
        [Column("abstractTitle")]
        public string AbstractTitle { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("content")]
        public string Content { get; set; }

        /// <summary>
        /// ���[1:���гɹ�, 2:������Ŀ]
        /// </summary>
        [Column("flag")]
        public int Flag { get; set; }

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



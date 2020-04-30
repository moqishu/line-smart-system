
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_index_photo")]
    public class Labindexphoto : EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ͼƬ����
        /// </summary>
        [Column("photo_title")]
        public string Photo_title { get; set; }

        /// <summary>
        /// ͼƬԭ�ļ���
        /// </summary>
        [Column("photo_name")]
        public string Photo_name { get; set; }

        /// <summary>
        /// ͼƬ·��
        /// </summary>
        [Column("photo_src")]
        public string Photo_src { get; set; }

        /// <summary>
        /// ͼƬ����
        /// </summary>
        [Column("photo_link")]
        public string Photo_link { get; set; }

        /// <summary>
        /// ͼƬ����[0:�ɹ�, 1:�ֲ�]
        /// </summary>
        [Column("photo_type")]
        public int Photo_type { get; set; }

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



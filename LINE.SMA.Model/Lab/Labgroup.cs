
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_group")]
    public class Labgroup : EntityBase
    {
        /// <summary>
        /// ����id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Column("group_name")]
        public string Group_name { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Column("group_num")]
        public string Group_num { get; set; }

        /// <summary>
        /// �༶id
        /// </summary>
        [Column("class_id")]
        public long Class_id { get; set; }

        /// <summary>
        /// �༶����
        /// </summary>
        [Column("class_name")]
        public string Class_name { get; set; }

        /// <summary>
        /// ��˭����[0:��ʦ, 1:ѧ��]
        /// </summary>
        [Column("type")]
        public int Type { get; set; }

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



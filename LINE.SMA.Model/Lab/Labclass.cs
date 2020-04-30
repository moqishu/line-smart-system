
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_class")]
    public class Labclass : EntityBase
    {
        /// <summary>
        /// �༶ID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// �༶���
        /// </summary>
        [Column("class_code")]
        public string Class_code { get; set; }

        /// <summary>
        /// �༶����
        /// </summary>
        [Column("class_name")]
        public string Class_name { get; set; }

        /// <summary>
        /// ԺϵID
        /// </summary>
        [Column("department_id")]
        public long Department_id { get; set; }

        /// <summary>
        /// Ժϵ����
        /// </summary>
        [Column("department_name")]
        public string Department_name { get; set; }

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



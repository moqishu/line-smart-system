
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_department")]
    public class Labdepartment : EntityBase
    {
        /// <summary>
        /// ԺϵID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// Ժϵ���
        /// </summary>
        [Column("department_code")]
        public string Department_code { get; set; }

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




using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_group_student")]
    public class Labgroupstudent : EntityBase
    {
        /// <summary>
        /// ѧ������id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ����id
        /// </summary>
        [Column("group_id")]
        public long Group_id { get; set; }

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
        /// ѧ��id
        /// </summary>
        [Column("student_id")]
        public long Student_id { get; set; }

        /// <summary>
        /// ѧ������
        /// </summary>
        [Column("student_name")]
        public string Student_name { get; set; }

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



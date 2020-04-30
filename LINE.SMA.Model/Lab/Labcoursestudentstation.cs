
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_course_student_station")]
    public class Labcoursestudentstation : EntityBase
    {
        /// <summary>
        /// ѧ��ԤԼid
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ��λid
        /// </summary>
        [Column("station_id")]
        public long Station_id { get; set; }

        /// <summary>
        /// ԤԼʱ��id
        /// </summary>
        [Column("time_id")]
        public long Time_id { get; set; }

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
        /// ��ǰ״̬[0:ͣ��, 1:����]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// ������id
        /// </summary>
        [Column("operator_id")]
        public long Operator_id { get; set; }

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



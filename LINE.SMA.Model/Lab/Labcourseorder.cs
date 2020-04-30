
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_course_order")]
    public class Labcourseorder : EntityBase
    {
        /// <summary>
        /// ԤԼid
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// �γ�id
        /// </summary>
        [Column("course_id")]
        public long Course_id { get; set; }

        /// <summary>
        /// �༶id
        /// </summary>
        [Column("class_id")]
        public long Class_id { get; set; }

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
        /// ��ע
        /// </summary>
        [Column("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// ɾ��״̬[0:ͣ��, 1:����]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// ����״̬[0:δǩ��, 1:��ǩ��]
        /// </summary>
        [Column("check_work")]
        public int Check_work { get; set; }

        /// <summary>
        /// �Ͽ�״̬[0:δ�Ͽ�, 1:���Ͽ�]
        /// </summary>
        [Column("work_state")]
        public int Work_state { get; set; }

        /// <summary>
        /// ������id
        /// </summary>
        [Column("operator_id")]
        public string Operator_id { get; set; }

        /// <summary>
        /// ����������
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

        /// <summary>
        /// ԤԼʱ��id
        /// </summary>
        [Column("time_id")]
        public long Time_id { get; set; }

        }
}



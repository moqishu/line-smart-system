
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_course_student")]
    public class Labcoursestudent : EntityBase
    {
        /// <summary>
        /// �γ�ѡ��ѧ��id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// �γ�id
        /// </summary>
        [Column("course_id")]
        public long Course_id { get; set; }

        /// <summary>
        /// �γ�����
        /// </summary>
        [Column("course_name")]
        public string Course_name { get; set; }

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
        /// ����ϰ������
        /// </summary>
        [Column("example_content")]
        public string Example_content { get; set; }

        /// <summary>
        /// ϰ��ѧ������[0:δ��, 1:����]
        /// </summary>
        [Column("example_flag")]
        public int Example_flag { get; set; }

        /// <summary>
        /// ϰ���Ƿ�����[0:δ����, 1:������]
        /// </summary>
        [Column("example_checked")]
        public int Example_checked { get; set; }

        /// <summary>
        /// ϰ������
        /// </summary>
        [Column("example_score")]
        public int Example_score { get; set; }

        /// <summary>
        /// ϰ������
        /// </summary>
        [Column("example_comment")]
        public string Example_comment { get; set; }

        /// <summary>
        /// ѧ��ʵ�鱨��
        /// </summary>
        [Column("experiment_report")]
        public string Experiment_report { get; set; }

        /// <summary>
        /// ϰ��ѧ������[0:δ��, 1:����]
        /// </summary>
        [Column("experiment_flag")]
        public int Experiment_flag { get; set; }

        /// <summary>
        /// �����Ƿ�����[0:δ����, 1:������]
        /// </summary>
        [Column("experiment_checked")]
        public int Experiment_checked { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Column("experiment_score")]
        public int Experiment_score { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Column("experiment_comment")]
        public string Experiment_comment { get; set; }

        /// <summary>
        /// ��ʼ����ʱ��
        /// </summary>
        [Column("begin_time")]
        public DateTime? Begin_time { get; set; }

        /// <summary>
        /// ��������ʱ��
        /// </summary>
        [Column("end_time")]
        public DateTime? End_time { get; set; }

        /// <summary>
        /// ��ҵ״̬[0:ͣ��, 1:δ��ʼ 20:ִ���� 30:�����]
        /// </summary>
        [Column("example_state")]
        public int Example_state { get; set; }

        /// <summary>
        /// ����״̬[0:ͣ��, 1:δ��ʼ 20:ִ���� 30:�����]
        /// </summary>
        [Column("experiment_state")]
        public int Experiment_state { get; set; }

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

        /// <summary>
        /// ԤԼʱ��id
        /// </summary>
        [Column("time_id")]
        public long Time_id { get; set; }

        }
}



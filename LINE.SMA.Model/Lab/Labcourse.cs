
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_course")]
    public class Labcourse : EntityBase
    {
        /// <summary>
        /// �γ�id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// �γ�����
        /// </summary>
        [Column("course_name")]
        public string Course_name { get; set; }

        /// <summary>
        /// ʵ��id
        /// </summary>
        [Column("experiment_id")]
        public long Experiment_id { get; set; }

        /// <summary>
        /// ʵ������
        /// </summary>
        [Column("experiment_name")]
        public string Experiment_name { get; set; }

        /// <summary>
        /// ϰ��id
        /// </summary>
        [Column("example_id")]
        public long Example_id { get; set; }

        /// <summary>
        /// ϰ������
        /// </summary>
        [Column("example_name")]
        public string Example_name { get; set; }

        /// <summary>
        /// ϰ������
        /// </summary>
        [Column("example_content")]
        public string Example_content { get; set; }

        /// <summary>
        /// ԤԼʱ��id
        /// </summary>
        [Column("time_id")]
        public long Time_id { get; set; }

        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        [Column("begin_time")]
        public DateTime? Begin_time { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        [Column("end_time")]
        public DateTime? End_time { get; set; }

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
        /// ����id
        /// </summary>
        [Column("room_id")]
        public long Room_id { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Column("room_name")]
        public string Room_name { get; set; }

        /// <summary>
        /// ��λ����
        /// </summary>
        [Column("place_count")]
        public int Place_count { get; set; }

        /// <summary>
        /// ��ԤԼ��λ����
        /// </summary>
        [Column("place_ok_count")]
        public int Place_ok_count { get; set; }

        /// <summary>
        /// ɾ��״̬[0:ͣ��, 1:δ��ʼ 20:ִ���� 30:�����]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// ��ʦid
        /// </summary>
        [Column("teacher_id")]
        public long Teacher_id { get; set; }

        /// <summary>
        /// ��ʦ����
        /// </summary>
        [Column("teacher_name")]
        public string Teacher_name { get; set; }

        /// <summary>
        /// ��ʦ����
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



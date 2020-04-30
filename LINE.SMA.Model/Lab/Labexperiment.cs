
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_experiment")]
    public class Labexperiment : EntityBase
    {
        /// <summary>
        /// ʵ��id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ʵ����
        /// </summary>
        [Column("experiment_code")]
        public string Experiment_code { get; set; }

        /// <summary>
        /// ʵ������
        /// </summary>
        [Column("experiment_name")]
        public string Experiment_name { get; set; }

        /// <summary>
        /// ����id
        /// </summary>
        [Column("type_id")]
        public long Type_id { get; set; }

        /// <summary>
        /// ʵ������
        /// </summary>
        [Column("type_name")]
        public string Type_name { get; set; }

        /// <summary>
        /// ʵ�������
        /// </summary>
        [Column("student_type")]
        public string Student_type { get; set; }

        /// <summary>
        /// ÿ������
        /// </summary>
        [Column("person_count")]
        public int Person_count { get; set; }

        /// <summary>
        /// �ƻ�ѧʱ
        /// </summary>
        [Column("study_time")]
        public int Study_time { get; set; }

        /// <summary>
        /// ʵ��̳�
        /// </summary>
        [Column("experiment_book")]
        public string Experiment_book { get; set; }

        /// <summary>
        /// ���˷�ʽ
        /// </summary>
        [Column("check_type")]
        public string Check_type { get; set; }

        /// <summary>
        /// ʵ���豸������
        /// </summary>
        [Column("experiment_count")]
        public string Experiment_count { get; set; }

        /// <summary>
        /// ʵ������
        /// </summary>
        [Column("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// Ŀ����Ҫ��
        /// </summary>
        [Column("require_content")]
        public string Require_content { get; set; }

        /// <summary>
        /// ʵ������
        /// </summary>
        [Column("file_name")]
        public string File_name { get; set; }

        /// <summary>
        /// ʵ��url
        /// </summary>
        [Column("file_url")]
        public string File_url { get; set; }

        /// <summary>
        /// ʵ���С
        /// </summary>
        [Column("file_size")]
        public int File_size { get; set; }

        /// <summary>
        /// ��ѧ�ƻ�����
        /// </summary>
        [Column("file_name2")]
        public string File_name2 { get; set; }

        /// <summary>
        /// ��ѧ�ƻ�url
        /// </summary>
        [Column("file_url2")]
        public string File_url2 { get; set; }

        /// <summary>
        /// ��ѧ����
        /// </summary>
        [Column("file_name3")]
        public string File_name3 { get; set; }

        /// <summary>
        /// ��ѧ����url
        /// </summary>
        [Column("file_url3")]
        public string File_url3 { get; set; }

        /// <summary>
        /// ɾ��״̬[0:ͣ��, 1:���� 2������]
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




using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_user")]
    public class Labuser : EntityBase
    {
        /// <summary>
        /// ��ԱID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ��Ա���
        /// </summary>
        [Column("user_num")]
        public string User_num { get; set; }

        /// <summary>
        /// ��Ա��¼�˺�
        /// </summary>
        [Column("user_name")]
        public string User_name { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("real_name")]
        public string Real_name { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// �Ա� 0 �� 1 Ů
        /// </summary>
        [Column("sex")]
        public int Sex { get; set; }

        /// <summary>
        /// �༶ID
        /// </summary>
        [Column("class_id")]
        public long Class_id { get; set; }

        /// <summary>
        /// �༶
        /// </summary>
        [Column("class_name")]
        public string Class_name { get; set; }

        /// <summary>
        /// ��Ա���� 1 ѧ�� 2 ��ʦ 3 ϵͳ����Ա
        /// </summary>
        [Column("type")]
        public int Type { get; set; }

        /// <summary>
        /// ��ɫID
        /// </summary>
        [Column("role_id")]
        public long Role_id { get; set; }

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



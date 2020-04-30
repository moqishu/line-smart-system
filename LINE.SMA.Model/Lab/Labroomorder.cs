
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_room_order")]
    public class Labroomorder : EntityBase
    {
        /// <summary>
        /// ԤԼID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ʱ��id
        /// </summary>
        [Column("time_id")]
        public long Time_id { get; set; }

        /// <summary>
        /// ����ID
        /// </summary>
        [Column("room_id")]
        public long Room_id { get; set; }

        /// <summary>
        /// ���ұ��
        /// </summary>
        [Column("room_code")]
        public string Room_code { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Column("room_name")]
        public string Room_name { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Column("room_day")]
        public string Room_day { get; set; }

        /// <summary>
        /// ��ʱ����
        /// </summary>
        [Column("time_name")]
        public string Time_name { get; set; }

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
        /// ��ʦID
        /// </summary>
        [Column("teacher_id")]
        public long Teacher_id { get; set; }

        /// <summary>
        /// ��ʦ����
        /// </summary>
        [Column("teacher_name")]
        public string Teacher_name { get; set; }

        /// <summary>
        /// �����ID
        /// </summary>
        [Column("shenhe_id")]
        public long Shenhe_id { get; set; }

        /// <summary>
        /// ���״̬[0:��Ч, 10: ԤԼ���ύ(�����), 20:ԤԼ�����ύ(�����) , 30: ԤԼδͨ��, 100: ԤԼͨ��]
        /// </summary>
        [Column("audit_state")]
        public int Audit_state { get; set; }

        /// <summary>
        /// ɾ��״̬[0:ͣ��, 1:����]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// ������[���ͨ�� �����,��ͨ�� ���������]
        /// </summary>
        [Column("remark")]
        public string Remark { get; set; }

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



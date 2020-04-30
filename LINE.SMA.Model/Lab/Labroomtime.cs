
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_room_time")]
    public class Labroomtime : EntityBase
    {
        /// <summary>
        /// ����ID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

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
        /// ʱ�����ڣ����� ���� ����
        /// </summary>
        [Column("room_time_type")]
        public string Room_time_type { get; set; }

        /// <summary>
        /// ɾ��״̬[0:ͣ��, 1:����]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// �Ƿ��ԤԼ[1:��ԤԼ, 2:����ԤԼ]
        /// </summary>
        [Column("check_state")]
        public int Check_state { get; set; }

        /// <summary>
        /// ���״̬ 0:��Ч, 1: ��˲�ͨ��, 2: ���ͨ�� 
        /// </summary>
        [Column("audit_state")]
        public int Audit_state { get; set; }

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



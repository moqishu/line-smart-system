
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_room")]
    public class Labroom : EntityBase
    {
        /// <summary>
        /// ����ID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

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
        /// Ժϵ����
        /// </summary>
        [Column("department")]
        public string Department { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        [Column("measure_area")]
        public string Measure_area { get; set; }

        /// <summary>
        /// �ص�
        /// </summary>
        [Column("area")]
        public string Area { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        [Column("leader")]
        public string Leader { get; set; }

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
        /// ��λ��
        /// </summary>
        [Column("room_rows")]
        public int Room_rows { get; set; }

        /// <summary>
        /// ��λ��
        /// </summary>
        [Column("room_cols")]
        public int Room_cols { get; set; }

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



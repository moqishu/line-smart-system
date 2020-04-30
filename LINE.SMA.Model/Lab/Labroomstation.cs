
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_room_station")]
    public class Labroomstation : EntityBase
    {
        /// <summary>
        /// ��λID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ����ID
        /// </summary>
        [Column("room_id")]
        public long Room_id { get; set; }

        /// <summary>
        /// ��λ�ڼ���
        /// </summary>
        [Column("room_row")]
        public int Room_row { get; set; }

        /// <summary>
        /// ��λ�ڼ���
        /// </summary>
        [Column("room_col")]
        public int Room_col { get; set; }

        /// <summary>
        /// ��λ����
        /// </summary>
        [Column("station_name")]
        public string Station_name { get; set; }

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



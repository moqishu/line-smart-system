
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_example")]
    public class Labexample : EntityBase
    {
        /// <summary>
        /// ϰ��id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

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
        /// ϰ����;
        /// </summary>
        [Column("example_use")]
        public string Example_use { get; set; }

        /// <summary>
        /// �Ƿ�鿴[0:δ�鿴, 1:�Ѳ鿴]
        /// </summary>
        [Column("looked")]
        public int Looked { get; set; }

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



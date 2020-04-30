
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_message")]
    public class Labmessage : EntityBase
    {
        /// <summary>
        /// ʵ��id
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ʵ��������
        /// </summary>
        [Column("message_name")]
        public string Message_name { get; set; }

        /// <summary>
        /// ʵ������
        /// </summary>
        [Column("message_content")]
        public string Message_content { get; set; }

        /// <summary>
        /// ���ͷ�����[0 ѧ�� 1 ��ʦ 2 ϵͳ����Ա]
        /// </summary>
        [Column("sender")]
        public int Sender { get; set; }

        /// <summary>
        /// ���ͷ�����[0 ѧ�� 1 ��ʦ 2 ϵͳ����Ա]
        /// </summary>
        [Column("receiver")]
        public int Receiver { get; set; }

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



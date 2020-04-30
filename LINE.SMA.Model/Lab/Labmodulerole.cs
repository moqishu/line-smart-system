
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_module_role")]
    public class Labmodulerole : EntityBase
    {
        /// <summary>
        /// ģ���ɫid
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// ģ��id
        /// </summary>
        [Column("module_id")]
        public int Module_id { get; set; }

        /// <summary>
        /// ��ɫid 
        /// </summary>
        [Column("role_id")]
        public int Role_id { get; set; }

        /// <summary>
        /// 0-ʹ��  1-ͣ��
        /// </summary>
        [Column("state")]
        public int State { get; set; }

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




using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LINE.SMA.Infrastructure;

namespace LINE.SMA.Model
{
    [Table("lab_index_photo")]
    public class Labindexphoto : EntityBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 图片标题
        /// </summary>
        [Column("photo_title")]
        public string Photo_title { get; set; }

        /// <summary>
        /// 图片原文件名
        /// </summary>
        [Column("photo_name")]
        public string Photo_name { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        [Column("photo_src")]
        public string Photo_src { get; set; }

        /// <summary>
        /// 图片连接
        /// </summary>
        [Column("photo_link")]
        public string Photo_link { get; set; }

        /// <summary>
        /// 图片类型[0:成果, 1:轮播]
        /// </summary>
        [Column("photo_type")]
        public int Photo_type { get; set; }

        /// <summary>
        /// 删除状态[0:停用, 1:启用]
        /// </summary>
        [Column("state")]
        public int State { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [Column("operator")]
        public string Operator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        public DateTime? Create_time { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Column("update_time")]
        public DateTime? Update_time { get; set; }

        }
}



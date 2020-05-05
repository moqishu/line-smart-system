using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINE.SMA.Model
{
    /// <summary>
    /// 自定义菜单转换
    /// </summary>
    public class CustomMenu
    {
        public long Id { get; set; }

        public long ParentId { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public List<CustomMenu> ChildNodes { get; set; }

    }
}

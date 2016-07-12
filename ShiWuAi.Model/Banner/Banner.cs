using ShiWuAi.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiWuAi.Model.Banner
{
    [Table("Tb_B_Banner")]
    public class Banner:Basic
    {
        //主键Id
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //类型Id
        public int Category_Id { get; set; }
        [MaxLength(255)]
        //标题
        public string Title { get; set; }
        //图片
        [MaxLength(255)]
        public string Pic { get; set; }
        //链接地址
        [MaxLength(255)]
        public string Link { get; set; }
        //图片alt属性
        [MaxLength(255)]
        public string Alt { get; set; }

    }
}

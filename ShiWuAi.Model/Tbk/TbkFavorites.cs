using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiWuAi.Model.Tbk
{
    [Table("Tb_T_TbkFavorites")]
    public class TbkFavorites : Basic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(255)]
        public string type { get; set; }//选品库类型，1：普通类型，2高佣金类型
        [MaxLength(255)]
        public string favorites_id { get; set; }//Number 100选品库id
        [MaxLength(255)]
        public string favorites_title { get; set; }//女装选品组选品组名称

    }
}

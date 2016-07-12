using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiWuAi.Model.Common
{
    [Table("Tb_C_File")]
    public class File:Basic
    {
        //主鍵Id
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string FileName { get; set; }

        [MaxLength(255)]
        public string FilePath { get; set; }
    }
}

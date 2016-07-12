using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiWuAi.Model.Tbk
{
    [Table("Tb_T_TbkItem")]
    public class TbkItem : Basic
    {
        //主键Id
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(255)]
        public string num_iid { get; set; }// 商品ID
        [MaxLength(255)]
        public string title { get; set; }// 连衣裙商品标题
        [MaxLength(255)]
        public string pict_url { get; set; }//http://gi4.md.alicdn.com/bao/uploaded/i4/xxx.jpg商品主图
        //public string[] small_images;// http://gi4.md.alicdn.com/bao/uploaded/i4/xxx.jpg商品小图列表
        [MaxLength(255)]
        public string reserve_price { get; set; }// 102.00商品一口价格
        [MaxLength(255)]
        public string zk_final_price { get; set; }//88.00商品折扣价格
        [MaxLength(10)]
        public string user_type { get; set; }// Number 1卖家类型，0表示集市，1表示商城
        [MaxLength(255)]
        public string provcity { get; set; }// String 杭州宝贝所在地
        [MaxLength(500)]
        public string item_url { get; set; }// String http://detail.m.tmall.com/item.htm?id=xxx商品地址
        [MaxLength(255)]
        public string nick { get; set; }// String demo卖家昵称
        [MaxLength(255)]
        public string seller_id { get; set; }// Number 123卖家id
        [MaxLength(255)]
        public string volume { get; set; }// Number 130天销量
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }//数据库需要 ID 字段以获取主键。
        public string Title { get; set; }

        [DataType(DataType.Date)]
        //[DataType(DataType.Date)]：[DataType] 属性指定数据的类型 (Date)。 通过此特性：
        //用户无需在日期字段中输入时间信息。
        //仅显示日期，而非时间信息。
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}

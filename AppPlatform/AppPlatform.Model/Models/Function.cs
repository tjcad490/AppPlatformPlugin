using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Model.Models
{


    public partial class Function
    {
        [Key]
        [Required]
        [DisplayName("功能ID")]
        public int Function_ID { get; set; }
        [Required]
        [DisplayName("父节点ID")]
        public int Function_PID { get; set; }
        [Required]
        [DisplayName("功能名称")]
        public string Function_Name { get; set; }
        [Required]
        [DisplayName("描述")]
        public string Function_Desc { get; set; }

        [Required]
        [DisplayName("功能URL")]
        public String Function_Url { get; set; }

        [DisplayName("备注")]
        public string Function_Note { get; set; }

        //导航属性

        public ICollection<Group_Function> Group_Functions { get; set; }
    }
}

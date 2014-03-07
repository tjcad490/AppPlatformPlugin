using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Model.Models
{
    public partial class AppClass
    {
        [Key]
        [Required]
        [DisplayName("分类编号")]
        public int AppClass_ID { get; set; }//主键

        [Required]
        [MaxLength(20)]
        [DisplayName("分类名称")]
        public string AppClass_Name { get; set; }

        [Required]
        [DisplayName("上级分类ID")]
        public int AppClass_PID { get; set; }

        [DisplayName("备注")]
        public string AppClass_Note { get; set; }

        public ICollection<App_AppClass> App_AppClass { get; set; }//导航属性
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Model.Models
{

    public partial class TaskList
    {
        [Key]
        [Required]
        [DisplayName("任务ID")]
        public int Task_ID { get; set; }//主键
        [Required]
        [DisplayName("任务名称")]
        public string Task_Name { get; set; }
        [Required]
        [DisplayName("任务内容")]
        public string Task_Content { get; set; }
        [Required]
        [DisplayName("任务URL")]
        public String Task_Url { get; set; }
        [Required]
        [DisplayName("任务创建人")]
        public int Create_ID { get; set; }

        [Required]
        [DisplayName("当前任务执行者")]
        public int Now_ID { get; set; }

        [Required]
        [DisplayName("任务承接人")]
        public int Next_ID { get; set; }
        [Required]
        [DisplayName("任务完成情况")]
        public bool Completion_Percentage { get; set; }
        [Required]
        [DisplayName("截止时间")]
        public System.DateTime DeadLine { get; set; }
        [Required]
        [DisplayName("等级")]
        public int Rank { get; set; }
        [Required]
        [DisplayName("备注")]
        public string Tank_Note { get; set; }

        public ICollection<User_Task> User_Tasks { get; set; }//导航属性
    }
}

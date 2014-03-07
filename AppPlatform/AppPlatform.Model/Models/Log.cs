using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Model.Models
{

    public partial class Log
    {
        [Key]
        [Required]
        [DisplayName("日志ID")]
        public int Log_ID { get; set; }

        [Required]
        [DisplayName("日志名称")]
        public string Log_Name { get; set; }

        [Required]
        [DisplayName("日志内容")]
        public String Log_Content { get; set; }

        [Required]
        [DisplayName("生成日志的用户")]
        public int User_ID { get; set; }

        [Required]
        [DisplayName("生成日志的时间")]
        public System.DateTime Log_Time { get; set; }

        public enum t{
             SystemLog,
             OperationLog
        }

        [Required]
        [DisplayName("日志分类")]
        public t Log_Class { get; set; }

        [DisplayName("备注")]
        public string Log_Note { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Model.Models
{
    public partial class Enterprise
    {
        [Key]
        
        [Required]
        [DisplayName("企业编号")]
        public int Enterprise_ID { get; set; }
        [Required]
        [DisplayName("企业名称")]
        public string Enterprise_Name { get; set; }
        [Required]
        [DisplayName("企业法人")]
        public string Enterprise_Rep { get; set; }
        [Required]
        [DisplayName("企业内部编号")]
        public int Enterprise_Code { get; set; }
        [Required]
        [DisplayName("企业标志图标")]
        public byte[] Enterprise_Logo { get; set; }
        [Required]
        [DisplayName("企业规模")]
        public int Enterprise_Scale { get; set; }
        [Required]
        [DisplayName("企业所在省份")]
        public string Enterprise_Province { get; set; }
        [Required]
        [DisplayName("企业所在城市")]
        public string Enterprise_City { get; set; }
        [Required]
        [DisplayName("企业地址")]
        public string Enterprise_Addr { get; set; }
        [Required]
        [DisplayName("邮编")]
        public string Enterprise_ZipCode { get; set; }
        [Required]
        [Phone]
        [DisplayName("企业电话 ")]
        public string Enterprise_Tel { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("企业邮箱")]
        public string Enterprise_Email { get; set; }
        [Required]
        [DisplayName("邮箱验证")]
        public bool Checked { get; set; }

        [Required]
        [DisplayName("企业传真")]
        public string Enterprise_Fax { get; set; }
        [DisplayName("")]
        public string Enterprise_Site { get; set; }
        [Required]
        [DisplayName("企业创建时间")]
        public System.DateTime EnterPrise_Create_Time { get; set; }
        [DisplayName("企业描述")]
        public string Enterprise_Description { get; set; }
        [DisplayName("企业备注")]
        public string Enterprise_Option { get; set; }

        public ICollection<Enterprise_EnterpriseClass> Enterprise_EnterpriseClasses { get; set; }//导航属性
        public ICollection<InternalOrganization>InternalOrganizations { get; set; }//导航属性
       
        public ICollection<Role> Roles { get; set; }//导航属性
        public ICollection<Enterprise_App> Enterprise_Apps { get; set; }//导航属性
    }
}

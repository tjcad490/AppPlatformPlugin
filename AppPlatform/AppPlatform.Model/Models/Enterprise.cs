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
        [DisplayName("��ҵ���")]
        public int Enterprise_ID { get; set; }
        [Required]
        [DisplayName("��ҵ����")]
        public string Enterprise_Name { get; set; }
        [Required]
        [DisplayName("��ҵ����")]
        public string Enterprise_Rep { get; set; }
        [Required]
        [DisplayName("��ҵ�ڲ����")]
        public int Enterprise_Code { get; set; }
        [Required]
        [DisplayName("��ҵ��־ͼ��")]
        public byte[] Enterprise_Logo { get; set; }
        [Required]
        [DisplayName("��ҵ��ģ")]
        public int Enterprise_Scale { get; set; }
        [Required]
        [DisplayName("��ҵ����ʡ��")]
        public string Enterprise_Province { get; set; }
        [Required]
        [DisplayName("��ҵ���ڳ���")]
        public string Enterprise_City { get; set; }
        [Required]
        [DisplayName("��ҵ��ַ")]
        public string Enterprise_Addr { get; set; }
        [Required]
        [DisplayName("�ʱ�")]
        public string Enterprise_ZipCode { get; set; }
        [Required]
        [Phone]
        [DisplayName("��ҵ�绰 ")]
        public string Enterprise_Tel { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("��ҵ����")]
        public string Enterprise_Email { get; set; }
        [Required]
        [DisplayName("������֤")]
        public bool Checked { get; set; }

        [Required]
        [DisplayName("��ҵ����")]
        public string Enterprise_Fax { get; set; }
        [DisplayName("")]
        public string Enterprise_Site { get; set; }
        [Required]
        [DisplayName("��ҵ����ʱ��")]
        public System.DateTime EnterPrise_Create_Time { get; set; }
        [DisplayName("��ҵ����")]
        public string Enterprise_Description { get; set; }
        [DisplayName("��ҵ��ע")]
        public string Enterprise_Option { get; set; }

        public ICollection<Enterprise_EnterpriseClass> Enterprise_EnterpriseClasses { get; set; }//��������
        public ICollection<InternalOrganization>InternalOrganizations { get; set; }//��������
       
        public ICollection<Role> Roles { get; set; }//��������
        public ICollection<Enterprise_App> Enterprise_Apps { get; set; }//��������
    }
}
